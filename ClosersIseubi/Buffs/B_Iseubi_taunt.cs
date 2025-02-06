using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Buffs
{
    public class B_Iseubi_taunt : B_Taunt,IP_SkillUse_User, IP_Awake
    {
        public override void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets[0].Info.Ally != this.BChar.Info.Ally)
            {
                Targets.Clear();
                Targets.Add(base.Usestate_L);
            }
            base.SkillUse(SkillD, Targets);
        }
        public override void Init()
        {
            this.PlusStat.hit = -15;
            base.Init();
        }
    }
}
