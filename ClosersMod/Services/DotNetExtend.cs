using ClosersFramework;
using ClosersFramework.Service.CodeManager;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

namespace ClosersFramework.Services
{
    public static partial class DotNetExtend
    {
        public static T NextRandom<T>(this IEnumerable<T> mylist) => mylist.ElementAt(new Random().Next(mylist.Count()));

        public static string Signal2Real(this string desc)
        {
            desc = desc.Replace("&sect", "Pluralism").Replace("&exp", "0");
            if (GlobalSetting.Allin)
                desc = desc.Replace("<b>Pluralism</b>", "<b>Closers</b>");
            return desc;
        }

        public static string Real2Signal(this string desc)
        {
            if (GlobalSetting.Allin)
                desc = desc.Replace("<b>Closers</b>", "<b>Pluralism</b>");
            desc = desc.Replace("Pluralism", "&sect").Replace("<b>0</b>", "<b>&exp</b>");
            return desc;
        }

        public static bool IsAdjacentVector(this Vector3 src, Vector3? dst)
        {
            if (!dst.HasValue) return false;
            var x = src.x - dst.Value.x;
            var y = src.y - dst.Value.y;
            var z = src.z - dst.Value.z;
            return x <= 1 && y <= 1 && z <= 1;
        }

        public static string PrintVector(this Vector3 src) => $"x:{src.x} y:{src.y} z:{src.z}";
        public static string PrintQuaternion(this Quaternion src) => $"x:{src.x} y:{src.y} z:{src.z} w:{src.w}";

        public static bool IsInt(this string inString) => new Regex("^[0-9]*[1-9][0-9]*$").IsMatch(inString.Trim());
        public static object DeepClone(object objSource)
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

                        if (!(property.GetValue(objSource, null) is IEnumerable currentValues))
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

                                        addMethod.Invoke(cloneObj, new[] { finalKeyValue, finalValueValue });
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
                                        addMethod.Invoke(cloneObj, new[] { currentValue });
                                    }
                                    else
                                    {
                                        //Reference type
                                        var copyObj = DeepClone(currentValue);
                                        addMethod.Invoke(cloneObj, new[] { copyObj });
                                    }
                                }
                                property.SetValue(objTarget, cloneObj, null);
                            }
                        }
                    }
                    //Array type
                    else
                    {
                        if (!(property.GetValue(objSource, null) is Array currentValues))
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

        public static IEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> list, Func<T, TKey> keySelector, bool reverse) => (reverse) ? list.OrderByDescending(keySelector) : list.OrderBy(keySelector);

        public static (IEnumerable<T1>, IEnumerable<T2>) DeZip<T1, T2>(this IEnumerable<(T1, T2)> list)
        {
            var rv0 = new List<T1>();
            var rv1 = new List<T2>();
            foreach (var i in list)
            {
                rv0.Add(i.Item1);
                rv1.Add(i.Item2);
            }
            return (rv0, rv1);
        }
        public static (IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>) DeZip<T1, T2, T3>(this IEnumerable<(T1, T2, T3)> list)
        {
            var rv0 = new List<T1>();
            var rv1 = new List<T2>();
            var rv2 = new List<T3>();
            foreach (var i in list)
            {
                rv0.Add(i.Item1);
                rv1.Add(i.Item2);
                rv2.Add(i.Item3);
            }
            return (rv0, rv1, rv2);
        }
        public enum LimitType { max, min }
        public static int Limit(this int a, int min, int max) => (a < min) ? min : (a > max) ? max : a;
        public static int Limit(this int a, int limit, LimitType type) => ((type == LimitType.max && a > limit) || (type == LimitType.min && a < limit)) ? limit : a;
        public static float Limit(this float a, float min, float max) => (a < min) ? min : (a > max) ? max : a;
        public static float Limit(this float a, float limit, LimitType type) => ((type == LimitType.max && a > limit) || (type == LimitType.min && a < limit)) ? limit : a;
        public static double Limit(this double a, double min, double max) => (a < min) ? min : (a > max) ? max : a;
        public static double Limit(this double a, double limit, LimitType type) => ((type == LimitType.max && a > limit) || (type == LimitType.min && a < limit)) ? limit : a;
        public static decimal Limit(this decimal a, decimal min, decimal max) => (a < min) ? min : (a > max) ? max : a;
        public static decimal Limit(this decimal a, decimal limit, LimitType type) => ((type == LimitType.max && a > limit) || (type == LimitType.min && a < limit)) ? limit : a;

        public static string ToJson(this object obj) => (obj == null) ? "" : JsonConvert.SerializeObject(obj);
        public static T ToObject<T>(this string str)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(str);
            }
            catch (Exception ex)
            {
                return default;
            }
        }
    }
}
