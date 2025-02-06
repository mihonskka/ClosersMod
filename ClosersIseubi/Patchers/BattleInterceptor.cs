using ClosersFramework.Service;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersIseubi.Patchers
{
    [HarmonyPatch(typeof(BattleTeam), "UsedDeckToDeck")]
    public class ShuffleInterceptor
    {
        [HarmonyPostfix]
        public static void Postfix(ref BattleTeam __instance)
        {
            //clog.w("检测到洗牌，发送通知！");
            
        }
    }
}
