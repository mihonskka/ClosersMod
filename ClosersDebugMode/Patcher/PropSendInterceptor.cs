using ClosersDebugMode.KeyWords;
using ClosersFramework;
using ClosersFramework.Service;
using GameDataEditor;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersDebugMode.Patcher
{
    internal class PropSendInterceptor
    {
    }
    [HarmonyPatch(typeof(FieldSystem))]
    public class PropSendInterceptorA
    {
        [HarmonyPatch("StageStart")]
        [HarmonyPostfix]
        public static void Postfix()
        {
            if (!GlobalSetting.ClosersDebugMode) return;
            if (StageSystem.instance.Map.StageData.Key == GDEItemKeys.Stage_Stage1_1)
            {
                clog.iw("调试模式，准备发送道具。");
                /*PlayData.TSavedata.IdentifyItems.Add(DebugPropKeyWords.PropDebugModeAP);
                PlayData.TSavedata.IdentifyItems.Add(DebugPropKeyWords.PropDebugModeCard);
                PlayData.TSavedata.IdentifyItems.Add(GDEItemKeys.Item_Misc_RWEnterItem);
                PlayData.TSavedata.IdentifyItems.Add(DebugPropKeyWords.PropDebugModeClear);*/
                PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(DebugPropKeyWords.Prop_DebugModeAP, 1));
                PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(DebugPropKeyWords.Prop_DebugModeCard, 1));
                PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Misc_RWEnterItem, 1));
                PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(DebugPropKeyWords.Prop_DebugModeClear, 99));
                PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(DebugPropKeyWords.Prop_DebugModeTestBattle, 99));
                PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Consume_SkillBookInfinity, 10));
                PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Consume_SkillBookCharacter_Rare, 10));
                PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Consume_SkillBookCharacter, 10));
                PartyInventory.InvenM.AddNewItem(ItemBase.GetItem(GDEItemKeys.Item_Misc_Soul, 99));
            }
        }
    }
}
