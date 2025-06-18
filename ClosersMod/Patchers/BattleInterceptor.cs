using ClosersFramework.Data;
using ClosersFramework.Services;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Patchers
{
    [HarmonyPatch(typeof(BattleSystem), "BattleEnd")]
    public class BattleEndInterceptor
    {
        public static List<Action> actions { get; set; } = new List<Action>();
        [HarmonyPrefix]
        public static void PreFix()
        {
            actions.ForEach(t => t());
            TurnResetInfo.NeedReloadEnemySkill = false;
        }
    }
}
