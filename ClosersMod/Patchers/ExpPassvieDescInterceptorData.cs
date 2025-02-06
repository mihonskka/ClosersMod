using ClosersFramework.Patchers.Registration;
using ClosersFramework.Service;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseItem;

namespace ClosersFramework.Patchers
{
    public class ExpPassvieDescInterceptorData
    {
        public static List<ClosersPassiveDescCheck> lst { get; set; } = new List<ClosersPassiveDescCheck>();
    }
    [HarmonyPatch(typeof(BloodyMist), "IncreaseLevel")]
    public class Exp_BloodyMistInterceptor
    {
        [HarmonyPostfix]
        public static void Postfix(ref BloodyMist __instance)
        {
            clog.w("血雾升级检测发动！");
            ExpPassvieDescInterceptorData.lst.ForEach(t => t.NormalCheck());
        }
    }
    [HarmonyPatch(typeof(Camp), "NewPartyadd")]
    public class Exp_CampHireInterceptor
    {
        [HarmonyPostfix]
        public static void Postfix(ref Camp __instance)
        {
            clog.w("篝火雇佣加人检测 发动！");
            ExpPassvieDescInterceptorData.lst.ForEach(t => t.NormalCheck());
        }
    }
    [HarmonyPatch(typeof(CharacterWindow), "Upgrade")]
    public class Exp_UpgradeInterceptor
    {
        [HarmonyPostfix]
        public static void Postfix(ref CharacterWindow __instance)
        {
            clog.w("角色升级检测 发动！");
            ExpPassvieDescInterceptorData.lst.ForEach(t => t.NormalCheck());
        }
    }
    [HarmonyPatch(typeof(CharacterWindow), "ForgetSkillSet")]
    public class Exp_ForgetInterceptor
    {
        [HarmonyPostfix]
        public static void Postfix(ref CharacterWindow __instance)
        {
            clog.w("技能遗忘检测 发动！");
            ExpPassvieDescInterceptorData.lst.ForEach(t => t.NormalCheck());
        }
    }
    [HarmonyPatch(typeof(SkillBookCharacter_Rare), "SkillAdd")]
    public class Exp_RareBookInterceptor
    {
        [HarmonyPostfix]
        public static void Postfix(ref SkillBookCharacter_Rare __instance)
        {
            clog.w("黄金技能书检测 发动！");
            ExpPassvieDescInterceptorData.lst.ForEach(t => t.NormalCheck());
        }
    }
    [HarmonyPatch(typeof(SkillBookCharacter), "SkillAdd")]
    public class Exp_NormalBookInterceptor
    {
        [HarmonyPostfix]
        public static void Postfix(ref SkillBookCharacter __instance)
        {
            clog.w("技能书检测 发动！");
            ExpPassvieDescInterceptorData.lst.ForEach(t => t.NormalCheck());
        }
    }
    [HarmonyPatch(typeof(SkillBookInfinity), "SkillAdd")]
    public class Exp_InfinityBookInterceptor
    {
        [HarmonyPostfix]
        public static void Postfix(ref SkillBookInfinity __instance)
        {
            clog.w("无限技能书检测 发动！");
            ExpPassvieDescInterceptorData.lst.ForEach(t => t.NormalCheck());
        }
    }
    [HarmonyPatch(typeof(RE_BlackMarket), "CharSkillAdd")]
    public class Exp_BlackMarketInterceptor
    {
        [HarmonyPostfix]
        public static void Postfix(ref RE_BlackMarket __instance)
        {
            clog.w("黑市检测 发动！");
            ExpPassvieDescInterceptorData.lst.ForEach(t => t.NormalCheck());
        }
    }
    [HarmonyPatch(typeof(RE_ReaperStatue), "SkillGet")]
    public class Exp_ReaperStatueInterceptor
    {
        [HarmonyPostfix]
        public static void Postfix(ref RE_ReaperStatue __instance)
        {
            clog.w("死神像检测 发动！");
            ExpPassvieDescInterceptorData.lst.ForEach(t => t.NormalCheck());
        }
    }
    [HarmonyPatch(typeof(RE_SacrificeSkill), "ButtonDel")]
    public class Exp_SacrificeSkillInterceptor
    {
        [HarmonyPostfix]
        public static void Postfix(ref RE_SacrificeSkill __instance)
        {
            clog.w("芝士的牺牲检测 发动！");
            ExpPassvieDescInterceptorData.lst.ForEach(t => t.NormalCheck());
        }
    }
    [HarmonyPatch(typeof(CharacterCollection), "Init")]
    public class EncyclopediaInterceptorA
    {
        [HarmonyPostfix]
        public static void Postfix(ref CharacterCollection __instance)
        {
            clog.w("检测到开启图鉴，修正李瑟钰的被动能力描述！");
            foreach (var i in ExpPassvieDescInterceptorData.lst)
                i.ReplaceCheck(ref __instance);
        }
    }
    [HarmonyPatch(typeof(CharacterCollection), "CharacterInfoOff")]
    public class EncyclopediaInterceptorB
    {
        [HarmonyPostfix]
        public static void Postfix(ref CharacterCollection __instance)
        {
            clog.w("检测到关闭图鉴，回滚封印者被动能力描述！");
            foreach(var i in ExpPassvieDescInterceptorData.lst)
                i.Rollback(ref __instance);
        }
    }
    [HarmonyPatch(typeof(StartPartySelect), "Select")]
    public class StartPartySelectInterceptorA
    {
        [HarmonyPostfix]
        public static void Postfix(ref StartPartySelect __instance)
        {
            clog.w("检测到开启图鉴A，修正封印者被动能力描述！");
            foreach (var i in ExpPassvieDescInterceptorData.lst)
                i.ReplaceCheck(ref __instance);
        }
    }

    [HarmonyPatch(typeof(StartPartySelect), "Apply")]
    public class StartPartySelectInterceptorG
    {
        [HarmonyPostfix]
        public static void Postfix(ref StartPartySelect __instance)
        {
            clog.w("检测到关闭图鉴G，回滚李瑟钰的被动能力描述！");
            foreach (var i in ExpPassvieDescInterceptorData.lst)
                i.Rollback(ref __instance);
        }
    }
    [HarmonyPatch(typeof(StartPartySelect), "SpecialApply")]
    public class StartPartySelectInterceptorH
    {
        [HarmonyPostfix]
        public static void Postfix(ref StartPartySelect __instance)
        {
            clog.w("检测到关闭图鉴H，回滚李瑟钰的被动能力描述！");
            foreach (var i in ExpPassvieDescInterceptorData.lst)
                i.Rollback(ref __instance);
        }
    }
    [HarmonyPatch(typeof(StartPartySelect), "InfoView")]
    public class StartPartySelectInterceptorI
    {
        [HarmonyPostfix]
        public static void Postfix(ref StartPartySelect __instance)
        {
            clog.w("检测到开启图鉴I，修正李瑟钰的被动能力描述！");
            foreach (var i in ExpPassvieDescInterceptorData.lst)
                i.ReplaceCheck(ref __instance);
        }
    }
    [HarmonyPatch(typeof(StartPartySelect), "Init")]
    public class StartPartySelectInterceptorJ
    {
        [HarmonyPostfix]
        public static void Postfix(ref StartPartySelect __instance)
        {
            clog.w("检测到开启图鉴J，修正李瑟钰的被动能力描述！");
            foreach (var i in ExpPassvieDescInterceptorData.lst)
                i.ReplaceCheck(ref __instance);
        }
    }

    [HarmonyPatch(typeof(CharSelectMainUIV2), "Select")]
    public class CharSelectMainUIV2InterceptorA
    {
        [HarmonyPrefix]
        public static void Prefix(ref CharSelectMainUIV2 __instance)
        {
            clog.w("检测到开启图鉴CA，修正李瑟钰的被动能力描述！");
            foreach (var i in ExpPassvieDescInterceptorData.lst)
                i.ReplaceCheck(ref __instance);
        }
    }
    [HarmonyPatch(typeof(CharSelectMainUIV2), "ShowInfo")]
    public class CharSelectMainUIV2InterceptorB
    {
        [HarmonyPrefix]
        public static void Prefix(ref CharSelectMainUIV2 __instance)
        {
            clog.w("检测到开启图鉴CB，修正李瑟钰的被动能力描述！");
            foreach (var i in ExpPassvieDescInterceptorData.lst)
                i.ReplaceCheck(ref __instance);
        }
    }
    [HarmonyPatch(typeof(CharSelectMainUIV2), "Apply")]
    public class CharSelectMainUIV2InterceptorC
    {
        [HarmonyPostfix]
        public static void Postfix(ref CharSelectMainUIV2 __instance)
        {
            clog.w("检测到关闭图鉴CC，回滚李瑟钰的被动能力描述！");
            foreach (var i in ExpPassvieDescInterceptorData.lst)
                i.Rollback(ref __instance);
        }
    }
    [HarmonyPatch(typeof(CharSelectMainUIV2), "SpecialApply")]
    public class CharSelectMainUIV2InterceptorD
    {
        [HarmonyPostfix]
        public static void Postfix(ref CharSelectMainUIV2 __instance)
        {
            clog.iw("检测到关闭图鉴CD，回滚李瑟钰的被动能力描述！");
            foreach (var i in ExpPassvieDescInterceptorData.lst)
                i.Rollback(ref __instance);
        }
    }
}
