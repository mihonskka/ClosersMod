using ClosersFramework.Templates;
using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.DebugItem
{
    public class PropDebugModeTestBattle: ClosersBaseActiveItem
    {
        public override bool Use()
        {
            FieldSystem.instance.BattleStart(new GDEEnemyQueueData(GDEItemKeys.EnemyQueue_Queue_TrialofStrength2), StageSystem.instance.StageData.BattleMap.Key, false, false, "", "", false);
            return base.Use();
        }
    }
}
