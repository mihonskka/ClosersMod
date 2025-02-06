using ClosersFramework.Data;
using ClosersFramework.Models;
using ClosersFramework.Service;
using ClosersFramework.Service.CodeManager;
using ClosersTina.Data;
using ClosersTina.KeyWords;
using ClosersTina.Models;
using ClosersTina.Services;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ClosersTina.Cards.C_tina4_1;

namespace ClosersTina.Cards
{
    public class C_tina4 : TinaBaseCard,IP_SkillCastingStart
    {
        public C_tina4():base(false) 
        {
            this.AudioForeSecond = 1f;
            this.AudioName = TinaKeyWords.Closers_Tina_Snipe_Audio;
        }
        
        #region 旧方案
        public class c4backup
        {
            public float Penetration { get; set; }
            public float CriRate { get; set; }
        }
        c4backup backup { get; set; }
        #endregion
        
        public override void Init()
        {
            base.Init();
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            EventDispatcher.AddAction(TinaEventKeys.SniperInterference, _ =>
            {
                if (BattleSystem.instance == null) return;
                BattleSystem.instance.ActWindow.CastingWaste(BattleSystem.instance.CastSkills.FirstOrDefault(t=>t.skill.CharinfoSkilldata.SkillInfo.KeyID==this.MySkill.MySkill.KeyID));
                BattleSystem.instance.SaveSkill.RemoveAll(cs => cs.skill == this.MySkill);
                BattleSystem.instance.CastSkills.RemoveAll(cs => cs.skill == this.MySkill);
                //BattleSystem.instance.EnemyCastSkills.RemoveAll(ecs => ecs.skill == c.skill);
                var tips = new TranslationItem()
                {
                    
                    SimplifiedChinese = "狙击被取消。",
                    TraditionalChinese = "狙擊被取消。",
                    English = "Cancelled.",
                    Japanese = "Cancelled。",
                    Korean = "취소。"
                };
                EffectView.SimpleTextout(this.BChar.transform, tips.TransToLocalization, 1f, false, 1f);
                EventDispatcher.RemoveAction(TinaEventKeys.SniperInterference);
            });
            Skill skill = Skill.TempSkill(TinaKeyWords.C_tina4_0, this.BChar, this.BChar.MyTeam);
            skill.NotCount = true;
            skill.isExcept = true;
            skill.AutoDelete = 1;
            this.BChar.MyTeam.Add(skill.CloneSkill(false, null, null, false), true);
            BattleSystem.instance.EnemyTeam.Chars.ForEach(t =>
            {
                if (t.IsDead || t == null) return;
                BuffStagingService.AddRegistration(new BuffStagingUnit() { Buffs = t.Buffs.Where(u => u.PlusStat.Vanish).Select(u => new ClosersRegistBuff() { buffkey = u.BuffData.Key, remainTime = u.LifeTime }).ToList(), Owner = t as BattleEnemy });
                t.Buffs.Where(u => !u.BuffData.Debuff && u.PlusStat.Vanish).ToList().ForEach(u => u.SelfDestroy());
                //t.Buffs.RemoveAll(u => u.PlusStat.Vanish);
            });
        }
        public List<Buff> TempArea = new List<Buff>();
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            //rollback
            /*this.Targets = Targets;
            if (BattleSystem.instance.AllyTeam.Skills_Deck.Count >= 0)
            {
                var tips = new TranslationItem()
                {
                    
                    SimplifiedChinese = "点击后继续。",
                    TraditionalChinese = "點擊後繼續。",
                    English = "Continue after click.",
                    Japanese = "マウスをクリックして続行。",
                    Korean = "마우스 클릭 후 계속。"
                };
                BattleSystem.instance.StartCoroutine(BattleSystem.I_OtherSkillSelect(BattleSystem.instance.AllyTeam.Skills_Deck.Take(4).ToList(), new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.SkillPreView+" "+tips.TransToLocalization, false, true, true, false, false));
            }
            else
            {
                Del(null);
            }*/

            
            #region 旧方案
            if (Targets.All(t => !t.Info.Ally))
            {
                //this.PlusSkillStat.Penetration = 100f;
                this.PlusSkillStat.cri = 100f;
            }
            else
            {
                this.PlusSkillStat.Penetration = backup.Penetration;
                this.PlusSkillStat.cri = backup.CriRate;
            }
            Targets.Where(t => !t.Info.Ally).ToList().ForEach(t =>
            {
                var e = t as BattleEnemy;
                if (e == null) return;
                e.SkillQueue.ForEach(c =>
                {
                    BattleSystem.instance.ActWindow.CastingWaste(c);
                    BattleSystem.instance.SaveSkill.RemoveAll(cs => cs.skill == c.skill);
                    BattleSystem.instance.CastSkills.RemoveAll(cs => cs.skill == c.skill);
                    BattleSystem.instance.EnemyCastSkills.RemoveAll(ecs => ecs.skill == c.skill);
                    var idle = new Skill();
                    idle.Init(new GDESkillData("S_Idle"));
                    c.skill = idle;
                    TurnResetInfo.NeedReloadEnemySkill = true;
                });
                e.SkillQueue.Clear();

            });
            base.SkillUseSingle(SkillD, Targets);
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaSniper, 4, this);

            EventDispatcher.RemoveAction(TinaEventKeys.SniperInterference);
            #endregion
        }
        public List<BattleChar> Targets { get; set; } = new List<BattleChar>();
        [NoReference]
        public void Del(SkillButton Mybutton)
        {
            var skill = Skill.TempSkill(TinaKeyWords.C_tina4_1, this.BChar, this.BChar.MyTeam);
            this.BChar.ParticleOut(this.MySkill, skill, Targets);
        }

        public override int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            //rollback
            //if(!View) return -114514;
            Damage = Damage + (int)(BattleSystem.instance.AllyTeam.Skills_Deck.Take(4).Count(t => t.AP <= this.MySkill.AP) * this.BChar.GetStat.atk * 0.5 + 1);
            return base.DamageChange(SkillD, Target, Damage, ref Cri, View);
        }

        public override string ClosersDesc(string desc)
        {
            return base.ClosersDesc(desc).Replace("&a", ((int)this.BChar.GetStat.atk * 0.5 + 1).ToString());
        }
    }

    public class C_tina4_1 : TinaBaseCard
    {
        public C_tina4_1() : base(false, 0)
        {
        }
        public class c4backup
        {
            public float Penetration { get; set; }
            public float CriRate { get; set; }
        }
        c4backup backup { get; set; }

        public override void Init()
        {
            base.Init();
            backup = new c4backup();
            backup.Penetration = this.PlusSkillStat.Penetration;
            backup.CriRate = this.PlusSkillStat.cri;
        }

        public override bool TargetHit(BattleChar Target)
        {
            //return base.TargetHit(Target);
            return base.TargetHit(Target) || Target.HP >= Target.GetStat.maxhp;
        }
        public List<Buff> TempArea = new List<Buff>();
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets.All(t => !t.Info.Ally))
            {
                this.PlusSkillStat.Penetration = 100f;
                this.PlusSkillStat.cri = 100f;
            }
            else
            {
                this.PlusSkillStat.Penetration = backup.Penetration;
                this.PlusSkillStat.cri = backup.CriRate;
            }

            Targets.Where(t => !t.Info.Ally).ToList().ForEach(t =>
            {
                var e = t as BattleEnemy;
                if (e == null) return;
                e.SkillQueue.ForEach(c =>
                {
                    BattleSystem.instance.ActWindow.CastingWaste(c);
                    BattleSystem.instance.SaveSkill.RemoveAll(cs => cs.skill == c.skill);
                    BattleSystem.instance.EnemyCastSkills.RemoveAll(cs => cs.skill == c.skill);
                });
                e.SkillQueue.Clear();

            });
            base.SkillUseSingle(SkillD, Targets);
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaSniper, 4, this);
        }
        public override int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            Damage = Damage + (int)(BattleSystem.instance.AllyTeam.Skills_Deck.Take(4).Count(t => t.AP <= this.MySkill.AP) * this.BChar.GetStat.atk * 0.5 + 1);
            return base.DamageChange(SkillD, Target, Damage, ref Cri, View);
        }
    }

    public class C_tina4_0 : TinaBaseCard
    {
        public C_tina4_0():base(false)
        {
            
        }


        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            var cs = BattleSystem.instance.CastSkills?.FirstOrDefault(t => t.skill.MySkill.KeyID == TinaKeyWords.C_tina4);
            if (SkillD.Master == this.BChar && cs != null)
            {
                BattleSystem.DelayInput(this.Wait());
                BattleSystem.DelayInput(this.Counter(cs));
            }
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaSniper0_, 0, this);
        }

        public IEnumerator Counter(CastingSkill CastingSkill)
        {
            //yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyCastingSkillUse(CastingSkill, false));
            BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyCastingSkillUse(CastingSkill, false));
            BattleSystem.instance.CastSkills.Remove(CastingSkill);
            BattleSystem.instance.SaveSkill.Remove(CastingSkill);
            yield return new WaitForSeconds(1.7f);
            BattleSystem.instance.ActWindow.On = true;
            yield return null;
            yield break;
        }
        public IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.5f);
            yield break;
        }
    }
}
