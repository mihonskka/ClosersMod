using ClosersFramework.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.DebugItem
{
    public class PropDebugModeClear : ClosersBaseActiveItem
    {
        public override bool Use()
        {
            //FieldSystem.instance.ClearMap();
            StageSystem.instance.CanNextStage = true;
            return base.Use();
        }
    }

    public class PropDebugModeClearInBattle : ClosersBaseActiveItemEffect
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            BattleSystem.instance.EnemyTeam.AliveChars.ForEach(t => t.Dead(true, true));
        }
    }
}
