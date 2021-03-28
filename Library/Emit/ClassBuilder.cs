using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Library.Emit
{
    public class ClassBuilder
    {
        private readonly ModuleBuilder _moduleBuilder;
        private readonly TypeBuilder _typeBuilder;
        private static object[] EmptyConstructor { get; } = { };

        public ClassBuilder(ClassBuilder classBuilder)
        {
            _moduleBuilder = classBuilder._moduleBuilder;
            _typeBuilder = _moduleBuilder.DefineType(
                $"{Guid.NewGuid()}_Type",
                TypeAttributes.Public
            );
        }

        public ClassBuilder() : this(Guid.NewGuid().ToString())
        {
        }

        public ClassBuilder(string name)
        {
            var aName = new AssemblyName(name);
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Run);
            _moduleBuilder = assemblyBuilder.DefineDynamicModule(aName.Name);

            _typeBuilder = _moduleBuilder.DefineType(
                $"{name}_Type",
                TypeAttributes.Public
            );
        }

        public void AddAllInterfaces(Type type)
        {
            AddInterface(type);
            foreach (var @interface in type.GetInterfaces())
            {
                AddInterface(@interface);
            }
        }

        public void AddInterface(Type type)
        {
            _typeBuilder.AddInterfaceImplementation(type);

            foreach (var prop in type.GetProperties())
            {
                AddPropertyFromInterface(prop);
            }
        }

        public void AddPropertyFromInterface(PropertyInfo propertyInfo)
        {
            var propertyType = propertyInfo.PropertyType;
            var propertyName = propertyInfo.Name;
            var fieldName = $"_{ToCamelCase(propertyName)}";

            var fieldBuilder = _typeBuilder.DefineField(fieldName, propertyType, FieldAttributes.Private);

            // The property set and get methods require a special set of attributes.
            const MethodAttributes getSetAttributes = MethodAttributes.Public | MethodAttributes.SpecialName |
                                                      MethodAttributes.Virtual | MethodAttributes.HideBySig;

            // Define the 'get' accessor method.
            var getMethodBuilder = _typeBuilder.DefineMethod($"get_{propertyName}", getSetAttributes,
                propertyType, Type.EmptyTypes);

            var propertyGetGenerator = getMethodBuilder.GetILGenerator();
            propertyGetGenerator.Emit(OpCodes.Ldarg_0);
            propertyGetGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
            propertyGetGenerator.Emit(OpCodes.Ret);

            // Define the 'set' accessor method.
            var setMethodBuilder =
                _typeBuilder.DefineMethod($"set_{propertyName}", getSetAttributes, null, new[] {propertyType});

            var propertySetGenerator = setMethodBuilder.GetILGenerator();
            propertySetGenerator.Emit(OpCodes.Ldarg_0);
            propertySetGenerator.Emit(OpCodes.Ldarg_1);
            propertySetGenerator.Emit(OpCodes.Stfld, fieldBuilder);
            propertySetGenerator.Emit(OpCodes.Ret);

            // Lastly, we must map the two methods created above to a PropertyBuilder and their corresponding behaviors, 'get' and 'set' respectively.
            var propertyBuilder =
                _typeBuilder.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);

            propertyBuilder.SetGetMethod(getMethodBuilder);
            propertyBuilder.SetSetMethod(setMethodBuilder);

            foreach (var attributeType in propertyInfo.GetCustomAttributes().Select(attribute => attribute.GetType()))
            {
                var defaultConstructor = attributeType.GetConstructor(Type.EmptyTypes);
                if (defaultConstructor == null)
                    continue;

                var attributeBuilder =
                    new CustomAttributeBuilder(attributeType.GetConstructor(Type.EmptyTypes), EmptyConstructor);

                propertyBuilder.SetCustomAttribute(attributeBuilder);
            }
        }

        public Type CreateType()
        {
            return _typeBuilder.CreateType();
        }

        private static string ToCamelCase(string s)
        {
            return char.ToLowerInvariant(s[0]) + s.Substring(1);
        }
    }
}