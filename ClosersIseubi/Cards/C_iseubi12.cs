using ClosersIseubi.Service;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using ClosersIseubi.KeyWords;
using ClosersFramework.Service;
using static ClosersFramework.Service.Enum;
using ClosersFramework;
using ClosersFramework.KeyWords;
using ClosersFramework.Models;
using ClosersFramework.PluginUnits;
using ClosersIseubi.Isouryoku;

namespace ClosersIseubi.Cards
{
    public class C_iseubi12 : IseubiBaseCard
    {
        public C_iseubi12() : base(-1, true, false, CardType.Electrical){ }

        public override void SkillUseHandBefore()
        {
            this.PlusSkillStat.HitMaximum = false;
            this.PlusSkillStat.hit = 999;
            base.SkillUseHandBefore();
        }

        public override string ClosersDesc(string desc)
        {
            return base.ClosersDesc(desc).Replace("&a", chipNumTimes.ToString()).Replace("&b", extraDamage.ToString());
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            this.TargetTemp = Targets[0];
            List<Skill> list = new List<Skill>
            {
                Skill.TempSkill(IseubiKeyWords.C_iseubi12_0, this.MySkill.Master, this.MySkill.Master.MyTeam),
                Skill.TempSkill(IseubiKeyWords.C_iseubi12_1, this.MySkill.Master, this.MySkill.Master.MyTeam)
            };
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, false, true, false, false));
            _Targets = Targets;
        }

        List<BattleChar> _Targets;
        int chipNumTimes => IseubiService.GetChipNum(this.BChar) + 1;
        int chipNumDamage=> IseubiService.GetChipNum(this.BChar) + 1 + this.BChar.MyTeam.LucyAlly.Buffs.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.blmc)?.StackNum ?? 0 + this.BChar.Buffs.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.bls)?.StackNum ?? 0 + this.BChar.Buffs.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.blsex)?.StackNum ?? 0;
        int extraDamage => (int)(1 + 0.4 * chipNumDamage*this.BChar.GetStat.atk);

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.FreeUse = true;

            clog.iw($"이슬비：Mybutton_KeyID：{Mybutton.Myskill.MySkill.KeyID}");
            if (Mybutton.Myskill.MySkill.KeyID == IseubiKeyWords.C_iseubi12_0)
				BattleSystem.DelayInputAfter(this.Useeffect0());
			if (Mybutton.Myskill.MySkill.KeyID == IseubiKeyWords.C_iseubi12_1)
                BattleSystem.DelayInputAfter(this.Useeffect1());
            this.BChar.ParticleOut(Skill.TempSkill(IseubiKeyWords.C_iseubi12_1, this.BChar, this.BChar.MyTeam), _Targets);
        }

        public override void FixedUpdate()
        {
            if(BattleSystem.instance!=null)
            {
                int chipCount = 0;
                chipCount = this.BChar.Buffs?.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.bc)?.StackNum??0;
                this.APChange = chipCount / 5;
                if (this.APChange>4) this.APChange = 4;
            }
            base.FixedUpdate();
        }

		public IEnumerator Ienum0(int num)
		{
			Skill skill = Skill.TempSkill(IseubiKeyWords.C_iseubi12_0, this.BChar, this.BChar.MyTeam);
			Skill_Extended skill_Extended = new Skill_Extended();
            skill_Extended.SkillBasePlus.Target_BaseDMG = extraDamage;
            skill_Extended.PlusSkillStat.hit = 500;
            skill_Extended.PlusSkillStat.cri = 10;
			skill.ExtendedAdd(skill_Extended);
            skill.isExcept = true;
			skill.FreeUse = true;
			skill.PlusHit = true;
			this.BChar.ParticleOut(this.MySkill, skill, TargetTemp);
            this.BChar.MyTeam.Skills_UsedDeck.RemoveAll(t => t.MySkill.KeyID == this.MySkill.MySkill.KeyID);
            IseubiService.FindIseubiInInvest().SkillDatas.RemoveAll(t => t.SkillInfo.KeyID == this.MySkill.MySkill.KeyID);
            PlayData.TSavedata.Party.Select(t => t.SkillDatas).SelectMany(t => t).ToList().RemoveAll(t => t.SkillInfo.KeyID == this.MySkill.MySkill.KeyID);
            yield return new WaitForSecondsRealtime(3f);
            InventoryManager.Reward(new List<ItemBase>()
            {
                ItemBase.GetItem(new GDESkillData(IseubiKeyWords.CL_iseubi1))
            });
            yield return new WaitForSecondsRealtime(0.2f);
			yield break;
		}
		public IEnumerator Useeffect0()
		{
            int chipNum = chipNumDamage;

            clog.iw($"이슬비：超电磁炮碎片数量计算结果为：{chipNum}");

			if (chipNum >= 10)
			{
				new WaitForSecondsRealtime(0.7f);
				IseubiSoundService.Sound(IseubiKeyWords.V_Railgun, this);
			}
			BattleSystem.DelayInput(this.Ienum0(chipNum));
			clog.iw($"이슬비：超电磁炮释放完毕。准备消耗魔法碎片");
			this.BChar.Buffs.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.bc)?.SelfDestroy();
			this.BChar.Buffs.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.bls)?.SelfDestroy();
			this.BChar.Buffs.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.blsex)?.SelfDestroy();
			this.BChar.MyTeam.LucyAlly.Buffs.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.blmc)?.SelfDestroy();
			yield return null;
			yield break;
		}
        public IEnumerator Useeffect1()
		{
            int chipNum = this.chipNumTimes;
			clog.iw($"이슬비：超电磁炮碎片数量计算结果为：{chipNum}");

			if (chipNum >= 10)
			{
				new WaitForSecondsRealtime(0.7f);
				IseubiSoundService.Sound(IseubiKeyWords.V_Railgun,this);
			}
            if (GlobalSetting.Allin) chipNum *= 2;
            for (int i = 0; i < chipNum; i++)
            {
                BattleSystem.DelayInput(this.Ienum1());
                if (BattleSystem.instance.EnemyTeam.AliveChars.Count <= 0 && BattleSystem.instance.EnemyTeam.AliveChars_Vanish.Count <= 0)
                    break;
            }
            BattleSystem.instance.ActAfter();
            clog.iw($"이슬비：超电磁炮释放完毕。准备消耗魔法碎片");
			this.BChar.Buffs.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.bc)?.SelfDestroy();
			yield return null;
			yield break;
		}
        public IEnumerator Ienum1()
        {
            Skill skill = Skill.TempSkill(IseubiKeyWords.C_iseubi12_1, this.BChar, this.BChar.MyTeam);
            Skill_Extended skill_Extended = new Skill_Extended();
            skill_Extended.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.4);
            skill_Extended.PlusPerStat.Damage = -100;
            skill.ExtendedAdd(skill_Extended);
            skill.ExtendedAdd(DataToExtended(new GDESkillExtendedData(IseubiKeyWords.CS_iseubi0)));
            skill = EnforceAddService.AddEnforce(this.MySkill, skill);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random<BattleEnemy>());
            yield return new WaitForSecondsRealtime(0.2f);
            yield break;
        }
        private BattleChar TargetTemp;
    }
    public class C_iseubi12_1 : IseubiBaseCard
    {
        public C_iseubi12_1() : base(-1, true, false, CardType.Electrical)
        {
            this.PlusSkillStat.hit = -10;
            clog.iw($"이슬비：光棱扫射初始化");
        }
        public override string ClosersDesc(string desc)
        {
            return base.ClosersDesc(desc).Replace("&a", (IseubiService.GetChipNum(this.BChar) + 1).ToString());
        }
    }
    public class C_iseubi12_0 : IseubiBaseCard
    {
        public C_iseubi12_0() : base(-1, true, false, CardType.Electrical)
        {
			clog.iw($"이슬비：极限火花初始化");
		}
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            
        }
        public override string ClosersDesc(string desc)
        {
            return base.ClosersDesc(desc).Replace("&b", ((int)(1 + 0.4 * (IseubiService.GetChipNum(this.BChar) + 1 + this.BChar.MyTeam.LucyAlly.Buffs.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.blmc)?.StackNum ?? 0 + this.BChar.Buffs.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.bls)?.StackNum ?? 0 + this.BChar.Buffs.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.blsex)?.StackNum ?? 0)* this.BChar.GetStat.atk)).ToString());
        }
    }
}
