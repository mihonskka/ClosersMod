using ClosersIseubi.KeyWords;
using ClosersFramework.KeyWords;
using GameDataEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using I2.Loc;

namespace ClosersIseubi.Service
{
    public class ToolBox
    {
        public string GetDllPath()
        {
			return AppDomain.CurrentDomain.BaseDirectory;
		}
        public string c(string a)
        {
            return "ClosersMod." + a;
        }

        public string UpperNum(int a, bool force = false)
        {
            if(!force && LocalizationManager.CurrentLanguage == "English") return a.ToString();
            if (a > 10 || a < 0) return "我测你们吗";

            string list = "零壹贰叁肆伍陆柒捌玖拾";
            return list[a].ToString();
        }
        public int GetIntNum(string a)
        {
            switch (a)
            {
                case "零": return 0;
                case "一": return 1;
                case "壹": return 1;

                case "二": return 2;
                case "贰": return 2;

                case "三": return 3;
                case "叁": return 3;

                case "四": return 4;
                case "肆": return 4;

                case "五": return 5;
                case "伍": return 5;

                case "六": return 6;
                case "陆": return 6;

                case "七": return 7;
                case "柒": return 7;

                case "八": return 8;
                case "捌": return 8;

                case "九": return 9;
                case "玖": return 9;

                case "十": return 10;
                case "拾": return 10;
                default:
                    return 114514;
            }
        }
        public bool IsIraishin(string skillName)
        {
            switch (skillName)
            {
                case IseubiKeyWords.C_iseubi4:
                    return true;
                case IseubiKeyWords.C_iseubi8:
                    return true;
                case IseubiKeyWords.C_iseubi8_0:
                    return true;
                case IseubiKeyWords.C_iseubi9:
                    return true;
                case IseubiKeyWords.C_iseubi10:
                    return true;
                case IseubiKeyWords.C_iseubi13:
                    return true;
                default:
                    return false;
            }
        }
        public bool IsLightning(string skillName)
        {
            switch (skillName)
            {
                case IseubiKeyWords.C_iseubi1:
                    return true;
                case IseubiKeyWords.C_iseubi1_0:
                    return true;
                case IseubiKeyWords.C_iseubi3:
                    return true;
                case IseubiKeyWords.C_iseubi4:
                    return true;
                case IseubiKeyWords.C_iseubi11:
                    return true;
                case IseubiKeyWords.C_iseubi12:
                    return true;
                case IseubiKeyWords.C_iseubi12_0:
                    return true;
                case IseubiKeyWords.C_iseubi12_1:
                    return true;
                case IseubiKeyWords.C_iseubi5:
                    return true;
                default:
                    return false;
            }
        }
        public bool IsGravity(string skillName)
        {
            switch (skillName)
            {
                case IseubiKeyWords.C_iseubi0:
                    return true;
                case IseubiKeyWords.C_iseubi2:
                    return true;
                case IseubiKeyWords.C_iseubi14:
                    return true;
                case IseubiKeyWords.C_iseubi6:
                    return true;
                case IseubiKeyWords.C_iseubi6_0:
                    return true;
                case IseubiKeyWords.C_iseubi6_1:
                    return true;
                case IseubiKeyWords.C_iseubi7:
                    return true;
                default:
                    return false;
            }
        }
        public bool IsSpendChip(string skillName)
        {
            switch (skillName)
            {
                case IseubiKeyWords.C_iseubi1_0:
                    return true;
                case IseubiKeyWords.C_iseubi3:
                    return true;
                case IseubiKeyWords.C_iseubi4:
                    return true;
                case IseubiKeyWords.C_iseubi5:
                    return true;
                case IseubiKeyWords.C_iseubi7:
                    return true;
                case IseubiKeyWords.C_iseubi8_0:
                    return true;
                case IseubiKeyWords.C_iseubi11:
                    return true;
                case IseubiKeyWords.C_iseubi12:
                    return true;
                case IseubiKeyWords.C_iseubi14:
                    return true;
                default:
                    return false;
            }
        }
        public bool IsCreateChip(string skillName)
        {
            switch (skillName)
            {
                case IseubiKeyWords.C_iseubi0:
                    return true;
                case IseubiKeyWords.C_iseubi6_0:
                    return true;
                case IseubiKeyWords.C_iseubi8:
                    return true;
                case IseubiKeyWords.C_iseubi9:
                    return true;
                case IseubiKeyWords.C_iseubi13:
                    return true;
                case IseubiKeyWords.CL_iseubi0:
                    return true;
                case IseubiKeyWords.C_iseubi10:
                    return true;
                default:
                    return false;
            }
        }

        public T DeepClone<T>(T obj)
        {
            //如果是字符串或值类型则直接返回
            if (obj is string || obj.GetType().IsValueType) return obj;

            object retval = Activator.CreateInstance(obj.GetType());
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                try 
                { 
                    field.SetValue(retval, DeepClone(field.GetValue(obj)));
                }
                catch { }
            }
            return (T)retval;
        }
        public GDESkillData DeepClone(GDESkillData obj)
        {
            object retval = new GDESkillData(obj.Key);
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                try
                {
                    field.SetValue(retval, DeepClone(field.GetValue(obj)));
                }
                catch { }
            }
            return (GDESkillData)retval;
        }
    }
}
