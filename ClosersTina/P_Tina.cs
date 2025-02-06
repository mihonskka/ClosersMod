using ClosersFramework;
using ClosersFramework.Models;
using ClosersFramework.Service;
using ClosersFramework.Service.CodeManager;
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
using static System.Net.Mime.MediaTypeNames;
using Random = System.Random;

namespace ClosersTina
{
    public class P_Tina : Passive_Char, IP_SkillUse_Team_Target, IP_DamageChange, IP_SkillUse_User_After, IP_SkillUseHand_Team, IP_BattleStart_Ones, IP_PlayerTurn_1, IP_TurnEnd, IP_BuffAddAfter, IP_BattleEnd, IP_StageStart, IP_PlayerTurn
    {
        int passiveCounter;

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (SkillD.Master == this.BChar && SkillD.AllExtendeds.All(t => !(t is TinaBaseCard)))
            {
                var Threshold = BattleChar.CalculationResult(this.BChar.Info.get_stat.atk, 33, 0) + 1;
                if (Damage > Threshold)
                {
                    Damage = Threshold;
                }
            }
            //if (SkillD.PlusHit && !Target.Info.Ally)
            //    TinaService.AddPassiveCounter(this.BChar);

            return Damage;
        }


        public IEnumerator Useeffect2(Skill skill, List<BattleChar> Targets)
        {
            int TotalStage;
            int DamageThreshold = 33;
            int OriginalDamage;
            int ReminderDamage;
            int NowStageDamage;

            clog.tw("连续释放第2次");
            OriginalDamage = skill.TargetDamageView;

            NowStageDamage = (int)(this.BChar.GetStat.atk * 0.01 * DamageThreshold);
            TotalStage = (OriginalDamage / NowStageDamage);
            ReminderDamage = OriginalDamage;
            for (var i = 1; i <= TotalStage; i++)
            {
                if (ReminderDamage <= NowStageDamage) NowStageDamage = ReminderDamage;
                BattleSystem.DelayInput(this.Ienum(skill, Targets, NowStageDamage));

                ReminderDamage -= NowStageDamage;
                if (ReminderDamage <= 0) break;
            }

            yield return null;
            yield break;
        }
        public IEnumerator Ienum(Skill skillD, List<BattleChar> Targets, int damage)
        {
            var skill = skillD.CloneSkill();
            var skill_Extended = new Skill_Extended();
            skill_Extended.SkillBasePlus.Target_BaseDMG = damage;
            //skill_Extended.PlusPerStat.Damage = -100;
            //skill.ExtendedAdd(skill_Extended);
            //skill = EnforceAddService.AddEnforce(this.MySkill, skill);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.NotCount = true;

            skill.ExtendedAdd(skill_Extended);
            if (Targets.Count == 0)
                this.BChar.ParticleOut(skillD, skill, this.BChar.BattleInfo.EnemyList.Random());
            this.BChar.ParticleOut(skillD, skill, Targets);
            yield return new WaitForFixedUpdate();
            yield break;
        }

        public void SkillUseTeam_Target(Skill skill, List<BattleChar> Targets)
        {
            bool HasMultiStage = true;
            int DamageThreshold = 33;
            int OriginalDamage;
            int ReminderDamage = 0;
            int NowStageDamage = skill.TargetDamageView;
            bool HasNextStage = true;
            if (skill.Master == this.BChar && skill.IsDamage && Targets.All(t=>t is BattleEnemy) && skill.AllExtendeds.All(t => !(t is TinaBaseCard)))
            {

                OriginalDamage = skill.TargetDamageView;
                ReminderDamage = OriginalDamage;

                //clog.w($"使用者为{this.BChar?.Info?.KeyData}");
                //TinaService.AddGrenadeCounter(this.BChar);
                if (HasMultiStage && this.BChar?.Info?.KeyData == TinaKeyWords.Tina)
                {
                    clog.tw($"本次伤害会触发多段伤害");
                    NowStageDamage = (int)(this.BChar.GetStat.atk * 0.01 * DamageThreshold);
                    clog.tw($"这一段伤害为{NowStageDamage}点");
                }

                while(HasNextStage)
                {
                    if (ReminderDamage < NowStageDamage) NowStageDamage = ReminderDamage;
                    clog.tw($"ReminderDamage:{ReminderDamage} NowStageDamage:{NowStageDamage}");
                    HasNextStage = ReminderDamage - NowStageDamage > 0;
                    clog.tw($"判断是否有下一段伤害:{HasNextStage}");

                    if (HasNextStage && this.BChar?.Info?.KeyData == TinaKeyWords.Tina)
                    {
                        clog.tw($"本次伤害有下一段伤害");
                        var skill0 = skill.CloneSkill();
                        var skill_Extended = Skill_Extended.DataToExtended(new GDESkillExtendedData(TinaKeyWords.Ex_TinaDamageLimiter)) as Ex_TinaDamageLimiter;
                        skill_Extended.LimitDamage = NowStageDamage;
                        skill0.ExtendedAdd(skill_Extended);
                        //TinaService.AddGrenadeCounter(this.BChar);
                        if (Targets == null || Targets.All(t => t.IsDead) || Targets.Count == 0)
                        {
                            BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill0, BattleSystem.instance.EnemyTeam.AliveChars.Random(), true, false, false, null));
                        }
                        else
                        {
                            BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill0, Targets.Random(), false, false, false, null));
                        }
                        ReminderDamage -= NowStageDamage;
                    }
                }
            }
        }

        public int PassiveCounter
        {
            get => passiveCounter;
            set
            {
                passiveCounter = value;
                var tips = new TranslationItem()
                {
                    
                    SimplifiedChinese = "补给。",
                    TraditionalChinese = "補給。",
                    English = "",
                    Japanese = "",
                    Korean = ""
                };
                
                if (passiveCounter >= SupplyThreshold0 && passiveCounter % SupplyThreshold0 == 0)
                {
                    clog.tw($"计数器记为：{passiveCounter}");
                    if (new Random().Next(0, 2) == 0)
                    {
                        var skill = Skill.TempSkill(TinaKeyWords.C_tina0, this.BChar, this.BChar.MyTeam);
                        skill.Disposable = true;
                        BattleSystem.instance.AllyTeam.Add(skill, false);
                    }
                    else
                    {
                        //紧急闪避
                        var skill = Skill.TempSkill(TinaKeyWords.C_tina3, this.BChar, this.BChar.MyTeam);
                        skill.Disposable = true;
                        BattleSystem.instance.AllyTeam.Add(skill, false);
                    }
                    EffectView.SimpleTextout(this.BChar.transform, tips.TransToLocalization, 1f, false, 1f);
                }
                if (passiveCounter >= SupplyThreshold1 && passiveCounter % SupplyThreshold1 == 0)
                {
                    clog.tw($"计数器记为：{passiveCounter}");
                    if (new Random().Next(0, 2) == 0)
                    {
                        var skill = Skill.TempSkill(TinaKeyWords.C_tina5, this.BChar, this.BChar.MyTeam);
                        skill.Disposable = true;
                        BattleSystem.instance.AllyTeam.Add(skill, false);
                    }
                    else
                    {
                        //急救包
                        var skill = Skill.TempSkill(TinaKeyWords.C_tina10, this.BChar, this.BChar.MyTeam);
                        skill.Disposable = true;
                        BattleSystem.instance.AllyTeam.Add(skill, false);
                    }
                    EffectView.SimpleTextout(this.BChar.transform, tips.TransToLocalization, 1f, false, 1f);
                }
                if (passiveCounter >= SupplyThreshold2 && passiveCounter % SupplyThreshold2 == 0)
                {
                    clog.tw($"计数器记为：{passiveCounter}");
                    if (new Random().Next(0, 2) == 0)
                    {
                        var skill = Skill.TempSkill(TinaKeyWords.C_tina6, this.BChar, this.BChar.MyTeam);
                        skill.Disposable = true;
                        BattleSystem.instance.AllyTeam.Add(skill, false);
                    }
                    else
                    {
                        var lucyskills = BattleSystem.instance.AllyTeam.ALLSKILLLIST.Where(t => t.Master == BattleSystem.instance.lucyM.LucyChar && t.MySkill.KeyID != "S_Transcendence_Main" && t.MySkill.User != "LucyCurse").Select(t => t.MySkill.KeyID).ToList();
                        var skill = Skill.TempSkill(lucyskills.Random(), this.BChar.MyTeam.LucyAlly, this.BChar.MyTeam);
                        skill.Disposable = true;
                        BattleSystem.instance.AllyTeam.Add(skill, false);
                    }
                    EffectView.SimpleTextout(this.BChar.transform, tips.TransToLocalization, 1f, false, 1f);
                }
            }
        }
        public int SupplyThreshold0 { get; set; } = 18;
        public int SupplyThreshold1 { get; set; } = 30;
        public int SupplyThreshold2 { get; set; } = 48;

        public void SkillUseAfter(Skill SkillD)
        {
            if (!SkillD.PlusHit && !(SkillD.IsDamage && SkillD.Master == this.BChar)) TinaService.AddPassiveCounter(this.BChar);
            if (SkillD.Master == this.BChar && SkillD.MySkill.KeyID != TinaKeyWords.C_tina4_0 && SkillD.MySkill.KeyID != TinaKeyWords.C_tina4_1)
            {
                BattleSystem.instance.CastSkills.RemoveAll(t => t.skill.MySkill.KeyID == TinaKeyWords.C_tina4);
                BattleSystem.instance.SaveSkill.RemoveAll(t => t.skill.MySkill.KeyID == TinaKeyWords.C_tina4);

                EventDispatcher.Dispatch(TinaEventKeys.SniperInterference);
            }
        }

        public void SKillUseHand_Team(Skill skill)
        {

        }

        public void BattleStart(BattleSystem Ins)
        {

            var exp = (int)ExpService.getExp().Obj;
            for (int i = 0; i < exp; i++)
                this.BChar.BuffAdd(TinaKeyWords.B_Abrasion, this.BChar);

            if (this.BChar.MyTeam.ALLSKILLLIST.Any(t => t.MySkill.KeyID != TinaKeyWords.CL_tina1 && t.Master == this.BChar && t.MySkill.Rare))
            {
                this.BChar.MyTeam.Skills.RemoveAll(t => t.MySkill.KeyID == TinaKeyWords.CL_tina1);
                this.BChar.MyTeam.ALLSKILLLIST.RemoveAll(t => t.MySkill.KeyID == TinaKeyWords.CL_tina1);
                this.BChar.MyTeam.Skills_Deck.RemoveAll(t => t.MySkill.KeyID == TinaKeyWords.CL_tina1);
                PlayData.TSavedata.LucySkills.RemoveAll(t => t == TinaKeyWords.CL_tina1);
            }

        }

        public void Turn1()
        {

        }

        public void TurnEnd()
        {
            if (!BuffStagingService.DataIsNull)
            {
                BuffStagingService.ReturnBuff();
                BuffStagingService.ClearData();
            }
        }

        public void BuffaddedAfter(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff, StackBuff stackBuff)
        {
            this.BChar.BuffRemove(GDEItemKeys.Buff_B_S3_Pope_P_2, true);
            this.BChar.BuffRemove(GDEItemKeys.Buff_B_PharosHighPriest_1_T_1, true);
            this.BChar.BuffRemove(GDEItemKeys.Buff_B_Butler_T_1, true);
        }

        public void BattleEnd()
        {
            if (!GlobalSetting.PositiveDevelop)
            {
                ExpService.AddExp();
                ExpService.PassiveDescCheckOutBattle();
            }
        }
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            ExpService.PassiveDescCheckOutBattle();
        }

        public void StageStart()
        {
            if (StageSystem.instance.Map.StageData.Key == GDEItemKeys.Stage_Stage1_1)
            {
                var tina = PlayData.TSavedata?.Party?.FirstOrDefault(t => t.KeyData == TinaKeyWords.Tina);
                if (tina != null)
                {
                    var facetina = UIManager.inst.CharstatUI.GetComponent<CharStatV4>().CharInfos.FirstOrDefault(t => t.AllyCharacter.Info.KeyData == TinaKeyWords.Tina);
                    facetina.Upgrade(true);
                    facetina.Upgrade(true);
                    facetina.Upgrade(true);
                    facetina.Upgrade(true);
                }
            }
        }

        public void Turn()
        {
            var mybasic = BattleSystem.instance.AllyTeam.Skills_Basic.FirstOrDefault(t => t.Master == this.BChar);

            if (mybasic == null) return;
            var whitelist = new List<string>(){
                TinaKeyWords.CL_tina0, TinaKeyWords.C_tina0
            };
            if ((this.BChar as BattleAlly).MyBasicSkill.CoolDownNum < 1 && whitelist.Contains(mybasic.MySkill.KeyID))
            {
                //CharacterService.RefreshBasicSkill(this.BChar, this.BChar.BattleBasicskillRefill);
                ClosersService.RefreshBasicSkill(this.BChar, mybasic);

                //if (mybasic.MySkill.KeyID == TinaKeyWords.CL_tina0) (this.BChar as BattleAlly).MyBasicSkill.SkillInput(skill2);
                //if(PlayData.TSavedata.LucySkills.Contains(TinaKeyWords.CL_tina0))
            }

        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (ThrottleService.CheckAvailable(TinaEventKeys.CL0APCheckinPassive))
            {
                ThrottleService.AddRegistrationMilliSeconds(TinaEventKeys.CL0APCheckinPassive, 500);
                //clog.tw($"tina被动换弹检查前，露西技能检查{PlayData.TSavedata.LucySkills.Any(t => t == TinaKeyWords.CL_tina0)}");
                //clog.tw($"tina被动换弹检查前，固定能力检查1{PlayData.TSavedata?.Party?.FirstOrDefault(t => t.KeyData == TinaKeyWords.Tina)?.BasicSkill?.KeyID}");
                //clog.tw($"tina被动换弹检查前，固定能力检查2{(TinaService.FindTinaInBattle() as BattleAlly).MyBasicSkill.buttonData.MySkill.KeyID != TinaKeyWords.CL_tina0}");
                if (PlayData.TSavedata.LucySkills.Any(t => t == TinaKeyWords.CL_tina0) && PlayData.TSavedata?.Party?.FirstOrDefault(t => t.KeyData == TinaKeyWords.Tina)?.BasicSkill?.SkillInfo.KeyID != TinaKeyWords.CL_tina0 && (TinaService.FindTinaInBattle() as BattleAlly).MyBasicSkill.buttonData.MySkill.KeyID!=TinaKeyWords.CL_tina0)
                {
                    clog.tw("tina被动换弹检查");
                    var tina = TinaService.FindTinaInInvest();
                    if (tina.KeyData == TinaKeyWords.Tina)
                    {
                        clog.tw("tina被动更换固定能力");
                        tina.BasicSkill = new CharInfoSkillData(TinaKeyWords.CL_tina0);
                        TinaService.FindTinaInBattle().BattleBasicskillRefill = Skill.TempSkill(TinaKeyWords.CL_tina0, this.BChar, this.BChar.MyTeam);
                        var skill = Skill.TempSkill(TinaKeyWords.CL_tina0, this.BChar, this.BChar.MyTeam);
                        skill.APChange = -1;
                        (TinaService.FindTinaInBattle() as BattleAlly).MyBasicSkill.SkillInput(skill);
                    }
                }
            }
        }
    }
}
