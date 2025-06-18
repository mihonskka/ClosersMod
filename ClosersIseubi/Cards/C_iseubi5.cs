using ClosersIseubi.Isouryoku;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.KeyWords;
using ClosersFramework.Services;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Services.Enum;

namespace ClosersIseubi.Cards
{
    public class C_iseubi5 : IseubiBaseCard
    {
        public C_iseubi5() : base(-1, true, false, CardType.Electrical)
        {
            if (BattleSystem.instance != null)
            {
                ThrottleService.Regist(ThrottleKeyWords.C5Chip, 500, () =>
                {
                    base.PlusChip = -BattleSystem.instance.EnemyTeam.AliveChars.Count + 1;
                });
            }
        }
        public override int PlusChipUpdate(int origin)
        {
            origin = -BattleSystem.instance.EnemyTeam.AliveChars.Count + 1;
            return base.PlusChipUpdate(origin);
        }

        public override string ClosersDesc(string desc)
        {
            if (BattleSystem.instance != null)
                desc = desc.Replace("&a", BattleSystem.instance.EnemyTeam.AliveChars.Count.ToString());
            else desc = desc.Replace("&a", "0");
            return base.ClosersDesc(desc);
        }

        public override void FixedUpdate()
        {
            if(BattleSystem.instance != null)
            {
                ThrottleService.Regist(ThrottleKeyWords.C5Chip, 500, () =>
                {
                    base.PlusChip = -BattleSystem.instance.EnemyTeam.AliveChars.Count + 1;
                });
            }
            base.FixedUpdate();
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            List<Skill> list = new List<Skill>
            {
                Skill.TempSkill(IseubiKeyWords.C_iseubi5_0, this.MySkill.Master, this.MySkill.Master.MyTeam),
                Skill.TempSkill(IseubiKeyWords.C_iseubi5_1, this.MySkill.Master, this.MySkill.Master.MyTeam)
            };
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, false, true, false, false));
            _Targets = Targets;
        }

        List<BattleChar> _Targets;

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.FreeUse = true;

            clog.iw($"이슬비：Mybutton_KeyID：{Mybutton.Myskill.MySkill.KeyID}");
            if (Mybutton.Myskill.MySkill.KeyID == IseubiKeyWords.C_iseubi5_0)
            {
                var skill = Skill.TempSkill(IseubiKeyWords.C_iseubi5_0, this.BChar, this.BChar.MyTeam);
                skill = EnforceAddService.AddEnforce(this.MySkill, skill);
                //skill = new Gravity().LV2_IgnoreDef(skill);
                this.BChar.ParticleOut(skill, _Targets);
                //BattleSystem.DelayInputAfter(BattleSystem.instance.SkillRandomUseIenum(this.BChar, Skill.TempSkill(KeyWords.C_iseubi6_0)));
            }
            if (Mybutton.Myskill.MySkill.KeyID == IseubiKeyWords.C_iseubi5_1)
            {
                var skill = Skill.TempSkill(IseubiKeyWords.C_iseubi5_1, this.BChar, this.BChar.MyTeam);
                skill = EnforceAddService.AddEnforce(this.MySkill, skill);
                //skill = new Gravity().LV2_IgnoreDef(skill);
                this.BChar.ParticleOut(skill, _Targets);
                //BattleSystem.DelayInputAfter(BattleSystem.instance.SkillRandomUseIenum(this.BChar, Skill.TempSkill(KeyWords.C_iseubi6_1)));
            }
            IseubiSoundService.RandomSound(IseubiKeyWords.V_ThunderForce, 1, this);
        }
    }

    public class C_iseubi5_0 : IseubiBaseCard
    {
        public C_iseubi5_0():base(0,false,false,CardType.Electrical) { }
    }
    public class C_iseubi5_1 : IseubiBaseCard
    {
        public C_iseubi5_1() : base(0, false, false, CardType.Electrical) { }
    }
}
