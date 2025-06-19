using ClosersFramework.Models.Interface;
using ClosersTina.KeyWords;
using ClosersTina.Services;
using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersTina.Cards
{
    public class C_tina1 : TinaBaseCard
    {
        public C_tina1():base(false)
        {

        }
        public override string ClosersDesc(string desc)
        {
            return base.ClosersDesc(desc).Replace("&a", ((int)Misc.PerToNum(this.BChar.GetStat.atk, 40f)).ToString()).Replace("&b", ((int)Misc.PerToNum(this.BChar.GetStat.atk, 33f)).ToString()).ToString();
        }
		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
			base.SkillUseSingle(SkillD, Targets);
		}
		public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingleAfter(SkillD, Targets);

            var skill = Skill.TempSkill(TinaKeyWords.C_tina1_0, this.BChar, this.BChar.MyTeam);

            if (Targets == null || Targets.All(t => t.IsDead) || Targets.Count == 0)
            {
                //BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.instance.ForceAction(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(), false, false, false, null));
                BattleSystem.instance.StartCoroutine(BattleSystem.instance.ForceAction(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(), false, false, false, null));
            }
            else
            {
                //BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.instance.ForceAction(skill, Targets.Random(), false, false, false, null));
                BattleSystem.instance.StartCoroutine(BattleSystem.instance.ForceAction(skill, Targets.Random(), false, false, false, null));
            }

            var skill1 = Skill.TempSkill(TinaKeyWords.C_tina1_1, this.BChar, this.BChar.MyTeam);
            skill1.isExcept = true;
            skill1.AutoDelete = 3;
            this.BChar.MyTeam.Add(skill1, true);
        }
    }

    public class C_tina1_0 : TinaBaseCard
    {
        public C_tina1_0() : base(false, 0)
        {
            this.AudioName = TinaKeyWords.Closers_Tina_Shotgun_Audio;
            this.Weapon = TinaWeapons.Shotgun;
		}
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
			base.SkillUseSingle(SkillD, Targets);
		}
		public override int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            this.SkillBasePlus.Target_BaseDMG = 0;
            if (Target is BattleEnemy && (Target as BattleEnemy).istaunt)
            {
                Damage += BattleChar.CalculationResult(this.BChar.Info.get_stat.atk, 33, 0);
            }
            return base.DamageChange(SkillD, Target, Damage, ref Cri, View);
        }
        public override string ClosersDesc(string desc)
        {
            return base.ClosersDesc(desc).Replace("&b", ((int)Misc.PerToNum(this.BChar.GetStat.atk, 33f)).ToString()).ToString();
        }
        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            base.AttackEffectSingle(hit, SP, DMG, Heal);
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaBlade, 8, this);
        }
    }

    public class C_tina1_1 : TinaBaseCard
    {
        public C_tina1_1() : base(false, 0)
        {
            this.Weapon = TinaWeapons.Continue;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            BattleSystem.instance.EnemyTeam.Chars.ForEach(t => t.Buffs.ForEach(u =>
            {
                if (u.BuffData.Key == TinaKeyWords.B_C4) u.SelfDestroy();
            }));
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaBomb, 3, this);
        }
    }
}
