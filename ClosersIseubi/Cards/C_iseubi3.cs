using ClosersIseubi.Isouryoku;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Models;
using ClosersIseubi.Service;
using ClosersFramework.Models;
using ClosersFramework.Services;
using GameDataEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ClosersFramework.Services.Enum;
using I2.Loc;
using ToolBox = ClosersIseubi.Service.ToolBox;

namespace ClosersIseubi.Cards
{
    public class C_iseubi3 : IseubiBaseCard, IP_DamageChange
    {
        public C_iseubi3() : base(-1, true, false, CardType.Electrical)
        {
        }

        public override void Init()
        {
            base.Init();
            new Electrical().LV3_ES(this.MySkill, this.MySkill.AllExtendeds.Count(t => t.Name == IseubiKeyWords.rlc) + 1);
        }

        public override string ClosersDesc(string desc)
        {
            int count = this.MySkill.AllExtendeds.Count(t => t.Name == IseubiKeyWords.rlc);
            desc = desc.Replace("&a", ((int)Misc.PerToNum(this.BChar.GetStat.atk, 15f) * count).ToString());
            return base.ClosersDesc(desc);
        }

        //public override string ClosersExtendName(string name) => base.ClosersExtendName(name) + " " + (LocalizationManager.CurrentLanguage != "English" ? "·" : string.Empty) + toolbox.UpperZHNum(this.MySkill.AllExtendeds.Count(t => t.Name == IseubiKeyWords.rlc) + 1) + cont.TransToLocalization;

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            clog.iw("이슬비：释放电磁枪");
            if (this.BChar?.BattleInfo?.EnemyList == null || this.BChar.BattleInfo.EnemyList.Count == 0) return;
            clog.iw("이슬비：准备生成电磁枪连击");
            base.SkillUseSingle(SkillD, Targets);
            int count = SkillD.AllExtendeds.Count(t => t.Name == IseubiKeyWords.rlc) + 1;
            //count = SkillD.AllExtendeds.Count(t => t.Name.StartsWith("RLC"));
            //SkillD.AllExtendeds.ForEach(t => clog.iw($"电磁枪ext-sd-{t.Name}"));
            //SkillD.MySkill.SkillExtended.ForEach(t => clog.iw($"电磁枪ext-ms-{t}"));
            //if (SkillD.MySkill.Name.EndsWith("连击")) count = toolbox.getIntNum(SkillD.MySkill.Name[8].ToString());
            if (count < 4)
            {
                if ((this.BChar.Buffs.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.bc)?.StackNum ?? 0) >= 1)
                {
                    clog.iw("이슬비：正在生成电磁枪连击");
                    var skill = new Skill();
                    skill.Init(new GDESkillData(IseubiKeyWords.C_iseubi3), this.MySkill.Master, this.BChar.MyTeam);

                    skill.ExtendedAdd(DataToExtended(new GDESkillExtendedData(IseubiKeyWords.CS_iseubi0)));
                    skill.ExtendedAdd(DataToExtended(new GDESkillExtendedData(IseubiKeyWords.Ext_RailgunLiteCounter)));

                    skill.NotCount = true;
                    skill.isExcept = true;
                    skill.UsedApNum = 0;
                    skill.MySkill.Name = $"{skillname.TransToLocalization}·{toolbox.UpperNum(count+1)}{cont.TransToLocalization}";
                    skill = EnforceAddService.AddEnforce(this.MySkill, skill);
                    skill.AutoDelete = 1;
                    skill.MySkill.Target = new GDEs_targettypeData("enemy");
                    new Electrical().LV3_ES(skill, count);
                    var skill0 = skill.CloneSkill(true, this.BChar, null, false);
                    this.BChar.MyTeam.Add(skill0, false);
                    clog.iw("이슬비：生成完毕");
                    skill.MySkill.Name = $"{skillname.TransToLocalization}";
                }
            }
            else
            {
                IseubiSoundService.Sound(IseubiKeyWords.V_RailgunLite, this);
            }
        }
        TranslationItem skillname = new TranslationItem()
        {
            
            SimplifiedChinese = "电磁·电磁枪",
            TraditionalChinese = "電磁·電磁槍",
            English = "[E]Thunder Strike",
            Japanese = "雷遁·レールガン",
            Korean = "[E]레이건"
        };
        TranslationItem cont = new TranslationItem()
        {
            
            SimplifiedChinese = "连击",
            TraditionalChinese = "連擊",
            English = " times",
            Japanese = "連段",
            Korean = " 연타"
        };

        public override int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            Damage = base.DamageChange(SkillD, Target, Damage, ref Cri, View);
            if (SkillD.MySkill.KeyID != IseubiKeyWords.C_iseubi3 || !(Target is BattleEnemy)) return Damage;
            return Damage += BattleChar.CalculationResult(this.BChar.Info.get_stat.atk, 15, 0) * this.MySkill.AllExtendeds.Count(t => t.Name == IseubiKeyWords.rlc);
        }

        //public int count { get; set; } = 1;

        ToolBox toolbox = new ToolBox();
    }
    public class Ext_RailgunLiteCounter : Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            //this.Name=Guid.NewGuid().ToString();
        }
    }
}
