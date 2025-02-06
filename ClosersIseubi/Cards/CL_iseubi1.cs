using ClosersIseubi.Buffs.BLL;
using ClosersIseubi.Isouryoku;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework;
using ClosersFramework.Models.Interface;
using ClosersFramework.Service;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ClosersFramework.Templates;

namespace ClosersIseubi.Cards
{
    public class CL_iseubi1 : ClosersBaseCard, ICharacterSoundsToken
    {
        public BattleChar ComponentMaster => IseubiService.FindIseubiInBattle();

        public Vector3 ComponentCoordinate => new Vector3();

        public Transform ComponentTransform => null;

        public override void Init()
        {
            if (GlobalSetting.Allin) this.NotCount = true;
            if(new Pluralism().LV5()) this.MySkill.Disposable = false;
            base.Init();
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.APChange = this.BChar.MyTeam.AliveChars.Sum(t => t.Overload);
        }

        public IEnumerator Draw()
        {
            clog.iw($"协同作战-准备抽卡");
            Skill skill2 = BattleSystem.instance.AllyTeam.Skills_Deck.FirstOrDefault(t=>t.Master==BattleSystem.instance.lucyM.LucyChar && t.MySkill.KeyID!= "S_Transcendence_Main" && t.MySkill.User!="LucyCurse");
            if (skill2 == null) BattleSystem.instance.AllyTeam.Draw();
            else
            {
                skill2.NotCount = true;
                yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._ForceDraw(skill2, null));
            }
            yield return null;
            yield break;
        }
        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            base.AttackEffectSingle(hit, SP, DMG, Heal);
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            BattleSystem.DelayInputAfter(this.Draw());
            BattleSystem.DelayInputAfter(this.Draw());
            List<Skill> list = new List<Skill>
            {
                Skill.TempSkill(IseubiKeyWords.CL_iseubi1_0, this.MySkill.Master, this.MySkill.Master.MyTeam),
                Skill.TempSkill(IseubiKeyWords.CL_iseubi1_1, this.MySkill.Master, this.MySkill.Master.MyTeam)
            };
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, false, true, false, false));
            _Targets = Targets;
        }
        List<BattleChar> _Targets;
        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.FreeUse = true;
            clog.iw($"이슬비：Mybutton_KeyID：{Mybutton.Myskill.MySkill.KeyID}");
            if (Mybutton.Myskill.MySkill.KeyID == IseubiKeyWords.CL_iseubi1_0)
            {
                this.BChar.ParticleOut(Skill.TempSkill(IseubiKeyWords.CL_iseubi1_0, this.BChar, this.BChar.MyTeam), _Targets);
                this.BChar.MyTeam.WaitCount += 1;
                if (IseubiService.FindIseubiInBattle() != null)
                    IseubiSoundService.RandomSound(IseubiKeyWords.V_L, 4, this);
            }
                
            if (Mybutton.Myskill.MySkill.KeyID == IseubiKeyWords.CL_iseubi1_1)
            {
                this.BChar.ParticleOut(Skill.TempSkill(IseubiKeyWords.CL_iseubi1_1, this.BChar, this.BChar.MyTeam), _Targets);
                this.BChar.MyTeam.DiscardCount += 1;
                if (IseubiService.FindIseubiInBattle() != null)
                    IseubiSoundService.RandomSound(IseubiKeyWords.V_L, 4, this);
            }
        }

        /*public override void FixedUpdate()
        {
            if (BattleSystem.instance != null)
            {
                if (ThrottleService.SearchRegistration(ThrottleKeyWords.CL1Checking)?.isTimeout ?? true)
                {
                    this.APChange = this.BChar.MyTeam.AliveChars.Sum(t => t.Overload);
                    ThrottleService.AddRegistrationMilliSeconds(ThrottleKeyWords.CL1Checking, 300);
                }
            }
            base.FixedUpdate();
        }*/

        ToolBox toolbox=new ToolBox();
    }
    public class CL_iseubi1_0 : ClosersBaseCard
    {

    }
    public class CL_iseubi1_1 : ClosersBaseCard
    {

    }
}
