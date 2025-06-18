using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Services.Enum;

namespace ClosersIseubi.Cards
{
	public class C_iseubi9 : IseubiBaseCard, IP_DamageChange
	{
		public C_iseubi9() : base(0, false, false, CardType.Teleport)
		{
		}
		bool voice = false;

		public override string ClosersDesc(string desc)
		{
			return base.ClosersDesc(desc).Replace("&a", ((int)Misc.PerToNum(this.BChar.GetStat.atk, 50f)).ToString());
		}

		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
			if (Targets.Any(t => t.BuffFind(IseubiKeyWords.birsb)))
			{
				this.PlusSkillStat.cri = 300f;
				this.voice = true;
			}
			base.SkillUseSingle(SkillD, Targets);
		}

		public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
		{
			base.AttackEffectSingle(hit, SP, DMG, Heal);
			if (this.voice) IseubiSoundService.RandomSound(IseubiKeyWords.V_Iraishingiri, 2, this);
		}
		public override int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
		{
            Damage = base.DamageChange(SkillD, Target, Damage, ref Cri, View);
			if (SkillD.MySkill.KeyID != IseubiKeyWords.C_iseubi9 || !(Target is BattleEnemy)) return Damage;
			this.SkillBasePlus.Target_BaseDMG = 0;
			if (this.BChar.BuffFind(IseubiKeyWords.birsm) && Target is BattleEnemy)
			{
				clog.iw("飞雷神斩-增加伤害");
				return Damage += BattleChar.CalculationResult(this.BChar.Info.get_stat.atk, 75, 0);
			} 
			return Damage;
		}
	}
}
