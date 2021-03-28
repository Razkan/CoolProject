using System;
using System.Collections;
using System.Collections.Generic;

namespace Library.Emit
{
    public class InterfaceBuilder
    {
        private static Dictionary<Type, Type> TypeCache { get; } = new Dictionary<Type, Type>();
        private Type StringType { get; } = typeof(string);
        private Type IsEnumerable { get; } = typeof(IEnumerable);

        private object Values { get; set; }

        public static InterfaceBuilder New()
        {
            return new InterfaceBuilder();
        }

        public InterfaceBuilder AddValues(object values)
        {
            Values = values;
            return this;
        }

        public T Build<T>()
        {
            return Values == null
                ? (T) CreateInstanceWithoutValues(typeof(T))
                : (T) CreateInstanceWithValue(Values, typeof(T), new ClassBuilder());
        }

        public object Build(Type type)
        {
            return Values == null
                ? CreateInstanceWithoutValues(type)
                : CreateInstanceWithValue(Values, type, new ClassBuilder());
        }

        private static object CreateInstanceWithoutValues(Type interfaceType)
        {
            if (!TypeCache.TryGetValue(interfaceType, out var type))
            {
                var classBuilder = new ClassBuilder();
                classBuilder.AddAllInterfaces(interfaceType);
                type = classBuilder.CreateType();
                TypeCache.Add(interfaceType, type);
            }

            return Activator.CreateInstance(type);
        }

        private object CreateInstanceWithValue(object valueObject, Type interfaceType, ClassBuilder classBuilder)
        {
            object instance;
            if (IsEnumerable.IsAssignableFrom(interfaceType))
            {
                var arguments = interfaceType.GenericTypeArguments;
                if (arguments.Length > 1)
                    throw new Exception("Only handling of one generic array type allowed");

                var listType = typeof(List<>);
                var constructedListType = listType.MakeGenericType(arguments);
                instance = Activator.CreateInstance(constructedListType);
            }
            else
            {
                if (!TypeCache.TryGetValue(interfaceType, out var type))
                {
                    classBuilder.AddAllInterfaces(interfaceType);
                    type = classBuilder.CreateType();
                    TypeCache.Add(interfaceType, type);
                }

                instance = Activator.CreateInstance(type);
            }

            var instanceType = instance.GetType();
            var valueType = valueObject.GetType();
            foreach (var propertyInfo in instanceType.GetProperties())
            {
                var valueProperty = valueType.GetProperty(propertyInfo.Name);
                if (valueProperty != null)
                {
                    var propertyType = propertyInfo.PropertyType;
                    if (propertyType.IsPrimitive || propertyType.IsEnum || propertyType == StringType)
                    {
                        var value = valueProperty.GetValue(valueObject);
                        propertyInfo.SetValue(instance, value);
                    }
                    else if (IsEnumerable.IsAssignableFrom(propertyType))
                    {
                        if (propertyType.GenericTypeArguments.Length > 1)
                            throw new Exception("Only handling of one generic array type allowed");

                        var listType = typeof(List<>);
                        var constructedListType = listType.MakeGenericType(propertyType.GenericTypeArguments);
                        var list = (IList) Activator.CreateInstance(constructedListType);

                        var values = valueProperty.GetValue(valueObject);
                        var elementType = propertyType.GenericTypeArguments[0];
                        foreach (var ele in (IEnumerable) values)
                        {
                            if (elementType.IsPrimitive || elementType.IsEnum || elementType == StringType)
                            {
                                list.Add(ele);
                            }
                            else
                            {
                                var obj = CreateInstanceWithValue(ele, propertyType.GenericTypeArguments[0],
                                    new ClassBuilder(classBuilder));
                                list.Add(obj);
                            }
                        }

                        propertyInfo.SetValue(instance, list);
                    }
                    else
                    {
                        var value = valueProperty.GetValue(valueObject);
                        var obj = CreateInstanceWithValue(value, propertyType, new ClassBuilder(classBuilder));
                        propertyInfo.SetValue(instance, obj);
                    }
                }
            }

            return instance;
        }
    }
}