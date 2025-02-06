using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.KeyWords;
using ClosersFramework.Service;
using GameDataEditor;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Patchers
{
    [HarmonyPatch(typeof(CharacterCollection), "Init")]
    public class EncyclopediaInterceptorA
    {
        [HarmonyPostfix]
        public static void Postfix(ref CharacterCollection __instance)
        {
            clog.iw("检测到开启图鉴，修正李瑟钰的被动能力描述！");
            var iseubi = __instance.CharacterList.FirstOrDefault(t => t.Key == IseubiKeyWords.Iseubi);
            if(iseubi != null) iseubi.PassiveDes = iseubi?.PassiveDes.Signal2Real();
        }
    }
    [HarmonyPatch(typeof(CharacterCollection), "CharacterInfoOff")]
    public class EncyclopediaInterceptorB
    {
        [HarmonyPostfix]
        public static void Postfix(ref CharacterCollection __instance)
        {
            clog.iw("检测到关闭图鉴，回滚李瑟钰的被动能力描述！");
            var iseubi = __instance.CharacterList.FirstOrDefault(t => t.Key == IseubiKeyWords.Iseubi);
            if (iseubi != null) iseubi.PassiveDes = iseubi?.PassiveDes.Real2Signal();
        }
    }
    [HarmonyPatch(typeof(StartPartySelect), "Select")]
    public class StartPartySelectInterceptorA
    {
        [HarmonyPostfix]
        public static void Postfix(ref StartPartySelect __instance)
        {
            clog.iw("检测到开启图鉴A，修正李瑟钰的被动能力描述！");
            var iseubi = __instance.Chars.FirstOrDefault(t => t.Key == IseubiKeyWords.Iseubi);
            if (iseubi != null) iseubi.PassiveDes = iseubi?.PassiveDes.Signal2Real();
        }
    }
    /*
    [HarmonyPatch(typeof(StartPartySelect), "ExitButton")]
    public class StartPartySelectInterceptorB
    {
        [HarmonyPostfix]
        public static void Postfix(ref CharacterCollection __instance)
        {
            clog.w("检测到关闭图鉴，回滚李瑟钰的被动能力描述！");
            var iseubi = __instance.CharacterList.FirstOrDefault(t => t.Key == KeyWords.Iseubi);
            iseubi.PassiveDes = iseubi.PassiveDes.Replace("Pluralism", "&sect").Replace("0", "&exp");
        }
    }
    [HarmonyPatch(typeof(StartPartySelect), "OriginNExitButton")]
    public class StartPartySelectInterceptorC
    {
        [HarmonyPostfix]
        public static void Postfix(ref CharacterCollection __instance)
        {
            clog.w("检测到关闭图鉴，回滚李瑟钰的被动能力描述！");
            var iseubi = __instance.CharacterList.FirstOrDefault(t => t.Key == KeyWords.Iseubi);
            iseubi.PassiveDes = iseubi.PassiveDes.Replace("Pluralism", "&sect").Replace("0", "&exp");
        }
    }
    [HarmonyPatch(typeof(StartPartySelect), "OriginExitButton")]
    public class StartPartySelectInterceptorD
    {
        [HarmonyPostfix]
        public static void Postfix(ref CharacterCollection __instance)
        {
            clog.w("检测到关闭图鉴，回滚李瑟钰的被动能力描述！");
            var iseubi = __instance.CharacterList.FirstOrDefault(t => t.Key == KeyWords.Iseubi);
            iseubi.PassiveDes = iseubi.PassiveDes.Replace("Pluralism", "&sect").Replace("0", "&exp");
        }
    }
    [HarmonyPatch(typeof(StartPartySelect), "OriginNEnter")]
    public class StartPartySelectInterceptorE   
    {
        [HarmonyPostfix]
        public static void Postfix(ref CharacterCollection __instance)
        {
            clog.w("检测到关闭图鉴，回滚李瑟钰的被动能力描述！");
            var iseubi = __instance.CharacterList.FirstOrDefault(t => t.Key == KeyWords.Iseubi);
            iseubi.PassiveDes = iseubi.PassiveDes.Replace("Pluralism", "&sect").Replace("0", "&exp");
        }
    }
    [HarmonyPatch(typeof(StartPartySelect), "OriginEnter")]
    public class StartPartySelectInterceptorF
    {
        [HarmonyPostfix]
        public static void Postfix(ref CharacterCollection __instance)
        {
            clog.w("检测到关闭图鉴，回滚李瑟钰的被动能力描述！");
            var iseubi = __instance.CharacterList.FirstOrDefault(t => t.Key == KeyWords.Iseubi);
            iseubi.PassiveDes = iseubi.PassiveDes.Replace("Pluralism", "&sect").Replace("0", "&exp");
        }
    }*/
    [HarmonyPatch(typeof(StartPartySelect), "Apply")]
    public class StartPartySelectInterceptorG
    {
        [HarmonyPostfix]
        public static void Postfix(ref StartPartySelect __instance)
        {
            clog.iw("检测到关闭图鉴G，回滚李瑟钰的被动能力描述！");
            var iseubi = __instance.Chars.FirstOrDefault(t => t.Key == IseubiKeyWords.Iseubi);
            if (iseubi != null) iseubi.PassiveDes = iseubi?.PassiveDes.Real2Signal();
        }
    }
    [HarmonyPatch(typeof(StartPartySelect), "SpecialApply")]
    public class StartPartySelectInterceptorH
    {
        [HarmonyPostfix]
        public static void Postfix(ref StartPartySelect __instance)
        {
            clog.iw("检测到关闭图鉴H，回滚李瑟钰的被动能力描述！");
            var iseubi = __instance.Chars.FirstOrDefault(t => t.Key == IseubiKeyWords.Iseubi);
            if (iseubi != null) iseubi.PassiveDes = iseubi?.PassiveDes.Real2Signal();
        }
    }
    [HarmonyPatch(typeof(StartPartySelect), "InfoView")]
    public class StartPartySelectInterceptorI
    {
        [HarmonyPostfix]
        public static void Postfix(ref StartPartySelect __instance)
        {
            clog.iw("检测到开启图鉴I，修正李瑟钰的被动能力描述！");
            var iseubi = __instance.Chars.FirstOrDefault(t => t.Key == IseubiKeyWords.Iseubi);
            if (iseubi != null) iseubi.PassiveDes = iseubi?.PassiveDes.Signal2Real();
        }
    }
    [HarmonyPatch(typeof(StartPartySelect), "Init")]
    public class StartPartySelectInterceptorJ
    {
        [HarmonyPostfix]
        public static void Postfix(ref StartPartySelect __instance)
        {
            clog.iw("检测到开启图鉴J，修正李瑟钰的被动能力描述！");
            var iseubi = __instance.Chars.FirstOrDefault(t => t.Key == IseubiKeyWords.Iseubi);
            if (iseubi != null) iseubi.PassiveDes = iseubi?.PassiveDes.Signal2Real();
        }
    }

    [HarmonyPatch(typeof(CharSelectMainUIV2), "Select")]
    public class CharSelectMainUIV2InterceptorA
    {
        [HarmonyPrefix]
        public static void Prefix(ref CharSelectMainUIV2 __instance)
        {
            clog.iw("检测到开启图鉴CA，修正李瑟钰的被动能力描述！");
            var iseubi = __instance.CharDatas.FirstOrDefault(t => t.Key == IseubiKeyWords.Iseubi);
            if (iseubi != null) iseubi.PassiveDes = iseubi?.PassiveDes.Signal2Real();
        }
    }
    [HarmonyPatch(typeof(CharSelectMainUIV2), "ShowInfo")]
    public class CharSelectMainUIV2InterceptorB
    {
        [HarmonyPrefix]
        public static void Prefix(ref CharSelectMainUIV2 __instance)
        {
            clog.iw("检测到开启图鉴CB，修正李瑟钰的被动能力描述！");
            var iseubi = __instance.CharDatas.FirstOrDefault(t => t.Key == IseubiKeyWords.Iseubi);
            if (iseubi != null) iseubi.PassiveDes = iseubi?.PassiveDes.Signal2Real();
        }
    }
    [HarmonyPatch(typeof(CharSelectMainUIV2), "Apply")]
    public class CharSelectMainUIV2InterceptorC
    {
        [HarmonyPostfix]
        public static void Postfix(ref CharSelectMainUIV2 __instance)
        {
            clog.iw("检测到关闭图鉴CC，回滚李瑟钰的被动能力描述！");
            var iseubi = __instance.CharDatas.FirstOrDefault(t => t.Key == IseubiKeyWords.Iseubi);
            if (iseubi != null) iseubi.PassiveDes = iseubi?.PassiveDes.Real2Signal();
        }
    }
    [HarmonyPatch(typeof(CharSelectMainUIV2), "SpecialApply")]
    public class CharSelectMainUIV2InterceptorD
    {
        [HarmonyPostfix]
        public static void Postfix(ref CharSelectMainUIV2 __instance)
        {
            clog.iw("检测到关闭图鉴CD，回滚李瑟钰的被动能力描述！");
            var iseubi = __instance.CharDatas.FirstOrDefault(t => t.Key == IseubiKeyWords.Iseubi);
            if (iseubi != null) iseubi.PassiveDes = iseubi?.PassiveDes.Real2Signal();
        }
    }
}
