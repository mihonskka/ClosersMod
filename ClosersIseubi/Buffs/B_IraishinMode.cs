using ClosersIseubi.Isouryoku;
using ClosersIseubi.Service;
using ClosersIseubi.KeyWords;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using ClosersFramework.Models.Interface;
using ClosersFramework.Service;
using UnityEngine;
using ClosersFramework.Templates;

namespace ClosersIseubi.Buffs
{
    public class B_IraishinMode : ClosersBaseBuff, IP_Dodge, IP_BuffRemove, IP_BuffUpdate, IP_BuffAdd, ICharacterSoundsToken, IP_TurnEnd, IP_Discard
    {
        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff) => check();

        public void BuffUpdate(Buff MyBuff) => check();

        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char == this.BChar)
            {
                this.BChar.BuffAdd(IseubiKeyWords.birsm, this.BChar);
                IseubiSoundService.RandomSound(IseubiKeyWords.V_HitBack, 4, this);
                //this.PlusStat.PerfectDodge = false;
                //Task.Run(() => OffPD(this));
                attacker = SP.SkillData.Master;
                if (new Teleport().LV3() && this.BChar.MyTeam.Skills.Any(t => t.Master == this.BChar))
                {
                    this.BChar.MyTeam.Draw();
                    attacker = SP.SkillData.Master;
                    BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(
						SylviSkills, new SkillButton.SkillClickDel(this.SkillButton), ScriptLocalization.System_SkillSelect.UseSkillSelect, false, true, true, false, true));
                }
            }
        }

        public List<Skill> SylviSkills => this.BChar.MyTeam.Skills.Union(new List<Skill>() {
                        Skill.TempSkill(IseubiKeyWords.C_iseubi_Cancel, this.BChar, this.BChar.MyTeam)
                        })
                        .Where(t => t.Master == this.BChar && !SkillMemory.Contains(t)).ToList();
        public static List<Skill> SkillMemory { get; set; } = new List<Skill>();

		/*
        public async Task OffPD(Buff bim)
        {
            await Task.Delay(300);
            bim.PlusStat.PerfectDodge=false;
        }
        */

		BattleChar attacker { get; set; }=new BattleChar();
        public BattleChar ComponentMaster => this.BChar;

        public Vector3 ComponentCoordinate => new Vector3();

        public Transform ComponentTransform => null;

        public void SkillButton(SkillButton Mybutton)
        {
            Mybutton.Myskill.FreeUse = true;
            clog.iw($"이슬비：Mybutton_KeyID：{Mybutton.Myskill.MySkill.KeyID}");
            if (Mybutton.Myskill.MySkill.KeyID == IseubiKeyWords.C_iseubi_Cancel) return;
            SkillMemory.Add(Mybutton.Myskill);

			if (attacker == null || attacker.IsDead)
            {
                clog.iw($"进入防反执行，攻击者为{attacker.Info.KeyData}");
                BattleSystem.instance.StartCoroutine(BModeFA(Mybutton.Myskill, BattleSystem.instance.EnemyTeam.AliveChars.Random()));
            }
            else
            {
                clog.iw($"进入防反执行2，攻击者为{attacker.Info.KeyData}");
                BattleSystem.instance.StartCoroutine(BModeFA(Mybutton.Myskill, attacker));
            }
            //BattleSystem.instance.AllyTeam.Skills.FirstOrDefault(t => t == Mybutton.Myskill).Delete(true);
        }

        public IEnumerator BModeFA(Skill skill,BattleChar target)
        {
            clog.iw("进入防反动作执行");
            return BattleSystem.instance.ForceAction(skill, target, true, false, false, null);
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            check();
        }

        public void BuffRemove(BattleChar buffMaster, Buff buff)
        {
			check();
			SkillMemory = new List<Skill>();
		}

        void check()
        {
            if (new Teleport().LV1_IraishinMode())
            {
                decimal amount = (decimal)Math.Log(1.5 * this.StackNum) * (90 / ((decimal)Math.Log(9)));
                this.PlusStat.dod = (float)amount;
                this.PlusStat.RES_DOT = (float)amount;
                this.PlusStat.RES_CC = (float)amount;

                this.PlusStat.AggroPer = 20 * this.StackNum;
                this.PlusStat.Strength = true;
            }
            else
            {
                //clog.w($"目前虫洞穿梭倍率为{10 * this.StackNum}");
                this.PlusStat.dod = 10 * this.StackNum;
                this.PlusStat.RES_DOT = 10 * this.StackNum;
                this.PlusStat.RES_CC = 10 * this.StackNum;
                this.PlusStat.AggroPer = 0;
                this.PlusStat.Strength = false;
                
            }
        }

		public void TurnEnd()
		{
            SkillMemory = new List<Skill>();
		}

		public void Discard(bool Click, Skill skill, bool HandFullWaste)
		{
			SkillMemory.Add(skill);
		}



		/*public void Targeted(Skill SkillD, List<BattleChar> Targets)
        {
            //clog.w("虫洞穿梭测试中");
            if (new Teleport().LV1_IraishinMode() && this.StackNum >= 6 && new Random().Next(0, 2) == 0)
            {
                clog.w("触发六层额外闪避");
                this.PlusStat.PerfectDodge = true;
                return;
            }
            else if (new Teleport().LV1_IraishinMode() && this.StackNum >= 5 && new Random().Next(0, 10) == 0)
            {
                clog.w("触发五层额外闪避");
                this.PlusStat.PerfectDodge = true;
                return;
            }
            else
            {
                this.PlusStat.PerfectDodge = false;
            }
        }*/
	}
}
