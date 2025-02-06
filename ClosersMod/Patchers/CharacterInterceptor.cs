using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Patchers
{
    public static class CharacterInterceptorData
    {
        public static List<Func<Character, bool>> PassivePrivilegesList { get; set; } = new List<Func<Character, bool>>();
        public static List<Action<Passive_Char>> GetPassiveActions { get; set; } = new List<Action<Passive_Char>>();
    }

    [HarmonyPatch(typeof(Character), "Passive", MethodType.Getter)]
    public class PassiveInterceptorA
    {
        [HarmonyPostfix]
        public static void Postfix(Character __instance, ref Passive_Char __result)
        {
            var token = false;
            if (__result == null)
            {
                CharacterInterceptorData.PassivePrivilegesList.ForEach(x => token |= x.Invoke(__instance));
                if (token) __result = __instance._Passive;
            }

			foreach(var i in CharacterInterceptorData.GetPassiveActions)
            {
                i(__result);
            }

			/*
            var token = false;
            clog.iw("get_stat准备检测token");
            StatInterceptorData.PrivilegesList.ForEach(t => token |= t.Invoke(__instance));
            if (token) return;
            if (__result.dod > 80 && !__result.PerfectDodge) __result.dod = 80;*/
		}
    }
}
