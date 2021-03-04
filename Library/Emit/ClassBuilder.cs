using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Library.Emit
{
    public class ClassBuilder
    {
        private readonly ModuleBuilder _moduleBuilder;
        private readonly TypeBuilder _typeBuilder;

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

        public void AddInterface(Type type)
        {
            _typeBuilder.AddInterfaceImplementation(type);

            foreach (var prop in type.GetProperties())
            {
                AddProperty(prop.Name, prop.PropertyType.AssemblyQualifiedName);
            }
        }

        public void AddProperty(string name, string typeName)
        {
            var propertyType = Type.GetType(typeName);
            if (propertyType == null)
                propertyType = _typeBuilder.Assembly.GetType(typeName);

            string propertyName = name;
            string fieldName = $"_{ToCamelCase(propertyName)}";

            FieldBuilder fieldBuilder = _typeBuilder.DefineField(fieldName, propertyType, FieldAttributes.Private);

            // The property set and get methods require a special set of attributes.
            MethodAttributes getSetAttributes = MethodAttributes.Public | MethodAttributes.SpecialName |
                                                MethodAttributes.Virtual | MethodAttributes.HideBySig;

            // Define the 'get' accessor method.
            MethodBuilder getMethodBuilder = _typeBuilder.DefineMethod($"get_{propertyName}", getSetAttributes,
                propertyType, Type.EmptyTypes);

            ILGenerator propertyGetGenerator = getMethodBuilder.GetILGenerator();
            propertyGetGenerator.Emit(OpCodes.Ldarg_0);
            propertyGetGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
            propertyGetGenerator.Emit(OpCodes.Ret);

            // Define the 'set' accessor method.
            MethodBuilder setMethodBuilder =
                _typeBuilder.DefineMethod($"set_{propertyName}", getSetAttributes, null, new[] { propertyType });

            ILGenerator propertySetGenerator = setMethodBuilder.GetILGenerator();
            propertySetGenerator.Emit(OpCodes.Ldarg_0);
            propertySetGenerator.Emit(OpCodes.Ldarg_1);
            propertySetGenerator.Emit(OpCodes.Stfld, fieldBuilder);
            propertySetGenerator.Emit(OpCodes.Ret);

            // Lastly, we must map the two methods created above to a PropertyBuilder and their corresponding behaviors, 'get' and 'set' respectively.
            PropertyBuilder propertyBuilder =
                _typeBuilder.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);

            propertyBuilder.SetGetMethod(getMethodBuilder);
            propertyBuilder.SetSetMethod(setMethodBuilder);
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