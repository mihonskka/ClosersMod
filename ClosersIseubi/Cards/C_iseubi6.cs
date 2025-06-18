using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosersIseubi.Isouryoku;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Models;
using ClosersIseubi.Service;
using ClosersFramework.Models;
using ClosersFramework.Services;
using DarkTonic.MasterAudio;
using GameDataEditor;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;
using static ClosersFramework.Services.Enum;

namespace ClosersIseubi.Cards
{
    public class C_iseubi6 : IseubiBaseCard
    {
        public C_iseubi6() : base(3, false, true, CardType.Gravity) { }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            List<Skill> list = new List<Skill>
            {
                Skill.TempSkill(IseubiKeyWords.C_iseubi6_0, this.MySkill.Master, this.MySkill.Master.MyTeam),
                Skill.TempSkill(IseubiKeyWords.C_iseubi6_1, this.MySkill.Master, this.MySkill.Master.MyTeam)
            };
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, false, true, false, false));
            _Targets = Targets;
        }

        List<BattleChar> _Targets;

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.FreeUse = true;

            clog.iw($"이슬비：Mybutton_KeyID：{Mybutton.Myskill.MySkill.KeyID}");
            if (Mybutton.Myskill.MySkill.KeyID == IseubiKeyWords.C_iseubi6_0)
            {
                var skill = Skill.TempSkill(IseubiKeyWords.C_iseubi6_0, this.BChar, this.BChar.MyTeam);
                skill = EnforceAddService.AddEnforce(this.MySkill, skill);
                skill =  new Gravity().LV2_IgnoreDef(skill);
                this.BChar.ParticleOut(skill, _Targets);
                //BattleSystem.DelayInputAfter(BattleSystem.instance.SkillRandomUseIenum(this.BChar, Skill.TempSkill(KeyWords.C_iseubi6_0)));
            }
            if (Mybutton.Myskill.MySkill.KeyID == IseubiKeyWords.C_iseubi6_1)
            {
                var skill = Skill.TempSkill(IseubiKeyWords.C_iseubi6_1, this.BChar, this.BChar.MyTeam);
                skill = EnforceAddService.AddEnforce(this.MySkill, skill);
                skill = new Gravity().LV2_IgnoreDef(skill);
                this.BChar.ParticleOut(skill, _Targets);
                //BattleSystem.DelayInputAfter(BattleSystem.instance.SkillRandomUseIenum(this.BChar, Skill.TempSkill(KeyWords.C_iseubi6_1)));
            }
        }
    }
    public class C_iseubi6_0 : IseubiBaseCard
    {
        public C_iseubi6_0() : base(0, false, false, CardType.Gravity)
        {
        }
        public override void Init()
        {
            clog.iw($"이슬비：万象天引三连击I");
            base.Init();
        }

        TranslationItem ExtDesc = new TranslationItem()
        {
            Id=0,
            SimplifiedChinese = "\n无视防御。",
            TraditionalChinese="\n無視防禦。",
            English= "\nIgnores Armor.",
            Japanese= "\n防御無効。",
            Korean= "\n방어 무시"
        };

        public override string ClosersDesc(string desc)
        {
            if(new Gravity().LV2Desc())
            {
                desc += ExtDesc.TransToLocalization;
            }
            return base.ClosersDesc(desc);
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            clog.iw($"이슬비：万象天引三连击AES");
			clog.iw($"이슬비：万象天引-清除干扰抵抗");
			SP.TargetChar.ForEach(t =>t.BuffRemove("B_Common_CCRsis"));
			base.AttackEffectSingle(hit, SP, DMG, Heal);
            if (!this.MySkill.PlusHit)
            {
                BattleSystem.DelayInputAfter(this.Useeffect2(hit));
                IseubiSoundService.RandomSound(IseubiKeyWords.V_Gravitation, 3, this);
            }
        }
        public IEnumerator Useeffect2(BattleChar hit)
        {
			new WaitForSecondsRealtime(0.2f);
			BattleSystem.DelayInput(this.Ienum(hit));
            BattleSystem.DelayInput(this.Ienum(hit));
            yield return null;
            yield break;
        }
        public IEnumerator Ienum(BattleChar hit)
        {
            Skill skill = Skill.TempSkill(IseubiKeyWords.C_iseubi6_0, this.BChar, this.BChar.MyTeam);
            Skill_Extended skill_Extended = new Skill_Extended();
            skill_Extended.PlusPerStat.Damage = -100;
            skill.ExtendedAdd(skill_Extended);
            skill.ExtendedAdd(DataToExtended(new GDESkillExtendedData(IseubiKeyWords.CS_iseubi0)));
            skill = EnforceAddService.AddEnforce(this.MySkill, skill);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill_Extended.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk*0.4);
            if (hit != null && !hit.IsDead)
            {
                clog.iw($"이슬비：万象天引三连击-判定目标未死亡");
                this.BChar.ParticleOut(this.MySkill, skill, hit);
            }
            else
            {
                clog.iw($"이슬비：万象天引三连击-判定目标已死亡");
                this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random<BattleEnemy>()); 
            }
            yield return new WaitForSecondsRealtime(0.2f);
            yield break;
        }
    }
    public class C_iseubi6_1 : IseubiBaseCard
    { 
        public C_iseubi6_1 (): base(0, false, false, CardType.Gravity) { }
        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
		{
			clog.iw($"이슬비：万象天引-清除干扰抵抗");
            SP.TargetChar.ForEach(t =>t.BuffRemove("B_Common_CCRsis"));
			base.AttackEffectSingle(hit, SP, DMG, Heal);
            IseubiSoundService.RandomSound(IseubiKeyWords.V_Gravitation, 3, this);
		}
		public IEnumerator Useeffect2()
        {
            BattleSystem.DelayInput(this.Ienum());
            yield return null;
            yield break;
        }
        public IEnumerator Ienum()
        {
            Skill skill = Skill.TempSkill(IseubiKeyWords.C_iseubi6_1, this.BChar, this.BChar.MyTeam);
            Skill_Extended skill_Extended = new Skill_Extended();
            skill_Extended.PlusPerStat.Damage = -100;
            skill.ExtendedAdd(skill_Extended);
            skill.ExtendedAdd(DataToExtended(new GDESkillExtendedData(IseubiKeyWords.CS_iseubi0)));
            skill = EnforceAddService.AddEnforce(this.MySkill, skill);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill_Extended.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk);
            this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random<BattleEnemy>());
            yield return new WaitForFixedUpdate();
            yield break;
        }
    }
}
