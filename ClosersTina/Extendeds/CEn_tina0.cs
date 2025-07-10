using ClosersFramework.Services;
using ClosersFramework.Templates;
using ClosersTina.Cards;
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
using Random = System.Random;

namespace ClosersTina.Extendeds
{
	//技能结算完毕后，缇娜对目标进行1~6次射击（每次射击造成攻击力33%的伤害）。并使缇娜过热+3。
	public class CEn_tina0: ClosersBaseExtend
	{
		public override bool CanSkillEnforce(Skill MainSkill)
		{
			return (MainSkill.TargetTypeKey == "enemy" || MainSkill.TargetTypeKey == "all_enemy" || MainSkill.TargetTypeKey == "random_enemy" || MainSkill.TargetTypeKey == "all_onetarget") && base.CanSkillEnforce(MainSkill);
		}

		public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
		{
			base.SkillUseSingleAfter(SkillD, Targets);
		}
		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
			if (this.BChar?.BattleInfo?.EnemyTeam?.AliveChars == null || this.BChar?.BattleInfo?.EnemyTeam?.AliveChars?.Count == 0) return;
			if(TinaService.FindTinaInBattle() == null) return;
			base.SkillUseSingle(SkillD, Targets);
			BattleSystem.DelayInputAfter(this.Useeffect2(Targets));
			TinaService.AddOverheat(3);
		}
		public IEnumerator Useeffect2(List<BattleChar> Targets)
		{
			var count = new Random().Next(1, 7);

			TinaWeapons weapon = TinaWeapons.Continue;
			if (TinaService.FindTinaInBattle()!=null)
			{
				if (count <= 3)
				{
					weapon = TinaWeapons.Pistol;
				}
				else //if (count <= 4)
				{
					weapon = TinaWeapons.Rifle;
				}
				//else
				//{
				//	weapon = TinaWeapons.SMG;
				//}
			}

			for (var i = 0; i < count; i++)
			{
				//clog.tw($"이슬비：第{i + 1}次释放");
				BattleSystem.DelayInput(this.Ienum(weapon, Targets));
				//yield return this.Ienum(Targets);
				if (i < count - 1)
				{
					yield return new WaitForSecondsRealtime(0.2f);
				}
			}


			//IseubiSoundService.RandomSound(IseubiKeyWords.V_LawDagger, 2, this);
			yield return null;
			yield break;
		}
		public IEnumerator Ienum(TinaWeapons weapon, List<BattleChar> Targets)
		{
			yield return new WaitForSecondsRealtime(0.1f);
			var skill = Skill.TempSkill(TinaKeyWords.C_tina_Shoot, TinaService.FindTinaInBattle(), this.BChar.MyTeam);
			//var skill_Extended = new Skill_Extended();
			//skill_Extended.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.2);
			//skill_Extended.PlusPerStat.Damage = -100;
			//skill.ExtendedAdd(skill_Extended);
			//skill.ExtendedAdd(DataToExtended("C_tina_Shoot"));
			try
			{
				//var cts = skill.ExtendedFind(TinaKeyWords.C_tina_Shoot) as C_tina_Shoot;
				var cts = skill.ExtendedAdd(new C_tina_Shoot()) as C_tina_Shoot;
				cts.Weapon = weapon;
				cts.AudioName = weapon == TinaWeapons.Pistol ? TinaKeyWords.Closers_Tina_Pistol_Audio : TinaKeyWords.Closers_Tina_Rifle_Audio;
				TinaAudioService.Play(cts.AudioName, 3f);
				bool isSwitching = TinaService.GetNowWeapon() != weapon;
				if (weapon != TinaWeapons.Continue) TinaService.SwitchWeapon(weapon);
				if (isSwitching) cts.AudioForeSecond = cts.AudioForeSecond.Limit(cts.SwitchingTime, DotNetExtend.LimitType.min);
			}
			catch
			{
				//clog.tw("cen tina0 91");
			}
			
			var skill_Extended = DataToExtended("CS_iseubiPlusHit");
			skill.ExtendedAdd(skill_Extended);
			skill.isExcept = true;
			skill.FreeUse = true;
			skill.PlusHit = true;
			skill.NotCount = true;
			if (Targets.Count == 0)
				this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random());
			this.BChar.ParticleOut(this.MySkill, skill, Targets);
			yield return new WaitForFixedUpdate();
			yield break;
		}
	}
}
