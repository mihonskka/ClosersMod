using ClosersFramework.Models.Interface;
using ClosersFramework.Service;
using ClosersFramework.Templates;
using ClosersTina.KeyWords;
using ClosersTina.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersTina.Cards
{
    /// <summary>
    /// reloading
    /// </summary>
    public class CL_tina0 : ClosersBaseCard, IP_BattleStart_Ones, ICharacterSoundsToken,IP_PlayerTurn
    {
        public BattleChar ComponentMaster => TinaService.FindTinaInBattle();

        public Vector3 ComponentCoordinate => new Vector3();

        public Transform ComponentTransform => null;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (ThrottleService.CheckAvailable(TinaEventKeys.CL0APCheck))
            {
                clog.tw("tina换弹检查");
                var tina = TinaService.FindTinaInInvest();
                ThrottleService.AddRegistrationMilliSeconds(TinaEventKeys.CL0APCheck, 500);
                if (this.MySkill.BasicSkill) (TinaService.FindTinaInBattle() as BattleAlly).MyBasicSkill.buttonData.ExtendedAdd(new Extended_Lucy_14_0());
				if (tina.KeyData == TinaKeyWords.Tina)
                {
                    clog.tw("tina更换固定能力");
                    tina.BasicSkill = this.MySkill.CharinfoSkilldata;
                    TinaService.FindTinaInBattle().BattleBasicskillRefill = this.MySkill;
                }
            }

        }

		public override string ClosersDesc(string desc)
        {
            return base.ClosersDesc(desc).Replace("&a", this.BChar.MyTeam.AliveChars.Count().ToString());
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (this.MySkill.BasicSkill)
                BattleSystem.DelayInputAfter(this.Effect());
            else
                this.BChar.MyTeam.DiscardCount += this.BChar.MyTeam.AliveChars.Count();
        }
        public IEnumerator Effect()
        {
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaReload, 2, this);
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills);
            int num = 0;
            foreach (Skill skill in list)
            {
                if (skill != this.MySkill)
                {
                    num++;
                    skill.Delete();
                }
            }
            for (int i = 0; i < num + 1; i++)
            {
                yield return BattleSystem.instance.StartCoroutine(this.BChar.MyTeam._Draw());
            }
            yield break;
        }
        public void BattleStart(BattleSystem Ins)
        {
            var tina = TinaService.FindTinaInBattle();
            if (tina != null)
            {
                (tina as BattleAlly).MyBasicSkill.SkillInput(this.MySkill.CharinfoSkilldata, tina, this.BChar.MyTeam);
                (tina as BattleAlly).BattleBasicskillRefill = this.MySkill;
            }
        }

        public void Turn()
        {
            var tina = TinaService.FindTinaInBattle();
            if (tina != null)
            {
                (tina as BattleAlly).MyBasicSkill.SkillInput(this.MySkill.CharinfoSkilldata, tina, this.BChar.MyTeam);
                (tina as BattleAlly).BattleBasicskillRefill = this.MySkill;
            }
        }
    }
}
