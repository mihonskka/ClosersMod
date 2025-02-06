using ClosersFramework.Data;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Patchers
{
    public class TurnStartInterceptorData
    {
        public static List<Action> TurnStartActions = new List<Action>();
    }
    [HarmonyPatch(typeof(EnemyTeam), "MyTurn")]
    public class EnemyTeamTurnStartInterceptor
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            TurnStartInterceptorData.TurnStartActions.ForEach(a => a());

			
        }
    }
}
