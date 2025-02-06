using ClosersIseubi.Service;
using ClosersFramework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosersFramework.Templates;

namespace ClosersIseubi.Extendeds
{
	public class CEn_iseubi0 : ClosersBaseExtend
	{
		public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
		{
			base.SkillUseSingleAfter(SkillD, Targets);
			IseubiService.addChipWithBuff(5, IseubiService.FindIseubiInBattle(), this.BChar);
		}
	}
}
