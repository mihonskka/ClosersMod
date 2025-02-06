using ClosersTina.KeyWords;
using ClosersTina.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Cards
{
    public class C_tina9:TinaBaseCard
    {
        public C_tina9():base(true,5,true)
        {
            this.AudioName = TinaKeyWords.Closers_Tina_MachineGun5Combo_Audio;
            this.ComboGapSecond = 0;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            var skill = Skill.TempSkill(TinaKeyWords.C_tina9_0, this.BChar, this.BChar.MyTeam);
            skill.AutoDelete = 1;
            this.BChar.MyTeam.Add(skill, false);
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaMachineGun, 3, this);
        }
    }

    public class C_tina9_0:TinaBaseCard,IP_TurnEnd
    {
        public C_tina9_0():base(false,0) { }

        public override void Init()
        {
            base.Init();
        }

        public void TurnEnd()
        {
            TinaService.AddOverheat(this.BChar, 7);
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaMachineGun0_, 1, this);
            base.SkillUseSingle(SkillD, Targets);
        }
    }
}
