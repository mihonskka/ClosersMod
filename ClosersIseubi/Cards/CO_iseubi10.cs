using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Service.Enum;

namespace ClosersIseubi.Cards
{
	/// <summary>
	/// 飞雷神·互瞬回还
	/// </summary>
	public class CO_iseubi10:IseubiBaseCard
	{
        public CO_iseubi10():base(0,false,false,CardType.Teleport) { }

		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
			int chipChange = 0;
			Targets.ForEach(t =>
			{
				if (t.BuffFind(IseubiKeyWords.birsb))
				{
					t.BuffRemove(IseubiKeyWords.birsb);
					chipChange+=2;
				}
				else
				{
					IseubiService.addIraishinBeacon(this.BChar, t);
					chipChange-=2;
				}
			});
			base.chipChangeNum(chipChange);
			base.SkillUseSingle(SkillD, Targets);
		}
	}
}
