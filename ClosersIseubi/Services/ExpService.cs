using ClosersIseubi.Isouryoku;
using ClosersIseubi.KeyWords;
using ClosersFramework;
using ClosersFramework.Filter;
using ClosersFramework.KeyWords;
using ClosersFramework.Models;
using ClosersFramework.PluginUnits;
using ClosersFramework.Services;
using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Services.Enum;
using ClosersFramework.Service.CodeManager;

namespace ClosersIseubi.Service
{
    public static class ExpService
    {


        public static CustomValue getExp()
        {
            if (!IseubiService.CheckPresence(false)) return new RecordInSave() { Name = IseubiKeyWords.iseubiEXP, Obj = 0 };

            //clog.w($"获取EXP");
            var rv = PlayData.TSavedata.CustomValues.FirstOrDefault(t => t.Name == IseubiKeyWords.iseubiEXP);
            if (rv == null)
            {
                rv = new RecordInSave()
                {
                    Name = IseubiKeyWords.iseubiEXP,
                    Obj = 0
                };
                PlayData.TSavedata.CustomValues.Add(rv);
            }
            //clog.w($"当前EXP-{(int)rv.Obj}");
            return rv;
        }

        public static CustomValue getSect()
        {
            if (!IseubiService.CheckPresence(false)) return new RecordInSave() { Name = IseubiKeyWords.iseubiSect, Obj = CardType.Pluralism };

            //clog.w($"获取当前流派");
            var rv = PlayData.TSavedata.CustomValues.FirstOrDefault(t => t.Name == IseubiKeyWords.iseubiSect);
            if (rv == null)
            {
                rv = new RecordInSave()
                {
                    Name = IseubiKeyWords.iseubiSect,
                    Obj = CardType.Pluralism
                };
                PlayData.TSavedata.CustomValues.Add(rv);
            }
            //clog.w($"当前流派-{(CardType)rv.Obj}");
            return rv;
        }

        public static bool AddExp(int i = 1)
        {
            try
            {
                clog.iw("准备增加EXP");
                if (!IseubiService.CheckPresence(false)) return false;

                int exp = (int)getExp().Obj;
                PlayData.TSavedata.CustomValues.FirstOrDefault(t => t.Name == IseubiKeyWords.iseubiEXP).Obj = exp + i;
                clog.iw("EXP增加！");

                //AfterAddExpMount();
                #region 任务手册模块
                var mypluginP3 = PluginUnitService.GetPlugin(PluginKeyWords.TaskHandbook) as TaskHandbookPlugin;
                mypluginP3.Init(new TaskHandBookConfig()
                {
                    PageList=new List<TaskHandBookPage>
                    {
                        new TaskHandBookPage()
                        {
                            TaskName = TaskHandBookKeyWords.PluLV3IScroll,
                            EventId = IseubiEventKeys.PluLV3IScroll,
                            InvokeAction = () =>
                            {
                                new Pluralism().LV3_Immediate();
                            }
                        },
                        new TaskHandBookPage()
                        {
                            TaskName = TaskHandBookKeyWords.PluLV1ISkill,
                            EventId = IseubiEventKeys.PluLV1ISkill,
                            InvokeAction = () =>
                            {
                                new Pluralism().LV0_Immediate();
                            }
                        }
                    }
                });
                clog.iw("插件模式-调用");
                mypluginP3.Invoke();
                #endregion
                return true;
            }
            catch
            {
                return false;
            }
        }

        [NoReference]
        public delegate void AfterAddExpDelegate();

        [NoReference]
        public static AfterAddExpDelegate AfterAddExpMount { get; set; }

        public static bool setSect(CardType ct,bool needCheckPresence=false)
        {
            try
            {
                if (needCheckPresence && !IseubiService.CheckPresence(false)) return false;
                getSect();
                PlayData.TSavedata.CustomValues.FirstOrDefault(t=>t.Name== IseubiKeyWords.iseubiSect).Obj = ct;
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public static CardType CheckSect()
        {
            if (GlobalSetting.Allin)
            {
                clog.iw("流派检查-火力全开模式");
                setSect(CardType.Closers);
                return CardType.Closers;
            }clog.iw("流派检查-非火力全开模式");
            if (!IseubiService.CheckPresence(false)) return CardType.Pluralism;

            var rv = CardType.Pluralism;
            var rareSkills = IseubiService.FindIseubiInInvest().GetBattleChar?.Skills?.Where(t => t.MySkill.Rare);
            //clog.w($"流派检测-rsCount:{rareSkills.Count()}");
            if (rareSkills == null || !rareSkills.Any() || rareSkills.Count() > 1) { }
            else
            {
                var rs = rareSkills?.FirstOrDefault()?.MySkill?.KeyID;
                //clog.w($"流派检测-rs:{rs}");
                switch (rs)
                {
                    case IseubiKeyWords.C_iseubi2:
                        rv = CardType.Gravity;
                        break;
                    case IseubiKeyWords.C_iseubi13:
                        rv = CardType.Teleport;
                        break;
                    case IseubiKeyWords.C_iseubi12:
                        rv = CardType.Electrical;
                        break;
                    default:
                        break;
                }
            }
            setSect(rv);
            return rv;
        }

        [NoReference]
        public static void RollBackPassiveDesc(ref Character c)
        {
            c.PassiveDes = PassiveDesc.TransToLocalization;
        }
        public static string PassiveDescCheck()
        {
            if(GlobalSetting.Allin) return PassiveDesc.TransToLocalization.Replace("&sect", getSect().Obj.ToString()).Replace("&exp", getExp().Obj.ToString()).Replace("<b>Pluralism</b>", "<b>" + "<b>Closers</b>" + "</b>").Replace("<b>0</b>", "<b>" + getExp().Obj.ToString() + "</b>");
            else return PassiveDesc.TransToLocalization.Replace("&sect", getSect().Obj.ToString()).Replace("&exp", getExp().Obj.ToString()).Replace("<b>Pluralism</b>", "<b>" + getSect().Obj.ToString() + "</b>").Replace("<b>0</b>", "<b>" + getExp().Obj.ToString() + "</b>");
        }
        
        public static void PassiveDescCheckOutBattle() 
        {
            if (!IseubiService.CheckPresence(false)) return;

            var mySect = CheckSect();
            var c = IseubiService.FindIseubiInInvest();
            c.PassiveDes = PassiveDescCheck() + PassiveDescriptionService.GetMyPassiveDescExtendeds((int)getExp().Obj, mySect).Replace("&lvd", ReplaceTeleportV5PassiveDesc(c).ToString());
        }

        public static void PassiveDescCheckOutBattle(ref Character c) 
        {
            if (!IseubiService.CheckPresence(false)) return;

            //clog.w("战斗外刷新被动能力描述。");
            var mySect = CheckSect();
            c.PassiveDes = PassiveDescCheck() + PassiveDescriptionService.GetMyPassiveDescExtendeds((int)getExp().Obj, mySect).Replace("&lvd", ReplaceTeleportV5PassiveDesc(c).ToString());
        }

        static decimal ReplaceTeleportV5PassiveDesc(Character c) => (decimal)((c.Passive as P_Iseubi).DodgeCount * 2);

        public static TranslationItem PassiveDesc => new TranslationItem()
        {
            
            SimplifiedChinese= "其他角色的技能出手时，碎片+1。\n使用<b>魔法碎片生成技能</b>或<b>魔法碎片消耗技能</b>时，获得暴击率提升5%，暴击伤害增加8%的增益（持续3回合，最多叠加5层）\n李瑟钰会根据拥有的稀有技能切换流派，并且会随着调查的进行而逐渐成长。\n当前流派为：<b>&sect</b>\n当前已完成<b>&exp</b>场战斗。",
            TraditionalChinese= "其他角色的技能出手時，碎片+1。\n使用<b>魔法碎片生成技能</b>或<b>魔法碎片消耗技能</b>時，獲得暴擊率提升5%，暴擊傷害增加8%的增益（持續3回合，最多疊加5層）\n李瑟鈺會根據擁有的稀有技能切換流派，並且會隨著調查的進行而逐漸成長。\n當前流派為：<b>&sect</b>\n當前已完成<b>&exp</b>場戰鬥。",
            English= "When using skills from other characters，add 1 bit.\nWhen casting <b>Magic Chip costing skills</b> or <b>Magic Chip receiving skills</b>, critical hit chance+5%, critical hit damage+8%(3 turns remaining, stacking up to 5)\nSylvi can base on rare skill to switch sect, and gradually strengthen the passive during the investigation.\nSect: <b>&sect</b>\nThe number of combat: <b>&exp</b>",
            Japanese= "他のキャラクターのスキルが手に入ると、ビット+1。\n<b>魔ビット生成スキル</b>または<b>ビット消費スキル</b>を使用すると、致命的な一撃率が5%上昇し、致命的な一撃ダメージが8%増加するゲインを獲得する（3ターン継続、最大5層重ね）\nミコトは持っている珍しい技によって流派を切り替え、調査が進むにつれて成長していく。\n現在の流派:<b>&sect</b>\n現在、<b>&exp</b>フィールドの戦闘が完了しています。",
            Korean= "다른 캐릭터의 스킬 사용 시 비트+1.\n<b>비트 생성 스킬</b> 또는 <b> 비트 소모 스킬</b>을 낼 때  치명타는 5% 증가하며 치명타 피해는 8% 증가합니다(연속 3턴간, 최대 5중첩).\r\n이슬비는 가지고 있는 희귀 스킬에 따라 파별을 전환하며 조사가 수행됨에 따라 점차 성장합니다.\r\n현재 파별：<b>&sect</b>\r\n현재 <b>&exp</b>회 전투를 완료."
        };
    }
}
