using ClosersFramework.Services;
using ClosersTina.KeyWords;
using ClosersTina.Models;
using ClosersTina.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersTina.Cards
{
    public class C_tina12:TinaBaseCard
    {
        public C_tina12() : base(false,10) { }

        public override void Init()
        {
            base.Init();
            this.PlusStat.Penetration = 500;
        }
		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
			Targets.ForEach(t =>
            {
                BuffStagingService.AddRegistration(new BuffStagingUnit() { Owner = t as BattleEnemy, Buffs = t.Buffs.Select(u=>new ClosersRegistBuff { buffkey= u.BuffData.Key, remainTime=u.LifeTime }).ToList() });
                t.Buffs.Where(u => !u.BuffData.Debuff).ToList().ForEach(u => u.SelfDestroy());
            });
            base.SkillUseSingle(SkillD, Targets);
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaRocket, 2, this);
            var target2 = BattleSystem.instance.EnemyTeam.AliveChars.Where(t => !Targets.Contains(t)).ToList();
            BattleSystem.DelayInput(this.Ienum0(target2));
        }
        public IEnumerator Ienum0(List<BattleChar> Targets)
        {
            //clog.tw("手榴弹-进入溅射ienum。");
            //var skill = this.MySkill.CloneSkill();
            var skill = Skill.TempSkill(TinaKeyWords.C_tina12_0, this.BChar, this.BChar.MyTeam);
            var skill_Extended = new Skill_Extended();
            skill_Extended.SkillBasePlus.Target_BaseDMG = 30;
            //skill_Extended.PlusPerStat.Damage = -100;
            //skill.ExtendedAdd(skill_Extended);
            //skill = EnforceAddService.AddEnforce(this.MySkill, skill);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.NotCount = true;

            skill.ExtendedAdd(skill_Extended);
            clog.tw("火箭筒-开始溅射。");
            this.BChar.ParticleOut(this.MySkill, skill, Targets);
            yield return new WaitForFixedUpdate();
            yield break;
        }

        public override string ClosersDesc(string desc)
        {
            return base.ClosersDesc(desc).Replace("&a", ((int)(this.BChar.GetStat.atk*0.3)).ToString());
        }
    }
    public class C_tina12_0 : TinaBaseCard
    {
        public C_tina12_0() : base(false, 0) { }
    }
}
