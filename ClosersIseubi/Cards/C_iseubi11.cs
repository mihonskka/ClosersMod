using ClosersIseubi.Extendeds;
using ClosersIseubi.Isouryoku;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.Services;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Services.Enum;
using ClosersFramework.Templates;
using UnityEngine;

namespace ClosersIseubi.Cards
{
    public class C_iseubi11 : IseubiBaseCard
    {
        public C_iseubi11() : base(0, true, false, CardType.Electrical)
        {
        }
        public override void SkillTargetSingle(List<Skill> Targets)
        {
            skill = Targets.FirstOrDefault();
            if (BattleSystem.instance.AllyTeam.ALLSKILLLIST.Find((Skill a) => a.CharinfoSkilldata == skill.CharinfoSkilldata) == null)
            {
                this.BChar.MyTeam.Skills.Remove(skill);
                IseubiService.addChipWithBuff(3, this.BChar);
                base.SkillTargetSingle(Targets);
                return;

            }
            if (skill.IsCreatedInBattle)
            {
                this.BChar.MyTeam.Skills.Remove(skill);
                IseubiService.addChipWithBuff(3, this.BChar);
                base.SkillTargetSingle(Targets);
                return;
            }
            var target = skill.CharinfoSkilldata.SkillInfo.Target;
            //clog.w($"千鸟刀-技能TargetKey为:{target.Key}");
            if (target.Key.ToLower() == "all_enemy" || target.Key.ToLower() == "enemy" || target.Key.ToLower() == "random_enemy")
            {
                Ex_iseubi11.Add(skill, skill.Master);
            }
            List<Skill> list = new List<Skill>
            {
                Skill.TempSkill(IseubiKeyWords.C_iseubi11_0, this.MySkill.Master, this.MySkill.Master.MyTeam),
                Skill.TempSkill(IseubiKeyWords.C_iseubi11_1, this.MySkill.Master, this.MySkill.Master.MyTeam)
            };
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, false, true, false, false));

            base.SkillTargetSingle(Targets);
        }
        Skill skill { get; set; }
        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.FreeUse = true;

            clog.iw($"이슬비：Mybutton_KeyID：{Mybutton.Myskill.MySkill.KeyID}");
            if (Mybutton.Myskill.MySkill.KeyID == IseubiKeyWords.C_iseubi11_0)
            {
                clog.iw($"千鸟刀-选择了向上");
                var index = this.BChar.MyTeam.Skills.IndexOf(skill);
                clog.iw($"千鸟刀-index:{index}");
                BattleSystem.DelayInputAfter(this.MoveUp(skill, index, index));
                //BattleSystem.DelayInputAfter(BattleSystem.instance.SkillRandomUseIenum(this.BChar, Skill.TempSkill(KeyWords.C_iseubi6_0)));
            }
            if (Mybutton.Myskill.MySkill.KeyID == IseubiKeyWords.C_iseubi11_1)
            {
                clog.iw($"千鸟刀-选择了向下");
                var index = this.BChar.MyTeam.Skills.IndexOf(skill);
                clog.iw($"千鸟刀-index:{index}");
                var count = this.BChar.MyTeam.Skills.Count;
                clog.iw($"千鸟刀-count:{count}");
                BattleSystem.DelayInputAfter(this.MoveDown(skill, index, count));
                //BattleSystem.DelayInputAfter(BattleSystem.instance.SkillRandomUseIenum(this.BChar, Skill.TempSkill(KeyWords.C_iseubi6_1)));
            }
        }

        public IEnumerator MoveUp(Skill Temp, int Originalpos, int MoveNum)
        {
            if (MoveNum > 0 && BattleSystem.instance.AllyTeam.Skills.Remove(Temp))
            {
                yield return BattleSystem.instance.ActAfter();
                int num = Originalpos - (MoveNum + 1);
                if (num <= -1)
                {
                    num = 0;
                }
                yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._Add(Temp, false, num));
            }
            yield break;
        }

        // Token: 0x06001385 RID: 4997 RVA: 0x0009619B File Offset: 0x0009439B
        public IEnumerator MoveDown(Skill Temp, int Originalpos, int MoveNum)
        {
            if (MoveNum > 0 && BattleSystem.instance.AllyTeam.Skills.Remove(Temp))
            {
                yield return BattleSystem.instance.ActAfter();
                int num = Originalpos + MoveNum;
                if (num >= BattleSystem.instance.AllyTeam.Skills.Count)
                {
                    num = BattleSystem.instance.AllyTeam.Skills.Count;
                }
                yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._Add(Temp, false, num));
            }
            yield break;
        }
    }

    public class C_iseubi11_0 : ClosersBaseCard
    {

    }
    public class C_iseubi11_1 : ClosersBaseCard
    {

    }
}

namespace ClosersIseubi.Extendeds
{
    public class Ex_iseubi11 : ClosersBaseExtend, IP_DeadAfter
    {
        public Ex_iseubi11()
        {
        }
        public static void Add(Skill skill, BattleChar User)
        {
            if (skill.ExtendedFind_DataName(IseubiKeyWords.Ex_iseubi11) == null)
            {
                Ex_iseubi11 myEx = Skill_Extended.DataToExtended(IseubiKeyWords.Ex_iseubi11) as Ex_iseubi11;
                myEx.MasterChar = User;
                skill.ExtendedAdd_Battle(myEx);
            }
        }
        public BattleChar MasterChar;
        public override void Init()
        {
            base.Init();
            //var target = this.MySkill.CharinfoSkilldata.Skill.Target;
            this.TargetBuff.Add(new BuffTag()
            {
                BuffData = new GDEBuffData(IseubiKeyWords.bec),
                User = this.BChar,
                PlusTagPer = 110
            });

        }

        public void DeadAfter()
        {
            if (this.MasterChar.IsDead)
            {
                this.SelfDestroy();
            }
        }
    }
}
