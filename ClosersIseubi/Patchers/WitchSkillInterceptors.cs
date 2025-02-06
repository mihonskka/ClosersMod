using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.KeyWords;
using ClosersFramework.Models;
using ClosersFramework.Service;
using GameDataEditor;
using HarmonyLib;
using I2.Loc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Patchers
{
    /*
    [HarmonyPatch(typeof(Extended_Witch_P_0), "Special_PointerEnter")]
    public class WitchSkillInterceptorA
    {
        [HarmonyPostfix]
        public static void Postfix(Extended_Witch_P_0 __instance, ref BattleChar Char)
        {
            clog.iw("触发魔女拦截器");
            if (Char.Info.KeyData == IseubiKeyWords.Iseubi)
            {
                if (Misc.NumToPer((float)Char.GetStat.maxhp, (float)Char.HP) >= 25f)
                {
                    Traverse.Create(__instance).Field("MyBT").SetValue(BattleText.CustomText(Char.GetTopPos(), IseubiModalMessageService.MessagesPool.FirstOrDefault(t => t.ActionName == ModalKeyWords.Text_Battle_WitchCurseA).Sentences.Random().TransToLocalization));
                }
                else
                {
                    Traverse.Create(__instance).Field("MyBT").SetValue(BattleText.CustomText(Char.GetTopPos(), IseubiModalMessageService.MessagesPool.FirstOrDefault(t => t.ActionName == ModalKeyWords.Text_Battle_WitchCurseB).Sentences.Random().TransToLocalization));
                }
            }
        }
    }
    */
}
