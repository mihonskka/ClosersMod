using ClosersIseubi.KeyWords;
using ClosersFramework.KeyWords;
using ClosersFramework.Services;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Patchers
{
    /*
    [HarmonyPatch(typeof(Skill), "IsCreatedInBattle", MethodType.Getter)]
    public class SkillCheckInterceptors
    {
        [HarmonyPostfix]
        public static void PostFix(Skill __instance, ref bool __result)
        {
            clog.iw($"技能检查拦截器：技能属于{__instance.Master.Info.KeyData}");
            if (__instance.Master.Info.KeyData != IseubiKeyWords.Iseubi) return;
            clog.iw($"技能检查拦截器：技能标记：{__instance.ExtendedFind_DataName(IseubiKeyWords.CS_iseubi0) == null}");
            __result &= __instance.ExtendedFind_DataName(IseubiKeyWords.CS_iseubi0)==null;
            clog.iw($"技能检查拦截器：技能为{__instance.MySkill.Name}，结果{__result}");
        }
    }
    */
}
