using ClosersFramework.Models.Interface;
using ClosersFramework.Services;
using ClosersFramework.Templates;
using ClosersTina.KeyWords;
using ClosersTina.Services;
using DarkTonic.MasterAudio;
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
    public class TinaBaseCard : ClosersBaseCard, IP_DamageChange, IP_SkillUse_User_After,ICharacterSoundsToken
    {
        bool hasMultiStage;

        public int TotalStage { get; set; } = 0;
        public int NowStage { get; set; } = 1;
        public bool HasMultiStage { get => hasMultiStage && this.BChar.Info.KeyData == TinaKeyWords.Tina; set => hasMultiStage = value; }
        public int DamageThreshold { get; set; } = 33;
        public int OriginalDamage { get; set; }
        public int ReminderDamage { get; set; }
        public int NowStageDamage { get; set; } = 0;
        public bool HasNextStage { get; set; }
        public int OverHeat { get; set; } = 1;
        public bool RandomTarget { get; set; }
        public float AudioForeSecond { get; set; } = 0f;
        public float ComboGapSecond { get; set; } = 0.1f;
        public string AudioName { get; set; }
		public bool isSwitching { get; set; } = false;
        public float SwitchingTime { get; set; } = 0.5f; // 切换武器的时间
		public TinaWeapons Weapon { get; set; } = TinaWeapons.NoneOrOther;
        public Action AfterComboAction { get; set; } = null;
        public float AfterComboActionDelay { get; set; } = 0.5f;

		public BattleChar ComponentMaster => this.BChar;

        public Vector3 ComponentCoordinate => new Vector3();

        public Transform ComponentTransform => null;

        public TinaBaseCard(bool hasMultiStage = true, int overheat = 1, bool randomTarget = false) 
        {
            this.HasMultiStage = hasMultiStage;
            this.OverHeat = overheat;
            this.OnePassive = true;
            this.RandomTarget = randomTarget;
        }

        public void SkillUseAfter(Skill SkillD)
        {
            if (this.BChar.Info.KeyData == TinaKeyWords.Tina && !this.MySkill.PlusHit && this.OverHeat>0) TinaService.AddOverheat(this.BChar, this.OverHeat);
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            /*
            this.OriginalDamage = base.MySkill.TargetDamageView;
            this.ReminderDamage = OriginalDamage;

            //clog.w($"使用者为{this.BChar?.Info?.KeyData}");

            if (HasMultiStage && this.BChar?.Info?.KeyData == TinaKeyWords.Tina)
            {
                clog.tw($"本次伤害会触发多段伤害");
                NowStageDamage = (int)(this.BChar.GetStat.atk * 0.01 * DamageThreshold);
                clog.tw($"这一段伤害为{NowStageDamage}点");
            }

            if (ReminderDamage<NowStageDamage) NowStageDamage=ReminderDamage;
            HasNextStage = ReminderDamage - NowStageDamage > 0;
            */
            
            base.AttackEffectSingle(hit, SP, DMG, Heal);

            /*
            if (HasNextStage && this.BChar?.Info?.KeyData == TinaKeyWords.Tina)
            {
                clog.tw($"本次伤害有下一段伤害");
                if (hit == null || hit.IsDead)
                {
                    Useeffect2(new List<BattleChar>() { BattleSystem.instance.EnemyTeam.AliveChars.Random() });
                }
                else
                {
                    Useeffect2(new List<BattleChar>() { hit });
                }
                ReminderDamage -= NowStageDamage;
            }
            */
        }

		public override string UseSubParticlepath()
		{
            if (isSwitching && this.MySkill.MySkill.SubParticle_Path.Count > 0 && !string.IsNullOrEmpty(this.MySkill.MySkill.SubParticle_Path[0])) return this.MySkill.MySkill.SubParticle_Path[0];
			return base.UseSubParticlepath();
		}

		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
			isSwitching = TinaService.GetNowWeapon() != Weapon;
            if (Weapon != TinaWeapons.Continue) TinaService.SwitchWeapon(Weapon);
            if (isSwitching) AudioForeSecond = AudioForeSecond.Limit(SwitchingTime, DotNetExtend.LimitType.min);

			if (this.BChar?.BattleInfo?.EnemyList == null || this.BChar.BattleInfo.EnemyList.Count == 0) return;

            if (!this.MySkill.PlusHit && this.HasMultiStage)
            {
                clog.tw("本轮攻击将会触发连击");
                BattleSystem.DelayInput(this.Useeffect2(Targets));
            }
            if (AudioForeSecond > 0) BattleSystem.instance.StartCoroutine(PlayAudioAsync());
            else TinaAudioService.Play(AudioName, 3f);
            if (this.HasMultiStage && this.SkillBasePlus.Target_BaseDMG > DamageThreshold) this.SkillBasePlus.Target_BaseDMG = DamageThreshold;
            base.SkillUseSingle(SkillD, Targets);
        }

        public IEnumerator Useeffect2(List<BattleChar> Targets)
        {
            clog.tw("进入UF2");
            this.OriginalDamage = (int)this.MySkill?.TargetDamageView;

            NowStageDamage = (int)(this.BChar.GetStat.atk * 0.01 * DamageThreshold);
            this.TotalStage = (int)Math.Ceiling((decimal)(this.OriginalDamage / NowStageDamage));
            this.ReminderDamage = this.OriginalDamage - NowStageDamage;
            clog.tw($"UF2: OriginalDamage:{OriginalDamage}, TotalStage:{TotalStage}, NowStageDamage:{NowStageDamage}");
            for (var i = 1; i < TotalStage; i++)
            {
                clog.tw("进入UF2循环");
                this.NowStage = i;
                
                if(ReminderDamage<=NowStageDamage) NowStageDamage = ReminderDamage;
                BattleSystem.DelayInput(this.Ienum(Targets, NowStageDamage));

                this.ReminderDamage -= NowStageDamage;
                clog.tw($"ReminderDamage:{ReminderDamage}");
                if (ReminderDamage <= 0) break;

                //TinaService.AddGrenadeCounter(this.BChar);
            }
            if (ReminderDamage <= NowStageDamage && ReminderDamage >=1)
            {
                NowStageDamage = ReminderDamage;
                BattleSystem.DelayInput(this.Ienum(Targets, NowStageDamage + 1));
            }
            if (AfterComboAction != null) BattleSystem.DelayInput(AfterComboAction.ToCorotine(AfterComboActionDelay));

            yield return null;
            yield break;
        }
        public IEnumerator Ienum(List<BattleChar> Targets, int damage)
        {
            if (ComboGapSecond > 0) yield return new WaitForSecondsRealtime(ComboGapSecond);
            else yield return new WaitForFixedUpdate();
            var skill = this.MySkill.CloneSkill();
            var skill_Extended = DataToExtended(new GDESkillExtendedData(TinaKeyWords.Ex_TinaDamageLimiter)) as Ex_TinaDamageLimiter;
            skill_Extended.LimitDamage = damage;
            //skill_Extended.PlusPerStat.Damage = -100;
            //skill.ExtendedAdd(skill_Extended);
            //skill = EnforceAddService.AddEnforce(this.MySkill, skill);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.NotCount = true;
			if (skill.AllExtendeds.FirstOrDefault(t => t is TinaBaseCard) is TinaBaseCard mydata && mydata.isSwitching)
			{
				mydata.isSwitching = false;
				if (mydata.AudioForeSecond <= mydata.SwitchingTime) mydata.AudioForeSecond = 0;
			}

			skill.ExtendedAdd(skill_Extended);
            if (Targets.Count == 0 || this.RandomTarget)
                this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random());
            else this.BChar.ParticleOut(this.MySkill, skill, Targets);
			TinaAudioService.Play(AudioName, 3f);
			//if (AudioForeSecond > 0) BattleSystem.instance.StartCoroutine(PlayAudioAsync());
			//else TinaAudioService.Play(AudioName, 3f);
			yield break;
        }

        public IEnumerator PlayAudioAsync()
        {
            yield return new WaitForSecondsRealtime(AudioForeSecond);
            TinaAudioService.Play(AudioName, 3f);
            yield break;
        }

        public virtual int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (!this.HasMultiStage) return Damage;
            this.SkillBasePlus.Target_BaseDMG = 0;
            if (Damage > Math.Ceiling((decimal)BattleChar.CalculationResult(this.BChar.Info.get_stat.atk, this.DamageThreshold, 0)))
            {
                Damage = (int)Math.Ceiling((decimal)BattleChar.CalculationResult(this.BChar.Info.get_stat.atk, this.DamageThreshold, 0));
            }
            return Damage;
        }
    }

    public class Ex_TinaDamageLimiter : ClosersBaseExtend, IP_DamageChange
    {
        public int LimitDamage { get; set; }
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (Damage > LimitDamage)
            {
                Damage = LimitDamage;
            }
            return Damage;
        }
    }
}
