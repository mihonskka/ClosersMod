using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Services.Enum;

namespace ClosersIseubi.Cards
{
	public class C_iseubi_Cancel:IseubiBaseCard
	{
        public C_iseubi_Cancel():base(1,false,false,CardType.None)
        {
            
        }
		public override void SkillUseHand(BattleChar Target)
		{
			base.SkillUseHand(Target);
			//this.MySkill.MyTeam.WaitCount++;
			//this.MySkill.MyTeam.DiscardCount++;
		}
	}
}
