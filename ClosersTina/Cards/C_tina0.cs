using ClosersFramework.Services;
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

namespace ClosersTina.Cards
{
    public class C_tina0 : TinaBaseCard
    {
        public C_tina0() : base(false)
        {
            this.Weapon = TinaWeapons.Grenade;
		}
        public override void Init()
        {
            base.Init();
            if(BattleSystem.instance != null && BattleSystem.instance.AllyList.Any(t => t.MyBasicSkill.buttonData == this.MySkill)) this.APChange = -1;
        }
        public override string ClosersDesc(string desc)
        {
            return base.ClosersDesc(desc).Replace("&a",((int)(this.BChar.GetStat.atk*0.4)).ToString());
        }
		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
			base.SkillUseSingle(SkillD, Targets);
            var target2 = BattleSystem.instance.EnemyTeam.AliveChars.Where(t => !Targets.Contains(t)).ToList();
            //clog.tw($"手榴弹-准备溅射0。目标数量：{target2.Count}");
            if(target2!=null && target2.Count>0)BattleSystem.DelayInput(this.Ienum0(target2));
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaGrenade, 1, this);
        }
		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (BattleSystem.instance != null && BattleSystem.instance.AllyList.Any(t => t.MyBasicSkill.buttonData == this.MySkill) && !basicCheckPassed && (ThrottleService.CheckAvailable(ThrottleKeyWords.C0Check)))
            {
				(TinaService.FindTinaInBattle() as BattleAlly).MyBasicSkill.buttonData.ExtendedAdd(new Extended_Lucy_14_0());
                basicCheckPassed = true;
				ThrottleService.AddRegistrationMilliSeconds(ThrottleKeyWords.C0Check, 300);
			}
		}
        bool basicCheckPassed = false;
		public IEnumerator Ienum0(List<BattleChar> Targets)
        {
            //clog.tw("手榴弹-进入溅射ienum。");
            //var skill = this.MySkill.CloneSkill();
            var skill = Skill.TempSkill(TinaKeyWords.C_tina0_0, this.BChar, this.BChar.MyTeam);
            var skill_Extended = new Skill_Extended();
            skill_Extended.SkillBasePlus.Target_BaseDMG = 40;
            //skill_Extended.PlusPerStat.Damage = -100;
            //skill.ExtendedAdd(skill_Extended);
            //skill = EnforceAddService.AddEnforce(this.MySkill, skill);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.NotCount = true;

            skill.ExtendedAdd(skill_Extended);
            clog.tw("手榴弹-开始溅射。");
            this.BChar.ParticleOut(this.MySkill, skill, Targets);
            yield return new WaitForFixedUpdate();
            yield break;
        }
    }


    public class C_tina0_0 : TinaBaseCard
    {
        public C_tina0_0():base(false, 0)
        {
            
        }
    }
}
