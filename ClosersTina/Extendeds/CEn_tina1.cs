using ClosersFramework.Templates;
using ClosersTina.KeyWords;
using ClosersTina.Services;
using GameDataEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersTina.Extendeds
{
	//2费及以上或1费非迅速
	//使用后生成一张缇娜的【急救包】
	public class CEn_tina1 : ClosersBaseExtend
	{
		public override bool CanSkillEnforce(Skill MainSkill)
		{
			return (MainSkill.AP >= 2 || (MainSkill.AP == 1 && MainSkill.NotCount)) && base.CanSkillEnforce(MainSkill);
		}

		public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
		{
			base.SkillUseSingleAfter(SkillD, Targets);
			BattleSystem.instance.StartCoroutine(ienum());
		}

		public IEnumerator ienum()
		{
			yield return new WaitForSecondsRealtime(0.2f);

			var skill = new Skill();
			skill = Skill.TempSkill(TinaKeyWords.C_tina10, TinaService.FindTinaInBattle(), this.BChar.MyTeam);
			skill.isExcept = true;
			//skill.ExtendedAdd(DataToExtended(new GDESkillExtendedData("CS_iseubi0")));
			BattleSystem.instance.AllyTeam.Add(skill, true);
			yield break;
		}
	}
}
