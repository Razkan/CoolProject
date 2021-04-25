using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Interfaces.Model.Db;
using Interfaces.Model.Db.Attribute;
using Library.Emit;
using Library.Service.Repository.Db.Setting;
using Serilog;

namespace Library.Service.Repository.Db.Databases
{
    // TODO Update to prepared statements https://github.com/OWASP/CheatSheetSeries/blob/d8edfc0659e986829dec36ee0ee093688f0bf694/cheatsheets/Query_Parameterization_Cheat_Sheet.md
    public class SqLiteDatabase : IDatabaseContext
    {
        private const string INTEGER = nameof(INTEGER);
        private const string TEXT = nameof(TEXT);
        private const string Id = nameof(Id);

        private const string EnumerableDelimiter = "|";

        private static readonly Type[] StringTypeArr = {typeof(string)};

        private static readonly MethodInfo ContainsAsyncMethod =
            typeof(SqLiteDatabase).GetMethod(nameof(ContainsAsync), StringTypeArr);

        private static readonly MethodInfo SelectAsyncMethod =
            typeof(SqLiteDatabase).GetMethod(nameof(SelectAsync), StringTypeArr);

        private static readonly MethodInfo InsertAsyncMethod =
            typeof(SqLiteDatabase).GetMethod(nameof(InsertAsync));

        private readonly DbConnection _dbConnection;
        private readonly IDatabaseSettings _settings;

        public SqLiteDatabase(
            DbConnection dbConnection,
            IDatabaseSettings settings)
        {
            _dbConnection = dbConnection;
            _settings = settings;

            _dbConnection.ConnectionString = _settings.Args;
        }

        public async Task RunAsync()
        {
            Setup();
            await EnsureDbConnection();
            await CreateInterfaceTables();
        }

        private void Setup()
        {
            if (_settings.Recreate)
            {
                if (Directory.Exists(_settings.Directory))
                {
                    Directory.Delete(_settings.Directory, true);
                }

                Directory.CreateDirectory(_settings.Directory);
                SQLiteConnection.CreateFile(_settings.File);
            }
            else
            {
                if (!Directory.Exists(_settings.Directory)) Directory.CreateDirectory(_settings.Directory);
                if (!File.Exists(_settings.File)) SQLiteConnection.CreateFile(_settings.File);
            }
        }

        private async Task CreateInterfaceTables()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var attributeType = typeof(TableInterfaceAttribute);
            
            foreach (var assembly in assemblies)
            {
                foreach (var type in GetTypesWithAttributeType(assembly, attributeType))
                {
                    try
                    {
                        var cmd = new SQLiteCommand
                        {
                            CommandType = CommandType.Text,
                            CommandText = $"CREATE TABLE IF NOT EXISTS {type.Name.ToSqlLiteral()} (" +
                                          $"{CreateQueryFromInterface(type)});"
                        };
                        await ExecuteNonQueryAsync(cmd);
                    }
#pragma warning disable 168
                    catch (Exception e)
#pragma warning restore 168
                    {
                        Log.Error(e, e.Message);
                    }
                }
            }
        }

        private static IEnumerable<Type> GetTypesWithAttributeType(Assembly assembly, Type attributeType) => assembly
            .GetTypes()
            .Where(type => type.GetCustomAttributes(attributeType, true).Length > 0);

        private static string CreateQueryFromProperties(Type t) => string.Join(", ",
            t.GetProperties().Select(e =>
            {
                if (IsPrimaryKey(e)) return $"[{e.Name}] TEXT NON NULL PRIMARY KEY";
                if (IsUnique(e)) return $"[{e.Name}] TEXT NON NULL UNIQUE";
                return $"[{e.Name}] {ToSQLType(e.PropertyType)} NON NULL";
            }));

        private static string CreateQueryFromInterface(Type t) => string.Join(", ",
            t.GetAllPublicProperties().Select(e =>
            {
                if (IsPrimaryKey(e)) return $"[{e.Name}] TEXT NON NULL PRIMARY KEY";
                if (IsUnique(e)) return $"[{e.Name}] TEXT NON NULL UNIQUE";
                return $"[{e.Name}] {ToSQLType(e.PropertyType)} NON NULL";
            }));

        private static string ToSQLType(Type t)
        {
            switch (Type.GetTypeCode(t))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return INTEGER;
                default:
                    return TEXT;
            }
        }

        private async Task EnsureDbConnection()
        {
            if (_dbConnection.State == ConnectionState.Closed)
            {
                await _dbConnection.OpenAsync();
            }
        }

        public async Task<T> SelectAsync<T>(string id)
        {
            await EnsureDbConnection();

            var type = typeof(T);
            var cmd = new SQLiteCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT * FROM {type.Name.ToSqlLiteral()} " +
                              "WHERE id=@id;";
            cmd.Parameters.AddWithValue("@id", id);

            return await ExecuteReaderAsync(cmd, async reader =>
            {
                await reader.ReadAsync();
                return reader.HasRows
                    ? (T) await ToObjectAsync(reader, type)
                    : default;
            }).Unwrap();
        }

        public async Task<IEnumerable<T>> SelectAllAsync<T>()
        {
            await EnsureDbConnection();

            var type = typeof(T);
            var cmd = new SQLiteCommand
            {
                CommandType = CommandType.Text,
                CommandText = $"SELECT * FROM {type.Name.ToSqlLiteral()};"
            };

            return await ExecuteReaderAsync(cmd, async reader =>
            {
                var list = new List<T>();
                while (await reader.ReadAsync())
                {
                    list.Add((T) await ToObjectAsync(reader, type));
                }

                return list;
            }).Unwrap();
        }

        public async Task<bool> ContainsAsync<T>(string id)
        {
            await EnsureDbConnection();

            var type = typeof(T);
            var cmd = new SQLiteCommand {CommandType = CommandType.Text};
            cmd.CommandText = $"SELECT * FROM {type.Name.ToSqlLiteral()} " +
                              "WHERE id=@id " +
                              "LIMIT 1;";
            cmd.Parameters.AddWithValue("@id", id);

            return await ExecuteReaderAsync(cmd, async reader =>
            {
                await reader.ReadAsync();
                return reader.HasRows;
            }).Unwrap();
        }

        public async Task InsertAsync<T>(T entity)
        {
            await EnsureDbConnection();

            var parameterType = typeof(T);
            var entityType = entity.GetType();

            await RecursiveInsert(entity, entityType);
            var cmd = new SQLiteCommand
            {
                CommandType = CommandType.Text,
                CommandText = $"INSERT OR IGNORE INTO {parameterType.Name.ToSqlLiteral()}({GetPropertyNames(entityType)}) " +
                              $"VALUES({GetPropertyParameterizedNamesInsert(entityType)});"
            };
            AddPropertyValues(cmd, entity, entityType);
            await ExecuteNonQueryAsync(cmd);
        }

        /// <summary>
        /// Recursively adds internal objects not yet stored in the db.
        /// Example: new Account(..., ..., new User()), first User would be stored in the db, then Account. 
        /// </summary>
        private async Task RecursiveInsert(object entity, Type entityType)
        {
            foreach (var pi in entityType.GetAllPublicProperties())
            {
                if (IsDbObjectCollection(pi))
                {
                    var enumerable = (IEnumerable) pi.GetValue(entity);
                    if (enumerable != null)
                    {
                        var genericArguments = pi.PropertyType.GetGenericArguments();
                        foreach (var obj in enumerable)
                        {
                            if (!await InternalContainsAsync(GetPropertyId(obj), genericArguments))
                                await InternalInsertAsync(obj, genericArguments);
                        }
                    }
                }
            }
        }

        public async Task UpdateAsync<T>(T entity)
        {
            await EnsureDbConnection();
            
            var type = typeof(T);
            var cmd = new SQLiteCommand
            {
                CommandType = CommandType.Text,
                CommandText = $"UPDATE {type.Name.ToSqlLiteral()} " +
                              $"SET {GetPropertyParameterizedNamesUpdate(type)} " +
                              "WHERE id = @entityId;"
            };
            AddPropertyValues(cmd, entity, type);
            cmd.Parameters.AddWithValue("@entityId", GetPropertyId(entity));
            await ExecuteNonQueryAsync(cmd);
        }

        public async Task DeleteAsync<T>(T entity)
        {
            await EnsureDbConnection();
            
            var type = typeof(T);
            var cmd = new SQLiteCommand
            {
                CommandType = CommandType.Text,
                CommandText = $"DELETE FROM {type.Name.ToSqlLiteral()} " +
                              "WHERE id = @id;"
            };
            cmd.Parameters.AddWithValue("@id", GetPropertyId(entity));
            await ExecuteNonQueryAsync(cmd);
        }

        public async Task<ulong> CountAsync<T>()
        {
            await EnsureDbConnection();

            var type = typeof(T);
            var cmd = new SQLiteCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT COUNT(*) " +
                              $"FROM {type.Name.ToSqlLiteral()}"
            };

            return await ExecuteReaderAsync(cmd, async reader =>
            {
                await reader.ReadAsync();
                return reader.HasRows
                    ? Convert.ToUInt64(reader.GetValue(0))
                    : default;
            }).Unwrap();
        }

        private async Task<T> ExecuteReaderAsync<T>(DbCommand cmd, Func<DbDataReader, T> func)
        {
            cmd.Connection = _dbConnection;

            try
            {
                await using var reader = await cmd.ExecuteReaderAsync();
                return func(reader);
            }
#pragma warning disable 168
            catch (Exception e)
#pragma warning restore 168
            {
                Log.Error(e, e.Message);
                return default;
            }
        }

        private async Task ExecuteNonQueryAsync(DbCommand cmd)
        {
            cmd.Connection = _dbConnection;

            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
#pragma warning disable 168
            catch (Exception e)
#pragma warning restore 168
            {
                Log.Error(e, e.Message);
            }
        }

        private async Task<object> ToObjectAsync(IDataRecord reader, Type entityType)
        {
            var entity = InterfaceBuilder.New().Build(entityType);
            entityType = entity.GetType();

            for (var i = 0; i < reader.FieldCount; i++)
            {
                var propertyInfo = entityType.GetProperty(reader.GetName(i));
                if (propertyInfo == null) continue;

                propertyInfo.SetValue(entity, await ToObject(reader.GetValue(i)));

                async Task<object> ToObject(object obj)
                {
                    return propertyInfo switch
                    {
                        _ when IsDateTime(propertyInfo) => DateTime.Parse(obj.ToString()),
                        _ when IsTimeSpan(propertyInfo) => TimeSpan.Parse(obj.ToString()),
                        _ when IsUShort(propertyInfo) => ushort.Parse(obj.ToString()),
                        _ when IsBool(propertyInfo) => (obj.ToString() != "0"),
                        _ when IsEnum(propertyInfo.PropertyType) => Enum.ToObject(propertyInfo.PropertyType, obj),
                        _ when IsDbObjectCollection(propertyInfo) => await GetDbObjectCollection(propertyInfo, obj),
                        _ when IsDbPrimitiveCollection(propertyInfo) => GetDbPrimitiveCollection(propertyInfo, obj),
                        _ => Convert.ChangeType(obj, propertyInfo.PropertyType)
                    };
                }
            }

            return entity;
        }

        private static object GetDbPrimitiveCollection(PropertyInfo pi, object obj)
        {
            var values = (string) obj;
            if (string.IsNullOrWhiteSpace(values)) return null;

            var genericArguments = pi.PropertyType.GetGenericArguments().First();
            var listType = typeof(List<>);
            var constructedListType = listType.MakeGenericType(genericArguments);
            var list = (IList) Activator.CreateInstance(constructedListType);

            foreach (var value in values.Split(EnumerableDelimiter))
            {
                var convert = IsEnum(genericArguments)
                    ? Enum.Parse(genericArguments, value)
                    : Convert.ChangeType(value, genericArguments);
                list.Add(convert);
            }

            return list;
        }

        private async Task<object> GetDbObjectCollection(PropertyInfo pi, object obj)
        {
            string values = (string) obj;
            if (string.IsNullOrWhiteSpace(values)) return null;

            var genericArguments = pi.PropertyType.GetGenericArguments();
            var listType = typeof(List<>);
            var constructedListType = listType.MakeGenericType(genericArguments);
            var list = (IList) Activator.CreateInstance(constructedListType);

            foreach (var value in ((string) obj).Split(EnumerableDelimiter))
            {
                var result = await InternalSelectAsync(value, genericArguments);
                list.Add(result);
            }

            return list;
        }

        private async Task<bool> InternalContainsAsync(object obj, params Type[] types) =>
            (bool) await InvokeAsync(ContainsAsyncMethod.MakeGenericMethod(types), this, obj);

        private Task InternalInsertAsync(object obj, params Type[] types) =>
            InvokeAsync(InsertAsyncMethod.MakeGenericMethod(types), this, obj);

        private Task<object> InternalSelectAsync(object value, params Type[] types) =>
            InvokeAsync(SelectAsyncMethod.MakeGenericMethod(types), this, value);

        private static async Task<object> InvokeAsync(MethodInfo methodInfo, object obj, params object[] parameters)
        {
            var task = (Task) methodInfo.Invoke(obj, parameters);
            await task.ConfigureAwait(false);
            var resultProperty = task.GetType().GetProperty("Result");
            return resultProperty?.GetValue(task);
        }

        private static string GetPropertyNames(Type type) =>
            string.Join(", ", type.GetProperties().Select(e => e.Name));

        private static string GetPropertyParameterizedNamesInsert(Type type) =>
            string.Join(", ", type.GetProperties().Select(e => $"@{e.Name}"));

        private static string GetPropertyParameterizedNamesUpdate(Type type) =>
            string.Join(", ", type.GetProperties().Select(e => $"{e.Name} = @{e.Name}"));

        private static void AddPropertyValues<T>(SQLiteCommand cmd, T entity, Type entityType) => entityType
            .GetAllPublicProperties()
            .ForEach(prop =>
            {
                object value;
                if (IsDbObjectCollection(prop))
                {
                    var values = new List<string>();
                    var enumerable = (IEnumerable) prop.GetValue(entity);
                    if (enumerable != null)
                    {
                        foreach (var obj in enumerable)
                        {
                            values.Add(GetPropertyId(obj));
                        }
                    }

                    value = string.Join(EnumerableDelimiter, values);
                }
                else if (IsDbPrimitiveCollection(prop))
                {
                    var values = new List<string>();
                    var enumerable = (IEnumerable) prop.GetValue(entity);
                    if (enumerable != null)
                    {
                        foreach (var obj in enumerable)
                        {
                            values.Add(obj.ToString());
                        }
                    }

                    value = string.Join(EnumerableDelimiter, values);
                }
                else
                {
                    value = prop.GetValue(entity);
                }

                cmd.Parameters.AddWithValue($"@{prop.Name}", value);
            });

        private static string GetPropertyId(object entity) =>
            entity.GetType().GetProperty(Id)?.GetValue(entity).ToString();

        private static bool IsDateTime(PropertyInfo pi) => pi.PropertyType == typeof(DateTime);

        private static bool IsUShort(PropertyInfo pi) => pi.PropertyType == typeof(ushort);

        private static bool IsBool(PropertyInfo pi) => pi.PropertyType == typeof(bool);

        private static bool IsEnum(Type type) => type.IsEnum;

        private static bool IsTimeSpan(PropertyInfo pi) => pi.PropertyType == typeof(TimeSpan);

        private static bool IsPrimaryKey(PropertyInfo pi) =>
            pi.GetCustomAttribute(typeof(PrimaryKeyAttribute)) != null;

        private static bool IsDbObjectCollection(PropertyInfo pi) =>
            pi.GetCustomAttribute(typeof(DbObjectCollectionAttribute)) != null;

        private static bool IsDbPrimitiveCollection(PropertyInfo pi) =>
            pi.GetCustomAttribute(typeof(DbPrimitiveCollectionAttribute)) != null;

        private static bool IsUnique(PropertyInfo pi) =>
            pi.GetCustomAttribute(typeof(UniqueAttribute)) != null;

        public void Dispose()
        {
            _dbConnection.Close();
            _dbConnection.Dispose();
        }
    }

    internal static class SqlExtensions
    {
        internal static string ToSqlLiteral(this string s)
        {
            return $"'{s}'";
        }
    }
}