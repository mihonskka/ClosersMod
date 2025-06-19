using ClosersFramework.Services;
using ClosersTina.KeyWords;
using ClosersTina.Services;
using EItem;
using GameDataEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersTina.Cards
{
    public class C_tina7:TinaBaseCard
    {
        public C_tina7() : base(true)
        {
            this.AudioName = TinaKeyWords.Closers_Tina_Pistol_Audio;
			this.Weapon = TinaWeapons.Pistol;
		}
		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
			base.SkillUseSingle(SkillD, Targets);
		}
		public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingleAfter(SkillD, Targets);
            BattleSystem.DelayInputAfter(ienum(Targets));
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaPistol, 4, this);
        }
        public IEnumerator ienum(List<BattleChar> Targets)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            if (Targets.All(t => !t.IsDead))
            {
                var skill = new Skill();
                skill = Skill.TempSkill(TinaKeyWords.C_tina7_0, this.BChar, this.BChar.MyTeam);
                skill.MySkill.Target = new GDEs_targettypeData("enemy");
                skill.AutoDelete = 1;
                skill.isExcept = true;
                skill.ExtendedAdd(DataToExtended(new GDESkillExtendedData("CS_iseubi0")));
                var ext = new Skill_Extended();
                BattleSystem.instance.AllyTeam.Add(skill, true);
            }
            yield break;
        }
    }
    public class C_tina7_0 : TinaBaseCard
    {
        public C_tina7_0() : base(false)
        {
            this.AudioName = TinaKeyWords.Closers_Tina_Pistol_Audio;
			this.Weapon = TinaWeapons.Pistol;
		}
		public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);
            Skill skill = new Skill();
            var gdesd = new GDESkillData(TinaKeyWords.C_tina7);
            gdesd.Target = new GDEs_targettypeData("enemy");
            skill.Init(gdesd, this.MySkill.Master, this.BChar.MyTeam);
            skill.NotCount = true;
            skill.isExcept = true;
            skill.IgnoreTaunt = true;
            skill.AutoDelete = 2;
            skill.MySkill.Target = new GDEs_targettypeData("enemy");
            skill.ExtendedAdd(DataToExtended(new GDESkillExtendedData("CS_iseubi0")));
            var skill0 = skill.CloneSkill(true, null, null, false);
            BattleSystem.instance.AllyTeam.AP++;


            this.BChar.MyTeam.Add(skill0, true);
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
			base.SkillUseSingle(SkillD, Targets);
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaPistol, 4, this);
        }
    }
}
