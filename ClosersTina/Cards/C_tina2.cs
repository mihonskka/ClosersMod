using ClosersFramework.Service;
using ClosersTina.KeyWords;
using ClosersTina.Models;
using ClosersTina.Services;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Cards
{
    public class C_tina2 : TinaBaseCard
    {
        public C_tina2():base(false)
        {
        
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            _Targets = Targets;
            base.SkillUseSingle(SkillD, Targets);

            List<Skill> list0 = new List<Skill>
            {
                Skill.TempSkill(TinaKeyWords.C_tina2_0, this.MySkill.Master, this.MySkill.Master.MyTeam),
                Skill.TempSkill(TinaKeyWords.C_tina2_1, this.MySkill.Master, this.MySkill.Master.MyTeam),
                Skill.TempSkill(TinaKeyWords.C_tina2_2, this.MySkill.Master, this.MySkill.Master.MyTeam),
                Skill.TempSkill(TinaKeyWords.C_tina2_3, this.MySkill.Master, this.MySkill.Master.MyTeam),
                Skill.TempSkill(TinaKeyWords.C_tina2_4, this.MySkill.Master, this.MySkill.Master.MyTeam)
            };
            //var firstskill = new List<Skill>() { list0.ElementAt(new Random().Next(list0.Count())) };
            var firstskill = new List<Skill>() { list0.NextRandom() };
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(firstskill, new SkillButton.SkillClickDel(this.Del0), ScriptLocalization.System_SkillSelect.EffectSelect, false, false, true, false, false));

            List<Skill> list = new List<Skill>
            {
                Skill.TempSkill(TinaKeyWords.C_tina2_0, this.MySkill.Master, this.MySkill.Master.MyTeam),
                Skill.TempSkill(TinaKeyWords.C_tina2_1, this.MySkill.Master, this.MySkill.Master.MyTeam),
                Skill.TempSkill(TinaKeyWords.C_tina2_2, this.MySkill.Master, this.MySkill.Master.MyTeam),
                Skill.TempSkill(TinaKeyWords.C_tina2_3, this.MySkill.Master, this.MySkill.Master.MyTeam),
                Skill.TempSkill(TinaKeyWords.C_tina2_4, this.MySkill.Master, this.MySkill.Master.MyTeam)
            };
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list.Where(t => !firstskill.Select(u=>u.MySkill.KeyID).Contains(t.MySkill.KeyID)).ToList(), new SkillButton.SkillClickDel(this.Del1), ScriptLocalization.System_SkillSelect.EffectSelect, false, false, true, false, false));
        }

        public SkillButton skill0 { get; set; }
        public string skill0Key { get; set; }

        public void Del0(SkillButton Mybutton)
        {
            Mybutton.Myskill.FreeUse = true;
            clog.tw($"Mybutton_KeyID：{Mybutton.Myskill.MySkill.KeyID}");
            skill0 = Mybutton;
            skill0Key = Mybutton.Myskill.MySkill.KeyID;
        }

        public void Del1(SkillButton Mybutton)
        {
            Mybutton.Myskill.FreeUse = true;
            clog.tw($"Mybutton_KeyID：{Mybutton.Myskill.MySkill.KeyID}");

            //BattleSystem.instance.CastEnqueue(_Targets.FirstOrDefault(), skill0.Myskill);
            //BattleSystem.instance.CastEnqueue(_Targets.FirstOrDefault(), Mybutton.Myskill);
            var s1 = Skill.TempSkill(skill0Key, this.BChar, this.BChar.MyTeam);
            var s2 = Skill.TempSkill(Mybutton.Myskill.MySkill.KeyID, this.BChar, this.BChar.MyTeam);

            try
            {
                (s1.AllExtendeds.FirstOrDefault(t => t is C_tina2_4) as C_tina2_4).SeniorAP = this.MySkill.AP;
                (s2.AllExtendeds.FirstOrDefault(t => t is C_tina2_4) as C_tina2_4).SeniorAP = this.MySkill.AP;
            }
            catch (Exception ex) { }

            clog.tw($"技能创建完毕s1{s1.MySkill.KeyID},s2{s2.MySkill.KeyID}");
            BattleSystem.DelayInput(BattleSystem.instance.ForceAction(s1, _Targets.FirstOrDefault(), false, false, false, null));
            BattleSystem.DelayInput(BattleSystem.instance.ForceAction(s2, _Targets.FirstOrDefault(), false, false, false, null));
        }

        public List<BattleChar> _Targets { get; set; } = new List<BattleChar>();
    }
    public class C_tina2_0 : TinaBaseCard
    {
        public C_tina2_0() : base()
        {
            this.AudioName = TinaKeyWords.Closers_Tina_Pistol_Audio;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            /*Targets.ForEach(t =>
            {
                BuffStagingService.AddRegistration(new BuffStagingUnit() { Buffs = t.Buffs.Select(u => new ClosersRegistBuff() { buffkey = u.BuffData.Key, remainTime = u.LifeTime }).ToList(), Owner = t as BattleEnemy });
                t.Buffs.Where(u => !u.BuffData.Debuff).ToList().ForEach(u => u.SelfDestroy());
                //t.Buffs.RemoveAll(u => !u.BuffData.Debuff);
            });*/
            base.SkillUseSingle(SkillD, Targets);
        }
        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            base.AttackEffectSingle(hit, SP, DMG, Heal);
            hit.BuffAdd(TinaKeyWords.B_tina2_0, this.BChar, true, 114514);
        }
    }
    public class C_tina2_1 : TinaBaseCard
    {
        public C_tina2_1() : base(false)
        {
            this.AudioName = TinaKeyWords.Closers_Tina_Shotgun_Audio;
        }
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            this.SkillBasePlus.Target_BaseDMG = 0;
            if (Target is BattleEnemy && (Target as BattleEnemy).istaunt)
            {
                Damage += BattleChar.CalculationResult(this.BChar.Info.get_stat.atk, 33, 0) + 1;
            }
            return base.DamageChange(SkillD, Target, Damage, ref Cri, View);
        }
        public override string ClosersDesc(string desc)
        {
            return base.ClosersDesc(desc).Replace("&a", ((int)Misc.PerToNum(this.BChar.GetStat.atk, 33f)).ToString()).ToString();
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaPistol, 4, this);
        }
    }
    public class C_tina2_2 : TinaBaseCard
    {
        public C_tina2_2() : base()
        {
            this.PlusStat.Penetration = 20;
            this.AudioName = TinaKeyWords.Closers_Tina_Rifle_Audio;
            this.ComboGapSecond = 0.05f;
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaShoot, 6, this);
        }
    }
    public class C_tina2_3 : TinaBaseCard
    {
        public C_tina2_3() : base()
        {
            this.DamageThreshold = 20;
            this.AudioName = TinaKeyWords.Closers_Tina_SubmachineGun5Combo_Audio;
            this.ComboGapSecond = 0;
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaBlade, 8, this);
        }
    }
    public class C_tina2_4 : TinaBaseCard
    {
        public C_tina2_4() : base(false)
        {
            this.OnePassive = true;
            this.AudioName = TinaKeyWords.Closers_Tina_Snipe_Audio;
            this.AudioForeSecond = 1f;
        }

        public int SeniorAP { get; set; }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            //if (BattleSystem.instance.AllyTeam.Skills_Deck.Count >= 0) BattleSystem.instance.StartCoroutine(BattleSystem.I_OtherSkillSelect(BattleSystem.instance.AllyTeam.Skills_Deck.Take(4).ToList(), new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.SkillPreView, false, true, true, false, false));
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaSniper, 4, this);
        }

        public override string ClosersDesc(string desc)
        {
            return base.ClosersDesc(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.3 + 1)).ToString());
        }

        public void Del(SkillButton Mybutton)
        {

        }

        public override int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            Damage = Damage + (int)(BattleSystem.instance.AllyTeam.Skills_Deck.Take(4).Count(t => t.AP == SeniorAP) * this.BChar.GetStat.atk * 0.3 + 1);
            return base.DamageChange(SkillD, Target, Damage, ref Cri, View);
        }
    }
}
