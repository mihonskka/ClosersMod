using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.Service;
using GameDataEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ClosersFramework.Service.Enum;

namespace ClosersIseubi.Cards
{
    /// <summary>
    /// 雷遁·闪电风暴
    /// </summary>
    public class C_iseubi1:IseubiBaseCard
    {
        public C_iseubi1():base(0, false, false, CardType.Electrical)
        {
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar?.BattleInfo?.EnemyList == null || this.BChar.BattleInfo.EnemyList.Count == 0) return;

            base.SkillUseSingle(SkillD, Targets);
            if (!this.MySkill.PlusHit)
            {
                BattleSystem.DelayInput(this.Useeffect2(Targets));

                if (IseubiService.GetChipNum(this.BChar) >= 5)
                {
                    Skill skill;
                    skill = Skill.TempSkill(IseubiKeyWords.C_iseubi1_0, this.BChar, this.BChar.MyTeam);
                    /*var gdesd = new GDESkillData(IseubiKeyWords.C_iseubi1_0);
                    gdesd.Target = new GDEs_targettypeData("enemy");
                    skill.Init(gdesd, this.MySkill.Master, this.BChar.MyTeam);*/
                    skill.NotCount = true;
                    skill.isExcept = true;
                    skill.Track = true;
                    skill.AutoDelete = 1;
                    skill.MySkill.Target = new GDEs_targettypeData("enemy");
                    this.BChar.MyTeam.Add(skill.CloneSkill(true, null, null, false), true);
                }
            }
        }
        public IEnumerator Useeffect2(List<BattleChar> Targets)
        {
            clog.iw("이슬비：连续释放第2次");
            BattleSystem.DelayInput(this.Ienum(Targets));
            clog.iw("이슬비：连续释放第3次");
            BattleSystem.DelayInput(this.Ienum(Targets));
            //BattleSystem.DelayInput(this.Waste());
            yield return null;
            yield break;
        }
        public IEnumerator Ienum(List<BattleChar> Targets)
        {
            Skill skill = Skill.TempSkill(IseubiKeyWords.C_iseubi1, this.BChar, this.BChar.MyTeam);
            Skill_Extended skill_Extended = new Skill_Extended();
            skill_Extended.PlusPerStat.Damage = -100;
            skill.ExtendedAdd(skill_Extended);
            var skill_Extended0 = DataToExtended("CS_iseubiPlusHit");
            skill.ExtendedAdd(skill_Extended0);
            skill = EnforceAddService.AddEnforce(this.MySkill, skill);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.NotCount = true;
            skill.MySkill.Target = new GDEs_targettypeData("enemy");
            skill_Extended.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.25);

            if (Targets.Count == 0)
                this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random<BattleEnemy>());
            this.BChar.ParticleOut(this.MySkill, skill, Targets);
            yield return new WaitForFixedUpdate();
            yield break;
        }

        ToolBox toolbox = new ToolBox();
    }
    public class C_iseubi1_0 : IseubiBaseCard
	{
        public C_iseubi1_0():base(-5,true,false,CardType.Electrical)
        {
        }

		public override void Init()
        {
            base.Init();
        }


        public override bool TargetHit(BattleChar Target)
        {
            return base.TargetHit(Target) || Target.BuffFind(IseubiKeyWords.bse);
        }

        public override void SkillUseHand(BattleChar Target)
        {
			clog.iw($"이슬비：麒麟打出");
			if (Target.HP >= Target.Info.BeforeMaxHP * 0.6)
                this.PlusSkillPerStat.Damage = 15;
            if (Target.BuffFind(IseubiKeyWords.bse))
            {
                this.PlusSkillStat.HitMaximum = false;
                this.PlusSkillStat.hit = 999f;
                IseubiSoundService.Sound(IseubiKeyWords.V_Lightning, this);
            }
                
            base.SkillUseHand(Target);
        }
    }
}
