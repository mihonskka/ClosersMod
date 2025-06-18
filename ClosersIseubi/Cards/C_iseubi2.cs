using ClosersIseubi.Extendeds;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.KeyWords;
using ClosersFramework.Services;
using GameDataEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ClosersFramework.Services.Enum;
using ClosersFramework.Templates;
using ClosersFramework.Data;

namespace ClosersIseubi.Cards
{
    public class C_iseubi2:IseubiBaseCard
    {
        public C_iseubi2():base(-15,true,false,CardType.Gravity,true)
        {
        }
        public override void Init()
        {
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
            base.Init();
        }

        public override string ClosersDesc(string desc)
        {
            int damage = 0;
            int count = 3;
            if (BattleSystem.instance != null)
            {
                damage = (int)((6 - IseubiService.GetChipNum(this.BChar))*2);
                count = 6 - BattleSystem.instance.EnemyTeam.AliveChars.Count;
                if (damage < 0) damage = 0;
                if (count < 3) count = 3;
            }
            return base.ClosersDesc(desc).Replace("&a",damage.ToString()).Replace("&b",count.ToString());
        }

        public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
        {
            Targets.ForEach(t => t.BuffRemove("Common_Buff_EnemyTaunt"));
            base.SkillUseSingleAfter(SkillD, Targets);
        }

        public override void SkillUseHandBefore()
        {
            if (!this.MySkill.PlusHit)
            {
                int chip = IseubiService.GetChipNum(this.BChar);
                if (chip < 6)
                {
                    this.BChar.Damage(this.BChar, (int)((6 - chip) * 2), false);
                }
            }
            base.SkillUseHandBefore();
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (!this.MySkill.PlusHit)
            {
                BattleSystem.DelayInputAfter(Useeffect2(Targets));
                if(this.allowDiscard)
                    BattleSystem.DelayInputAfter(Effect());
            }
                
        }
        public IEnumerator Effect()
        {
            int Temp = 1;
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills);
            int num;
            foreach (Skill skill in list)
            {
                if (skill != this.MySkill)
                {
                    num = Temp;
                    Temp = num + 1;
                    skill.Delete(false);
                }
            }
            for (int i = 0; i < Temp; i = num + 1)
            {
                yield return BattleSystem.instance.StartCoroutine(this.BChar.MyTeam._Draw(1, new BattleTeam.DrawInput(this.Drawinput)));
                num = i;
            }
            this.BChar.MyTeam.AP += 2;
            yield break;
        }
        public void Drawinput(Skill skill)
        {
            if (skill.MySkill.KeyID != IseubiKeyWords.C_iseubi2)
            {
                skill.ExtendedAdd(new Ex_iseubi2());
            }
        }

        public IEnumerator Useeffect2(List<BattleChar> Targets)
        {
            IseubiSoundService.RandomSound(IseubiKeyWords.V_GravityField, 3, this);
            clog.iw($"重力场-UEF2");
            var count = 6-Targets.Count;
            if (count < 3) count = 3;
            for(int i = 0; i < count; i++)
            {
                BattleSystem.DelayInput(this.Ienum(Targets));
            }
            BattleSystem.instance.CastSkills.RemoveAll(t => t.CastSpeed >= 5 && t.skill.Master is BattleEnemy);
            BattleSystem.instance.SaveSkill.RemoveAll(t => t.CastSpeed >= 5 && t.skill.Master is BattleEnemy);
            Targets.ForEach(t =>
            {
                clog.iw($"重力场-开始检索敌方技能队列施法速度");
                var TBE = t as BattleEnemy;
                var matchList = new List<string>();
                TBE?.SkillQueue?.ForEach(u =>
                {
                    clog.iw($"重力场-检索敌方技能队列施法速度，当前检索到的：{u?.CastSpeed}");
                    if (u.CastSpeed >= 5)
                    {
                        BattleSystem.instance.ActWindow.CastingWaste(u);
                        BattleSystem.instance.EnemyCastSkills.RemoveAll(ecs => ecs.skill == u.skill);
                        var idle = new Skill();
                        idle.Init(new GDESkillData("S_Idle"));
                        u.skill = idle;
                        TurnResetInfo.NeedReloadEnemySkill = true;
                    }
                });
                clog.iw($"重力场-敌方技能队列施法速度检索完毕");
                
                TBE?.SkillQueue?.RemoveAll(u => u.CastSpeed >= 5);
                
                //TBE?.SkillQueue?.RemoveAll(u => matchList.Contains(u));
                clog.iw($"重力场-清空敌方符合条件的技能队列元素");
            });
            IseubiService.addChip(Targets.Count * 2, this.BChar);
            yield return null;
            yield break;
        }

        public IEnumerator Ienum(List<BattleChar> Targets)
        {
            clog.iw($"重力场-Ienum");
            var skill = Skill.TempSkill(IseubiKeyWords.C_iseubi2, this.BChar, this.BChar.MyTeam);
            var skill_Extended = new Skill_Extended();
            skill_Extended.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.25);
            skill_Extended.PlusPerStat.Damage = -100;
            skill.ExtendedAdd(skill_Extended);
            var skill_Extended0 = DataToExtended("CS_iseubiPlusHit");
            skill.ExtendedAdd(skill_Extended0);
            skill = EnforceAddService.AddEnforce(this.MySkill, skill);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.NotCount = true;
            this.BChar.ParticleOut(this.MySkill, skill, Targets);
            yield return new WaitForFixedUpdate();
            yield break;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (ThrottleService.SearchRegistration(ThrottleKeyWords.C2Discard)?.isTimeout ?? true)
            {
                ThrottleService.AddRegistrationMilliSeconds(ThrottleKeyWords.C2Discard, 500);
                var lst = new List<string>();
                foreach (var i in this.BChar.MyTeam.Skills)
                {
                    lst.Add(i.MySkill.Name);
                }
                lst = lst.Distinct().ToList();
                if (lst.Count >= 6)
                {
                    allowDiscard = true;
                    this.SkillParticleOn();
                }
                else
                {
                    allowDiscard = false;
                    this.SkillParticleOff();
                }
            }
        }
        bool allowDiscard = false;
    }
}

namespace ClosersIseubi.Extendeds
{
    public class Ex_iseubi2 : ClosersBaseExtend
    {
        public override void Init()
        {
            base.Init();
            this.NotCount = true;
            var target = this.MySkill.CharinfoSkilldata.SkillInfo.Target;
            if (target.Key == "all_enemy" || target.Key == "enemy" || target.Key == "random_enemy")
            {
                clog.iw("检测到攻击技能，增加重力场增益");
                this.TargetBuff.Add(new BuffTag()
                {
                    BuffData = new GDEBuffData(IseubiKeyWords.B_Iseubi_grab),
                    User = this.BChar,
                    PlusTagPer = 100
                });
            }
        }
    }
}