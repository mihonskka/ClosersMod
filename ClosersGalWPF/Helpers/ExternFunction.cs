using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClosersGalWPF.Helpers
{
    public static partial class ExternFunction
    {
        public static void AddNoRepeat<T>(this List<T> mylist, T Element)
        {
            if (mylist.Any(t => t.Equals(Element))) return;
            mylist.Add(Element);
        }

        public static bool IsInt(this string inString)
        {
            var regex = IntRegex();
            return regex.IsMatch(inString.Trim());
        }
        public static int? TailNumber(this string input)
        {
            var stack = new Stack<char>();
            for (var i = input.Length - 1; i >= 0; i--)
            {
                if (!char.IsNumber(input[i])) break;
                stack.Push(input[i]);
            }
            if (stack.Count <= 0) return null;
            var result = new string(stack.ToArray());
            return int.Parse(result);
        }

        public static object DeepClone(this object objSource)
        {
            //Get the type of source object and create a new instance of that type
            Type typeSource = objSource.GetType();
            object objTarget = Activator.CreateInstance(typeSource);
            //Get all the properties of source object type
            PropertyInfo[] propertyInfo = typeSource.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            //Assign all source property to taget object 's properties
            foreach (PropertyInfo property in propertyInfo)
            {
                //Check whether property can be written to
                if (!property.CanWrite) continue;
                //check whether property type is value type, enum or string type
                if (property.PropertyType.IsPrimitive || property.PropertyType.IsEnum || property.PropertyType == typeof(string))
                {
                    property.SetValue(objTarget, property.GetValue(objSource, null), null);
                }
                else if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    //Include List and Dictionary and......
                    if (property.PropertyType.IsGenericType)
                    {
                        var cloneObj = Activator.CreateInstance(property.PropertyType);

                        var addMethod = property.PropertyType.GetMethod("Add", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                        Debug.Assert(null != addMethod);

                        if (property.GetValue(objSource, null) is not IEnumerable currentValues)
                        {
                            property.SetValue(objTarget, null, null);
                        }
                        else
                        {
                            if (cloneObj is IDictionary)
                            {
                                cloneObj = cloneObj as IDictionary;
                                foreach (var currentValue in currentValues)
                                {
                                    var propInfoKey = currentValue.GetType().GetProperty("Key");
                                    var propInfoValue = currentValue.GetType().GetProperty("Value");
                                    if (propInfoKey != null && propInfoValue != null)
                                    {
                                        var keyValue = propInfoKey.GetValue(currentValue, null);
                                        var valueValue = propInfoValue.GetValue(currentValue, null);

                                        object finalKeyValue, finalValueValue;

                                        //Get finalKeyValue
                                        var currentKeyType = keyValue.GetType();
                                        if (currentKeyType.IsPrimitive || currentKeyType.IsEnum || currentKeyType == typeof(string))
                                        {
                                            finalKeyValue = keyValue;
                                        }
                                        else
                                        {
                                            //Reference type
                                            var copyObj = DeepClone(keyValue);
                                            finalKeyValue = copyObj;
                                        }

                                        //Get finalValueValue
                                        var currentValueType = valueValue.GetType();
                                        if (currentValueType.IsPrimitive || currentValueType.IsEnum || currentValueType == typeof(string))
                                        {
                                            finalValueValue = valueValue;
                                        }
                                        else
                                        {
                                            //Reference type
                                            var copyObj = DeepClone(valueValue);
                                            finalValueValue = copyObj;
                                        }

                                        addMethod.Invoke(cloneObj, [finalKeyValue, finalValueValue]);
                                    }
                                }
                                property.SetValue(objTarget, cloneObj, null);
                            }
                            //Common IList type
                            else
                            {
                                foreach (var currentValue in currentValues)
                                {
                                    var currentType = currentValue.GetType();
                                    if (currentType.IsPrimitive || currentType.IsEnum || currentType == typeof(string))
                                    {
                                        addMethod.Invoke(cloneObj, [currentValue]);
                                    }
                                    else
                                    {
                                        //Reference type
                                        var copyObj = DeepClone(currentValue);
                                        addMethod.Invoke(cloneObj, [copyObj]);
                                    }
                                }
                                property.SetValue(objTarget, cloneObj, null);
                            }
                        }
                    }
                    //Array type
                    else
                    {
                        if (property.GetValue(objSource, null) is not Array currentValues)
                        {
                            property.SetValue(objTarget, null, null);
                        }
                        else
                        {
                            var cloneObj = Activator.CreateInstance(property.PropertyType, currentValues.Length) as Array;
                            var arrayList = new ArrayList();
                            for (var i = 0; i < currentValues.Length; i++)
                            {
                                var currentType = currentValues.GetValue(i).GetType();
                                if (currentType.IsPrimitive || currentType.IsEnum || currentType == typeof(string))
                                {
                                    arrayList.Add(currentValues.GetValue(i));
                                }
                                else
                                {
                                    //Reference type
                                    var copyObj = DeepClone(currentValues.GetValue(i));
                                    arrayList.Add(copyObj);
                                }
                            }
                            arrayList.CopyTo(cloneObj, 0);
                            property.SetValue(objTarget, cloneObj, null);
                        }
                    }
                }
                //else property type is object/complex types, so need to recursively call this method until the end of the tree is reached
                else
                {
                    object objPropertyValue = property.GetValue(objSource, null);
                    if (objPropertyValue == null)
                    {
                        property.SetValue(objTarget, null, null);
                    }
                    else if (objPropertyValue.GetType().IsPrimitive || objPropertyValue.GetType().IsEnum || objPropertyValue.GetType() == typeof(string))
                    {
                        property.SetValue(objTarget, objPropertyValue, null);
                    }
                    else
                    {
                        property.SetValue(objTarget, DeepClone(objPropertyValue), null);
                    }
                }
            }
            return objTarget;
        }

        [GeneratedRegex("^[0-9]*[1-9][0-9]*$")]
        private static partial Regex IntRegex();
    }
}
