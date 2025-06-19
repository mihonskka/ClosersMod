using ClosersFramework.Models.Interface;
using ClosersFramework.Services;
using ClosersFramework.Templates;
using ClosersTina.KeyWords;
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
using static BattleChar;
using static System.Net.Mime.MediaTypeNames;

namespace ClosersTina.Cards
{
    /// <summary>
    /// 协同作战
    /// </summary>
    public class CL_tina1 : ClosersBaseCard
    {
        public BattleChar user => TinaService.FindTinaInBattle() ?? this.BChar ?? BattleSystem.instance.AllyTeam.AliveChars.FirstOrDefault(t => t.Info.KeyData == "Iseubi") ?? BattleSystem.instance.AllyTeam.AliveChars.FirstOrDefault();
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            clog.tw($"使用协同作战");
            List<Skill> list = new List<Skill>
            {
                Skill.TempSkill(TinaKeyWords.CL_tina1_0, user, this.MySkill.Master.MyTeam),
                Skill.TempSkill(TinaKeyWords.CL_tina1_1, user, this.MySkill.Master.MyTeam),
                Skill.TempSkill(TinaKeyWords.CL_tina1_2, user, this.MySkill.Master.MyTeam),
                Skill.TempSkill(TinaKeyWords.CL_tina1_3, user, this.MySkill.Master.MyTeam)
            };
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, false, true, false, false));
            _Targets = Targets;
        }
        List<BattleChar> _Targets;

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.FreeUse = true;
            clog.tw($"Mybutton_KeyID：{Mybutton.Myskill.MySkill.KeyID}, master:{user.Info.Name}");
            if (Mybutton.Myskill.MySkill.KeyID == TinaKeyWords.CL_tina1_0)
            {
                this.BChar.MyTeam.AP++;
                //user.ParticleOut(Skill.TempSkill(TinaKeyWords.CL_tina1_0, user, this.BChar.MyTeam), BattleSystem.instance.EnemyTeam.AliveChars.FirstOrDefault(t => t.HP == BattleSystem.instance.EnemyTeam.AliveChars.Select(u => u.HP).Min()));
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(Skill.TempSkill(TinaKeyWords.CL_tina1_0, TinaService.FindTinaInBattle() ?? this.BChar, this.BChar.MyTeam), BattleSystem.instance.EnemyTeam.AliveChars.FirstOrDefault(t => t.HP == BattleSystem.instance.EnemyTeam.AliveChars.Select(u => u.HP).Min()), false, false, false));
            }

            if (Mybutton.Myskill.MySkill.KeyID == TinaKeyWords.CL_tina1_1)
            {
                this.BChar.MyTeam.WaitCount++;
                this.BChar.MyTeam.partybarrier.BarrierHP += this.BChar.MyTeam.Chars.Sum(t => t.GetStat.maxhp) / 4 + 1;
                if (this.BChar.MyTeam.AliveChars.All(t => t.Info.GetData.Role.Key != "Role_Tank")) this.BChar.MyTeam.AliveChars.ForEach(t => t.BuffAdd(TinaKeyWords.B_DefendSignal, this.BChar));
                user.ParticleOut(Skill.TempSkill(TinaKeyWords.CL_tina1_1, user, this.BChar.MyTeam), this.BChar.MyTeam.AliveChars);
            }

            if (Mybutton.Myskill.MySkill.KeyID == TinaKeyWords.CL_tina1_2)
            {
                this.BChar.MyTeam.DiscardCount++;
                var healnum = user.GetStat.reg;
                if (healnum < 15) healnum = 15;
                this.BChar.MyTeam.AliveChars.ForEach(t => t.Heal(user, healnum, false));
                if (this.BChar.MyTeam.AliveChars.All(t => t.Info.GetData.Role.Key != "Role_Support") && TinaService.FindTinaInBattle()!=null)
                {
                    var skill = Skill.TempSkill(TinaKeyWords.C_tina10, user, this.BChar.MyTeam);
                    var skill0 = Skill.TempSkill(TinaKeyWords.C_tina10, user, this.BChar.MyTeam);
                    this.BChar.MyTeam.Add(skill, true);
                    this.BChar.MyTeam.Add(skill0, true);
                }
                else
                {
                    BattleSystem.DelayInputAfter(this.DrawHeal());
                    BattleSystem.DelayInputAfter(this.DrawHeal());
                }
                //user.ParticleOut(Skill.TempSkill(TinaKeyWords.CL_tina1_2, user, this.BChar.MyTeam), this.BChar.MyTeam.AliveChars);
            }

            if (Mybutton.Myskill.MySkill.KeyID == TinaKeyWords.CL_tina1_3)
            {
                BattleSystem.DelayInputAfter(this.DrawLucy());
                BattleSystem.DelayInputAfter(this.DrawLucy());
                //BattleSystem.instance.AllyTeam.LucyAlly.BuffAdd(TinaKeyWords.B_SupplySignal, this.BChar);
                user.ParticleOut(Skill.TempSkill(TinaKeyWords.CL_tina1_3, user, this.BChar.MyTeam), new List<BattleChar>());
            }

        }
        public IEnumerator DrawHeal()
        {
            var skill = BattleSystem.instance.AllyTeam.Skills_Deck.FirstOrDefault(t => t.IsHeal);
            if (skill == null) BattleSystem.instance.AllyTeam.Draw();
            else yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._ForceDraw(skill, null));
            yield return null;
            yield break;
        }
        public IEnumerator DrawLucy()
        {
            clog.tw($"协同作战-准备抽卡");
            Skill skill2 = BattleSystem.instance.AllyTeam.Skills_Deck.FirstOrDefault(t => t.Master == BattleSystem.instance.lucyM.LucyChar && t.MySkill.KeyID != "S_Transcendence_Main" && t.MySkill.User != "LucyCurse");
            if (skill2 == null) BattleSystem.instance.AllyTeam.Draw();
            else
            {
                skill2.NotCount = true;
                yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._ForceDraw(skill2, null));
            }
            yield return null;
            yield break;
        }
    }

    /// <summary>
    /// 进攻信号
    /// </summary>
    public class CL_tina1_0 : ClosersBaseCard, ICharacterSoundsToken, IP_DamageChange
    {
        public BattleChar ComponentMaster => TinaService.FindTinaInBattle();

        public Vector3 ComponentCoordinate => new Vector3();

        public Transform ComponentTransform => null;
        public override string ClosersDesc(string desc)
        {
            return base.ClosersDesc(desc).Replace("&a", TinaService.FindTinaInInvest()?.get_stat.atk.ToString() ?? "14");
        }

		public override void SkillUseHand(BattleChar Target)
        {
            base.SkillUseHand(Target);
        }
        public override bool TargetHit(BattleChar Target) => Target.HP <= Target.GetStat.maxhp * 0.5 || base.TargetHit(Target);
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            TinaService.SwitchWeapon(TinaWeapons.Snipe);

			TinaSoundService.RandomSound(TinaKeyWords.V_TinaL, 7, this);
            if (Targets.Any(t=>t.HP <= t.GetStat.maxhp * 0.5))
            {
                this.PlusStat.cri = 500;

            }
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (Damage <= this.BChar.GetStat.atk) Damage = (int)this.BChar.GetStat.atk + 1;
            if (Damage < 14) Damage = 14;
            if (Target.HP <= Target.GetStat.maxhp * 0.5)
            {
                Cri = true;
            }
            return Damage;
        }
    }
    /// <summary>
    /// 防守信号
    /// </summary>
    public class CL_tina1_1 : ClosersBaseCard, ICharacterSoundsToken
    {
        public BattleChar ComponentMaster => TinaService.FindTinaInBattle();

        public Vector3 ComponentCoordinate => new Vector3();

        public Transform ComponentTransform => null;

        public override string ClosersDesc(string desc)
        {
            return base.ClosersDesc(desc).Replace("&a", (this.BChar?.MyTeam?.Chars.Sum(t => t.GetStat.maxhp) / 4 + 1).ToString() ?? "5");
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaL, 7, this);
        }
    }
    /// <summary>
    /// 急救信号
    /// </summary>
    public class CL_tina1_2 : ClosersBaseCard, ICharacterSoundsToken
    {
        public BattleChar ComponentMaster => TinaService.FindTinaInBattle();

        public Vector3 ComponentCoordinate => new Vector3();

        public Transform ComponentTransform => null;

        public BattleChar user => TinaService.FindTinaInBattle() ?? BattleSystem.instance?.AllyTeam?.LucyChar ?? BattleSystem.instance?.AllyTeam?.AliveChars?.FirstOrDefault(t => t.Info.KeyData == "Iseubi") ?? BattleSystem.instance?.AllyTeam?.AliveChars?.FirstOrDefault();

        public override string ClosersDesc(string desc)
        {
            var i = Math.Ceiling((decimal)(user?.GetStat.reg ?? 11 * 1.4));
            if (i < 15) i = 15;
            return base.ClosersDesc(desc).Replace("&a", i.ToString() ?? "15");
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaL, 7, this);
        }
        public override void BeforeHeal(BattleChar hit, SkillParticle SP, float Heal, bool Cri)
        {
            if (Heal <= user.GetStat.reg * 1.4) Heal = (float)(user.GetStat.reg * 1.4);
            if (Heal <= 15) Heal = 15;
            base.BeforeHeal(hit, SP, Heal, Cri);
        }
    }
    /// <summary>
    /// 补给信号
    /// </summary>
    public class CL_tina1_3 : ClosersBaseCard, ICharacterSoundsToken
    {
        public BattleChar ComponentMaster => TinaService.FindTinaInBattle();

        public Vector3 ComponentCoordinate => new Vector3();

        public Transform ComponentTransform => null;

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaL, 7, this);
        }
    }
}
