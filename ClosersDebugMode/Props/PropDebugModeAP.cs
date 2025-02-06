using ClosersFramework.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClosersDebugMode.Props
{
    public class PropDebugModeAP: ClosersBaseActiveItemEffect
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            BattleSystem.instance.AllyTeam.AP++;
        }
    }
    public class PropDebugModeAP0 : ClosersBaseActiveItem
    {
        public override bool Use()
        {
            BattleSystem.instance.AllyTeam.AP++;
            return base.Use();
        }
        /*public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
           
        }*/
    }
}
