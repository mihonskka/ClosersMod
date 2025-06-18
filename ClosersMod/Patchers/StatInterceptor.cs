using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosersFramework.KeyWords;
using ClosersFramework.Services;

namespace ClosersFramework.Patchers
{
    public static class StatInterceptorData
    {
        public static List<Func<Character, bool>> DodgePrivilegesList { get; set; } = new List<Func<Character, bool>>();
    }
    
    [HarmonyPatch(typeof(Character), "StatC")]
    public class StatInterceptorA
    {
        [HarmonyPostfix]
        public static void Postfix(Character __instance, ref Stat inputstat, ref Stat __result)
        {
            if(!inputstat.PerfectDodge && !__result.PerfectDodge)__result.dod = inputstat.dod;
            var token = false;
            //clog.iw($"StatC准备检测token，列表数量{StatInterceptorData.PrivilegesList.Count}");
            StatInterceptorData.DodgePrivilegesList.ForEach(t => token |= t.Invoke(__instance));
            if (token) return;
            if (__result.dod > 80 && !__result.PerfectDodge) __result.dod = 80;
        }
    }

    [HarmonyPatch(typeof(Character), "get_stat", MethodType.Getter)]
    public class StatInterceptorB
    {
        [HarmonyPostfix]
        public static void Postfix(Character __instance, ref Stat __result)
        {
            /*
            var token = false;
            clog.iw("get_stat准备检测token");
            StatInterceptorData.PrivilegesList.ForEach(t => token |= t.Invoke(__instance));
            if (token) return;
            if (__result.dod > 80 && !__result.PerfectDodge) __result.dod = 80;*/
        }
    }
}
