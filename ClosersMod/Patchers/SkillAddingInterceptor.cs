using ClosersFramework.KeyWords;
using ClosersFramework.Service;
using DarkTonic.MasterAudio;
using GameDataEditor;
using HarmonyLib;
using I2.Loc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UseItem;

namespace ClosersFramework.Patchers
{
    public static class SkillAddingInterceptorData
    {
        public static Dictionary<string, Func<Character, bool, bool>> SkillPrivilegesList { get; set; } = new Dictionary<string, Func<Character, bool, bool>>();
    }

    public class SkillAddingInterceptor
    {
        [HarmonyPatch(typeof(CharacterWindow), "GetRandomSkill")]
        public class SkillAddingInterceptorA
        {
            [HarmonyPrefix]
            public static void Prefix(CharacterWindow __instance)
            {
                //clog.w("技能增加拦截器A");
                /*
                bool flag = false;
                foreach(var i in SkillAddingInterceptorData.SkillPrivilegesList)
                    flag |= i.Value.Invoke(__instance.AllyCharacter.Info, false);
                if (flag) num++;
                */


                /*
                if (!IseubiService.CheckPresence(false)) return;
                if (__instance.AllyCharacter.Info == IseubiService.FindIseubiInInvest())
                {
                    var result = __result;
                    var externSkillGDE = PlayData.GetCharacterSkillNoOverLap(__instance.AllyCharacter.Info, false, null).Where(t => result.All(u => u.MySkill.KeyID != t.KeyID)).NextRandom();
                    __result.Add(Skill.TempSkill(externSkillGDE.Key, __instance.AllyCharacter, PlayData.TempBattleTeam).CloneSkill());
                    if (!SaveManager.IsUnlock(externSkillGDE.Key, SaveManager.NowData.unlockList.SkillPreView))
                        SaveManager.NowData.unlockList.SkillPreView.Add(externSkillGDE.Key);

                }
                */
            }
        }

        [HarmonyPatch(typeof(CharFace), "GetRandomSkill")]
        public class SkillAddingInterceptorB
        {
            [HarmonyPrefix]
            public static void Prefix(CharFace __instance, ref int num)
            {
                clog.w("技能增加拦截器B");
                bool flag = false;
                foreach (var i in SkillAddingInterceptorData.SkillPrivilegesList)
                    flag |= i.Value.Invoke(__instance.AllyCharacter.Info, false);
                if (flag) num++;
                if (flag && num > 4) num = 4;
            }
        }
        
        [HarmonyPatch(typeof(SkillBookCharacter), "Use")]
        public class SkillAddingInterceptorBook
        {
            
            [HarmonyPrefix]
            public static bool Prefix(SkillBookCharacter __instance, ref bool __result)
            {
                /*
                if (!ThrottleService.CheckAvailable(InterceptorsKeyWord.SkillBookCharacterUse))
                {
                    clog.iw("技能书拦截成功！");
                    __result = true;
                    return false;
                }
                ThrottleService.AddRegistrationMilliSeconds(InterceptorsKeyWord.SkillBookCharacterUse, 300);*/
                try
                {
                    int count = PlayData.TSavedata.Party.Count;
                    List<Skill> list = new List<Skill>();
                    List<BattleAlly> battleallys = PlayData.Battleallys;
                    BattleTeam tempBattleTeam = PlayData.TempBattleTeam;
                    int i = 0;
                    while (i < PlayData.TSavedata.Party.Count)
                    {
                        if (PlayData.TSavedata.SpRule != null && PlayData.TSavedata.SpRule.RuleChange.SkillBookPlusNum >= 1)
                        {
                            List<GDESkillData> list2 = new List<GDESkillData>();
                            list2.AddRange(PlayData.GetCharacterSkillNoOverLap(PlayData.TSavedata.Party[i], false, null).RandomSkill(PlayData.TSavedata.Party[i], PlayData.TSavedata.SpRule.RuleChange.SkillBookPlusNum + 1));
                            using (List<GDESkillData>.Enumerator enumerator = list2.GetEnumerator())
                            {
                                while (enumerator.MoveNext())
                                {
                                    GDESkillData gdeskillData = enumerator.Current;
                                    list.Add(Skill.TempSkill(gdeskillData.KeyID, battleallys[i], tempBattleTeam));
                                }
                                goto IL_128;
                            }
                            goto IL_E4;
                        }
                        goto IL_E4;
                    IL_128:
                        i++;
                        continue;
                    IL_E4:
                        list.Add(Skill.TempSkill(PlayData.GetCharacterSkillNoOverLap(PlayData.TSavedata.Party[i], false, null).RandomSkill(PlayData.TSavedata.Party[i]).KeyID, battleallys[i], tempBattleTeam));
                        goto IL_128;
                    }

                    var clist = new List<string>();
                    foreach (var item in SkillAddingInterceptorData.SkillPrivilegesList) if (item.Value.Invoke(null, true)) clist.Add(item.Key);
                    foreach (var c in clist) clog.w($"skillbook:{c}");
                    foreach (var c in clist)
                        list.Add(Skill.TempSkill(PlayData.GetCharacterSkillNoOverLap(PlayData.TSavedata.Party.FirstOrDefault(t => t.KeyData == c), false, null).Where(t => list.All(u => u.MySkill.KeyID != t.KeyID)).ToList().RandomSkill(PlayData.TSavedata.Party.FirstOrDefault(t => t.KeyData == c)).KeyID, battleallys.FirstOrDefault(t => t.Info.KeyData == c), tempBattleTeam));

                    /*StackTrace stackTrace = new StackTrace(true);
                    MethodBase methodBase = stackTrace.GetFrame(4).GetMethod();
                    var info0 = methodBase.DeclaringType.Name;
                    var info1 = methodBase.Name;
                    clog.iw($"技能书阅读拦截器，{info0}.{info1}");*/
                    foreach (Skill skill in list)
                    {
                        if (!SaveManager.IsUnlock(skill.MySkill.KeyID, SaveManager.NowData.unlockList.SkillPreView))
                        {
                            SaveManager.NowData.unlockList.SkillPreView.Add(skill.MySkill.KeyID);
                        }
                    }
                    PlayData.TSavedata.UseItemKeys.Add(GDEItemKeys.Item_Consume_SkillBookCharacter);
                    FieldSystem.DelayInput(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(Mybutton =>
                    {
                        Mybutton.Myskill.Master.Info.UseSoulStone(Mybutton.Myskill);
                        UIManager.inst.CharstatUI.GetComponent<CharStatV4>().SkillUPdate();
                    }), ScriptLocalization.System_Item.SkillAdd, false, true, true, true, true));
                    MasterAudio.PlaySound("BookFlip", 1f, null, 0f, null, null, false, false);
                    __result = true;
                    return false;
                }
                catch (Exception ex)
                {
                    return true;
                }
            }
        }

        /*
        [HarmonyPatch(typeof(Item_Consume),"Use")]
        public class DebuggingInterceptorA
        {
            [HarmonyPrefix]
            public static void Postfix(Item_Consume __instance)
            {
                clog.iw("检测到Item_ConsumeUse");
            }
        }
        [HarmonyPatch(typeof(ItemObject), "Use")]
        public class DebuggingInterceptorB
        {
            [HarmonyPrefix]
            public static void Postfix(Item_Consume __instance)
            {
                clog.iw("检测到Item_ObjectUse");
            }
        }
        */

        [HarmonyPatch(typeof(CharacterWindow), "GetRandomSkill")]
        public class SkillAddingInterceptorRareBook
        {
        }
    }
}
