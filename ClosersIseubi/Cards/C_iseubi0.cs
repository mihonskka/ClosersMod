using ClosersIseubi.Isouryoku;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework;
using ClosersFramework.KeyWords;
using ClosersFramework.Services;
using DarkTonic.MasterAudio;
using GameDataEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ClosersFramework.Services.Enum;
using ToolBox = ClosersIseubi.Service.ToolBox;

namespace ClosersIseubi.Cards
{
    /// <summary>
    /// 戒律之刃
    /// </summary>
    public class C_iseubi0:IseubiBaseCard
    {
        public C_iseubi0():base(2, false, true, CardType.Gravity)
        {
        }

        public override void Init()
        {
            if (GlobalSetting.Allin) this.IgnoreTaunt=true;
            base.Init();
        }

        public override void FixedUpdate()
        {
            if (BattleSystem.instance != null && (ThrottleService.CheckAvailable(ThrottleKeyWords.C0Check)))
            {
                if (new Gravity().LV3()) this.PlusChip = 1;
                else this.PlusChip = 0;
                ThrottleService.AddRegistrationMilliSeconds(ThrottleKeyWords.C0Check, 5000);
            }
            base.FixedUpdate();
        }

        public override string ClosersDesc(string desc)
        {
            if (new Gravity().LV3()) return base.ClosersDesc(desc).Replace("&a", "3").Replace("&b", "3");
            else return base.ClosersDesc(desc).Replace("&a", "2").Replace("&b", "2");
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar?.BattleInfo?.EnemyTeam?.AliveChars == null || this.BChar?.BattleInfo?.EnemyTeam?.AliveChars?.Count == 0) return;

            base.SkillUseSingle(SkillD, Targets);
            clog.iw($"plushit:{this.MySkill.PlusHit}");
            if (this.MySkill.ExtendedFind("CS_iseubiPlusHit")==null)
            {
                BattleSystem.DelayInputAfter(this.Useeffect2(Targets));
            }
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            base.AttackEffectSingle(hit, SP, DMG, Heal);
		}
        public IEnumerator Useeffect2(List<BattleChar> Targets)
        {
            clog.iw("이슬비：连续释放第2次");
            BattleSystem.DelayInput(this.Ienum(Targets));
            clog.iw("이슬비：连续释放第3次");
            BattleSystem.DelayInput(this.Ienum(Targets));

            if(new Gravity().LV3())
            {
                BattleSystem.DelayInput(this.Ienum(Targets));
            }

			IseubiSoundService.RandomSound(IseubiKeyWords.V_LawDagger, 2, this);
			yield return null;
            yield break;
        }
        public IEnumerator Ienum(List<BattleChar> Targets)
        {
            var skill = Skill.TempSkill(IseubiKeyWords.C_iseubi0, this.BChar, this.BChar.MyTeam);
            //var skill_Extended = new Skill_Extended();
            //skill_Extended.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.2);
            //skill_Extended.PlusPerStat.Damage = -100;
            //skill.ExtendedAdd(skill_Extended);
            var skill_Extended = DataToExtended("CS_iseubiPlusHit");
            skill.ExtendedAdd(skill_Extended);
            skill = EnforceAddService.AddEnforce(this.MySkill, skill);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.NotCount = true;
            if(Targets.Count==0) 
                this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random());
            this.BChar.ParticleOut(this.MySkill, skill, Targets);
            yield return new WaitForFixedUpdate();
            yield break;
        }

		ToolBox toolbox=new ToolBox();
    }
}
