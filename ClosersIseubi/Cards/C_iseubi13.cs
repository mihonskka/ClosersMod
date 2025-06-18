using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.Services;
using GameDataEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ClosersFramework.Services.Enum;

namespace ClosersIseubi.Cards
{
    public class C_iseubi13: IseubiBaseCard
    {
        public C_iseubi13():base(2,false,true,CardType.Teleport)
        {
            
        }
        public override void FixedUpdate()
        {
            if (BattleSystem.instance != null)
            {
                bool e1 = false, e2 = this.BChar?.BuffFind(IseubiKeyWords.birsm)??false;
                e1 = BattleSystem.instance.EnemyTeam?.Chars?.Any(t => t.BuffFind(IseubiKeyWords.birsb))??false;
                if (e1||e2)
                {
                    this.APChange = -1;
                    this.NotCount = true;
                }
                else
                {
                    this.APChange = 0;
                    this.NotCount = false;
                }
                //base.plusChip = BattleSystem.instance.EnemyTeam.AliveChars.Count * 2;
            }
            base.FixedUpdate();
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
			if (!this.MySkill.PlusHit)
			{
				foreach (BattleChar b in Targets)
					if (b.BuffFind(IseubiKeyWords.birsb))
						if (b.HP <= b.GetStat.maxhp / 2) 
						{
							SkillD.Fatal = true;
							if(!this.MySkill.PlusHit) IseubiSoundService.RandomSound(IseubiKeyWords.V_Metro, 3, this);
							new WaitForSecondsRealtime(0.5f);
							break;
						}
			}
			base.SkillUseSingle(SkillD, Targets);
        }

		public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
		{
            base.AttackEffectSingle(hit, SP, DMG, Heal);
            if (!this.MySkill.PlusHit)
            {
                mainhit = hit;
                //BattleSystem.instance.EnemyTeam.AliveChars.ForEach(t => BattleSystem.instance.StartCoroutine(this.Ienum(t)));
                foreach (var t in BattleSystem.instance.EnemyTeam.Chars.Where(u=>!u.IsDead))
                {
                    if (t != null && t != mainhit)
                    {
                        Skill skill = Skill.TempSkill(IseubiKeyWords.C_iseubi13_0, this.BChar, this.BChar.MyTeam);
                        Skill_Extended skill_Extended = new Skill_Extended();
                        //skill_Extended.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk);
                        //skill_Extended.PlusPerStat.Damage = -100;
                        skill_Extended.PlusSkillStat.hit = 200;
                        skill.ExtendedAdd(skill_Extended);
                        skill = EnforceAddService.AddEnforce(this.MySkill, skill);
                        skill.isExcept = true;
                        skill.FreeUse = true;
                        skill.IgnoreTaunt = true;
                        skill.PlusHit = true;
                        this.BChar.ParticleOut(skill, skill, t);
                        //new WaitForSecondsRealtime(0.2f);
                    }
                }
            }
			    
		}
        public override void MissEffect(BattleChar hit, SkillParticle SP)
        {
            if(SP.SkillData.MySkill.KeyID!=this.MySkill.MySkill.KeyID) return;
            clog.iw("大地铁闪避");
            base.MissEffect(hit, SP);
            if (!this.MySkill.PlusHit)
            {
                mainhit = hit;
                //BattleSystem.instance.EnemyTeam.AliveChars.ForEach(t => BattleSystem.instance.StartCoroutine(this.Ienum(t)));
                foreach (var t in BattleSystem.instance.EnemyTeam.Chars.Where(u => !u.IsDead))
                {
                    if (t != null && t != mainhit)
                    {
                        Skill skill = Skill.TempSkill(IseubiKeyWords.C_iseubi13_0, this.BChar, this.BChar.MyTeam);
                        Skill_Extended skill_Extended = new Skill_Extended();
                        //skill_Extended.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk);
                        //skill_Extended.PlusPerStat.Damage = -100;
                        skill_Extended.PlusSkillStat.hit = 200;
                        skill.ExtendedAdd(skill_Extended);
                        skill = EnforceAddService.AddEnforce(this.MySkill, skill);
                        skill.isExcept = true;
                        skill.FreeUse = true;
                        skill.IgnoreTaunt = true;
                        skill.PlusHit = true;
                        this.BChar.ParticleOut(skill, skill, t);
                        //new WaitForSecondsRealtime(0.2f);
                    }
                };
            }
        }
        //public override void SkillKill(SkillParticle SP)
        //{
        //    clog.w("大地铁击杀");
        //    BattleSystem.instance.EnemyTeam.AliveChars.ForEach(t => BattleSystem.instance.StartCoroutine(this.Ienum(t)));
        //    base.SkillKill(SP);
        //}
        BattleChar mainhit { get; set; }
        public IEnumerator Ienum(BattleChar hit)
		{
            if (hit != null && hit != mainhit)
            {
                Skill skill = Skill.TempSkill(IseubiKeyWords.C_iseubi13_0, this.BChar, this.BChar.MyTeam);
                Skill_Extended skill_Extended = new Skill_Extended();
                //skill_Extended.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk);
                //skill_Extended.PlusPerStat.Damage = -100;
                skill_Extended.PlusSkillStat.hit = 200;
                skill.ExtendedAdd(skill_Extended);
                skill = EnforceAddService.AddEnforce(this.MySkill, skill);
                skill.isExcept = true;
                skill.FreeUse = true;
                skill.IgnoreTaunt = true;
                skill.PlusHit = true;
                this.BChar.ParticleOut(skill, skill, hit);
            }
			yield return new WaitForSecondsRealtime(0.2f);
			yield break;
		}
	}
    public class C_iseubi13_0:IseubiBaseCard
    {
        public C_iseubi13_0():base(2,false,true,CardType.None)
        {
            
        }
        public override void MissEffect(BattleChar hit, SkillParticle SP)
        {
            base.MissEffect(hit, SP);
            ChangeChipNum();
        }
        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            base.AttackEffectSingle(hit, SP, DMG, Heal);
            ChangeChipNum();
        }
    }
}
