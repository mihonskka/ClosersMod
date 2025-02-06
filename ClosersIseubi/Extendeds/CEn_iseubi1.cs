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
	public class CEn_iseubi1 : ClosersBaseExtend
    {
		public override void Init()
		{
			base.Init();
			this.APChange = -1;
		}
		public override bool Terms() => (BattleSystem.instance != null && IseubiService.GetChipNum() < 3) ? false: base.Terms();
		public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
		{
			base.SkillUseSingleAfter(SkillD, Targets);
			IseubiService.reduceChipWithBuff(-3, IseubiService.FindIseubiInBattle());
		}
	}
}
