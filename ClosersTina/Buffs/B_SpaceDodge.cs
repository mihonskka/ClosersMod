using ClosersFramework.Models;
using ClosersFramework.Services;
using ClosersFramework.Templates;
using ClosersTina.KeyWords;
using ClosersTina.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersTina.Buffs
{
    public class B_SpaceDodge : ClosersBaseBuff, IP_Dodge
    {
        public CastingSkill c3skill { get=> BattleSystem.instance.CastSkills.Union(BattleSystem.instance.SaveSkill).ToList().FirstOrDefault(t => t.skill.MySkill.KeyID == TinaKeyWords.C_tina3 && t.skill.Master == TinaService.FindTinaInBattle()); }
        public bool dodgeSuccess { get; set; } = false;
        public override void Init()
        {
            base.Init();
            
        }
		public override void BuffStat()
		{
			base.BuffStat();
			this.PlusStat.PerfectDodge = true;
			this.PlusStat.dod = 999;
			this.PlusStat.RES_CC = 999;
			this.PlusStat.RES_DEBUFF = 999;
			this.PlusStat.RES_DOT = 999;
		}

		public override void DestroyByTurn()
        {
            base.DestroyByTurn();
            if (dodgeSuccess) this.BChar.MyTeam.ForceDraw(this.BChar.MyTeam.Skills_UsedDeck.FirstOrDefault(t => t.MySkill.KeyID == TinaKeyWords.C_tina3) ?? this.BChar.MyTeam.Skills_Deck.FirstOrDefault(t => t.MySkill.KeyID == TinaKeyWords.C_tina3));
        }

        public IEnumerator Counter(CastingSkill CastingSkill)
        {
            yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyCastingSkillUse(CastingSkill, false));
            BattleSystem.instance.CastSkills.Remove(CastingSkill);
            BattleSystem.instance.SaveSkill.Remove(CastingSkill);
            yield break;
        }

        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if(SP.TargetChar.All(t=>t!=this.BChar) && Char != this.BChar)
            {
                BattleSystem.DelayInput(this.Counter(c3skill));
                dodgeSuccess = true;
                if (TinaService.CheckPresence(true)) TinaSoundService.RandomSound(TinaKeyWords.V_TinaDodge, 3, new SoundsComponentMsg() { ComponentMaster = TinaService.FindTinaInBattle(), ComponentCoordinate = new Vector3(), ComponentTransform = null });
                this.SelfDestroy();
                this.StackDestroy();
            }
        }
    }
}
