using ClosersIseubi.KeyWords;
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
using UseItem;

namespace ClosersIseubi.Patchers
{
    public class EquipInterceptors
    {
    }

    [HarmonyPatch(typeof(CharEquipInven), "OnDropSlot")]
    public class WhitePriestClothInterceptor
    {
        [HarmonyPostfix]
        public static void Postfix(ref CharEquipInven __instance, ItemBase inputitem, ref bool __result)
        {
            //clog.w("装备检测 发动！");
            if(inputitem.itemkey==GDEItemKeys.Item_Equip_WhitePriestCloth && __instance.Info.KeyData == IseubiKeyWords.Iseubi)
            {
                var text = new TranslationItem()
                {
                     Id=0, SimplifiedChinese="李瑟钰无法穿戴此装备！", TraditionalChinese="李瑟鈺無法穿戴此裝備！", English= "Sylvi cannot equip this.", Japanese= "ミコトはこの装備を着用することができません。",
                    Korean= "이슬비 이 장비를 착용할 수 없습니다."
                };
                //clog.w("检测到装备白色祭司服");
                EffectView.SimpleTextout(__instance.transform, text.TransToLocalization, 1f, false, 1f);
                __result = true;
            }
        }
    }
}
