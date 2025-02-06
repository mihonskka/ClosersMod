using ClosersFramework.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersItem.Equipments
{
	public class EmployeeCard : ClosersBaseEquipmentEffect, IP_SkillUse_User_After,IP_PlayerTurn
	{
		public override void Init()
		{
			base.Init();
			this.PlusStat.maxhp = 12;
		}

		int CardCount = 0;
		public void SkillUseAfter(Skill SkillD)
		{
			CardCount += 1;
			if (CardCount == BattleSystem.instance.TurnNum)
			{
				this.BChar.MyTeam.BasicSkillRefill(this.BChar, this.BChar.BattleBasicskillRefill);
			}
		}

		public void Turn()
		{
			CardCount = 0;
		}
	}
}
