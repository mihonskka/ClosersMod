using ClosersFramework;
using ClosersFramework.Models;
using ClosersFramework.Service;
using ClosersFramework.Service.CodeManager;
using ClosersTina.KeyWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Services
{
    public static class ExpService
    {
        public static CustomValue getExp()
        {
            try
            {
                if (!TinaService.CheckPresence(false)) return new RecordInSave() { Name = TinaKeyWords.tinaExp, Obj = 0 };

                //clog.w($"获取EXP");
                var rv = PlayData.TSavedata?.CustomValues?.FirstOrDefault(t => t.Name == TinaKeyWords.tinaExp);
                if (rv == null)
                {
                    rv = new RecordInSave()
                    {
                        Name = TinaKeyWords.tinaExp,
                        Obj = 0
                    };
                    PlayData.TSavedata?.CustomValues?.Add(rv);
                }
                //clog.w($"当前EXP-{(int)rv.Obj}");
                return rv;
            }
            catch(Exception ex) 
            {
                clog.tw("缇娜战斗场次获取中出错，报错信息为：" + ex.Message);
                return null;
            } 
        }

        public static void setExp(CustomValue value)
        {
            try
            {
                var dst = PlayData.TSavedata.CustomValues.FirstOrDefault(t => t.Name == TinaKeyWords.tinaExp);
                if (dst != null)
                    dst.Obj = value.Obj;
                else
                    PlayData.TSavedata.CustomValues.Add(new RecordInSave() { Name = TinaKeyWords.tinaExp, Obj = value.Obj });
            }
            catch (Exception ex)
            {
                clog.tw("缇娜战斗场次写入中出错，报错信息为：" + ex.Message);
            }
        }

        public static void AddExp(int num = 1)
        {
            var cv = getExp();
            cv.Obj = (int)cv.Obj + num;
            setExp(cv);
        }

        public static void PassiveDescCheckOutBattle()
        {
            if (!TinaService.CheckPresence(false)) return;

            var c = TinaService.FindTinaInInvest();
            c.PassiveDes = c.PassiveDes.Replace("&exp", ((int)getExp().Obj).ToString());
        }

        public static void PassiveDescCheckOutBattle(ref Character c)
        {
            if (!TinaService.CheckPresence(false)) return;
            c.PassiveDes = c.PassiveDes.Replace("&exp", ((int)getExp().Obj).ToString());
        }
        /*
        [NoReference]
        public static string PassiveDescCheck()
        {
            //if (ClosersModPlugin.Allin) return PassiveDesc.TransToLocalization.Replace("&exp", getExp().Obj.ToString());
            //else return PassiveDesc.TransToLocalization.Replace("&exp", getExp().Obj.ToString());
            return PassiveDesc.TransToLocalization.Replace("&a", getExp().Obj.ToString());
        }
        [NoReference]
        public static TranslationItem PassiveDesc { get; } = new TranslationItem()
        {
            
            SimplifiedChinese = "【战前准备】：出场时等级为5级，在通过【白色墓地】前，每抵达一个区域都将降低1级等级。\n【弹幕】：自身每次攻击至多造成攻击力33%的伤害，若伤害溢出，则在伤害结算完毕后以溢出的伤害进行一次额外的攻击。\n【补给】：自身每进行18次攻击或使用技能后，随机获得一张【手榴弹】或【紧急闪避】；30次，随机获得一张【我想静静】或【急救包】；48次，随机获得一张【三连发】或拥有的露西技能(不包括血色迷雾和露西诅咒技能)；\n【防火墙】：免疫【绝对服从】、【精神错乱】、【激怒】。\n【升温】：每当自身使用技能时，都会为自身施加【过热】。\n【磨损】：每完成一次战斗，都会为自身施加【关节磨损】。\n当前已完成 &a 场战斗。",
            TraditionalChinese = "",
            English = "",
            Japanese = "",
            Korean = ""
        };*/
    }
}
