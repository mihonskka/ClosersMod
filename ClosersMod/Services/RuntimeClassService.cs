using ClosersFramework.Service.CodeManager;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Service
{
    #region 生成自定义动态类
    [NoReference]
    public static class RuntimeClassService
    {
        /// <summary>
        /// 创建属性
        /// </summary>
        /// <param name="propertyType">属性基础类型(byte/int/string/float/double/bool等)和List基础类型</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="propertyDefaultValue">属性初始值</param>
        /// <returns></returns>
        static string PropertyString(string propertyType, string propertyName, string propertyDefaultValue)
        {
            StringBuilder sbproperty = new StringBuilder();
            sbproperty.Append(" private " + propertyType + "  _" + propertyName + "   =  " + propertyDefaultValue + ";\n");
            sbproperty.Append(" public " + propertyType + " " + propertyName + "\n");
            sbproperty.Append(" {\n");
            sbproperty.Append(" get{   return   _" + propertyName + ";}   \n");
            sbproperty.Append(" set{   _" + propertyName + "   =   value;   }\n");
            sbproperty.Append(" }\n");
            return sbproperty.ToString();
        }

        static string OverrideReadonlyPropertyString(string propertyType, string propertyName, string propertyDefaultValue)
        {
            return $" public override {propertyType} {propertyName} => {propertyDefaultValue};\n";
        }


        /// <summary>
        /// 创建动态类
        /// </summary>
        /// <param name="className">动态类名字</param>
        /// <param name="propertyList">属性列表</param>
        /// <returns></returns>
        public static Assembly Newassembly(string className, string inhertClassName, List<List<string>> propertyList, List<List<string>> overrideReadonlyPropertyList = null, string extraProperty = "")
        {
            //创建编译器实例。   
            CSharpCodeProvider provider = new CSharpCodeProvider();
            //设置编译参数。   
            CompilerParameters paras = new CompilerParameters();
            //编译器生成的临时文件，参数2为true，放置为当前文件夹下，false则放入windows的temp文件夹下
            paras.TempFiles = new TempFileCollection(".", false);
            //如果为true，则生成exe文件，false会生成临时dll文件
            paras.GenerateExecutable = false;
            paras.GenerateInMemory = true;

            //创建动态代码。   
            StringBuilder classsource = new StringBuilder();
            //float、bool等类型需要引用System
            classsource.Append("using System;\n");
            //List需要引用System.Collections.Generic
            classsource.Append("using System.Collections.Generic;\n");
            if(string.IsNullOrWhiteSpace(inhertClassName)) classsource.Append($"public class {className}\n");
            else classsource.Append($"public class {className} : {inhertClassName}\n");
            classsource.Append("{\n");

            try
            {
                //创建属性。   
                for (int i = 0; i < propertyList.Count; i++)
                {
                    classsource.Append(PropertyString(propertyList[i][0], propertyList[i][1], propertyList[i][2]));
                }
                
                //创建属性。   
                for (int i = 0; i < overrideReadonlyPropertyList?.Count; i++)
                {
                    classsource.Append(PropertyString(overrideReadonlyPropertyList[i][0], overrideReadonlyPropertyList[i][1], overrideReadonlyPropertyList[i][2]));
                }

                classsource.Append(extraProperty);

                classsource.Append("}");
                System.Diagnostics.Debug.WriteLine(classsource.ToString());
                //编译代码。   
                CompilerResults result = provider.CompileAssemblyFromSource(paras, classsource.ToString());
                //获取编译后的程序集。   
                Assembly assembly = result.CompiledAssembly;

                return assembly;
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.WriteLine(ex.Message);
                clog.w("动态创建类失败："+ex.Message);
                return null;
            }

        }
        /// <summary>
        /// 给属性赋值
        /// </summary>
        /// <param name="objclass">先进行dynamic objclass = assembly.CreateInstance(className)，得到的objclass</param>
        /// <param name="propertyname">属性名称</param>
        /// <param name="value">属性值</param>
        public static void ReflectionSetValue(object objclass, string propertyname, object value)
        {
            PropertyInfo[] infos = objclass.GetType().GetProperties();

            try
            {
                foreach (PropertyInfo info in infos)
                {
                    if (info.Name == propertyname && info.CanWrite)
                    {
                        info.SetValue(objclass, value, null);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// 得到属性值
        /// </summary>
        /// <param name="objclass">先进行dynamic objclass = assembly.CreateInstance(className)，得到的objclass</param>
        /// <param name="propertyname">属性名称</param>
        /// <returns>属性值，是object类型，使用时记得转换</returns>
        public static object ReflectionGetValue(object objclass, string propertyname)
        {
            object result = null;
            PropertyInfo[] infos = objclass.GetType().GetProperties();
            try
            {
                foreach (PropertyInfo info in infos)
                {
                    if (info.Name == propertyname && info.CanRead)
                    {
                        System.Console.WriteLine(info.GetValue(objclass, null));
                        result = info.GetValue(objclass, null);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                result = null;
            }

            return result;
        }



    }
    #endregion
}
