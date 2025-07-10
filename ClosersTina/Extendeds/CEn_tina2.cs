using ClosersFramework.Templates;
using ClosersTina.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersTina.Extendeds
{
	//清空缇娜的过热
	public class CEn_tina2: ClosersBaseExtend
	{
		public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
		{
			base.SkillUseSingleAfter(SkillD, Targets);
			TinaService.ClearOverheat();

			BattleSystem.instance.StartCoroutine(enumerator());
			//TinaService.GetTinaPBInBattle().SetHeat(0);
		}
		public IEnumerator enumerator()
		{
			yield return new WaitForSecondsRealtime(0.1f);
			TinaService.GetTinaPBInBattle().StateHasChanged();
			yield break;
		}
	}
}
