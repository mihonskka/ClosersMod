using ClosersFramework;
using ClosersFramework.Service;
using ClosersTina.KeyWords;
using GameDataEditor;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersTina.Patcher
{
    [HarmonyPatch(typeof(FieldSystem))]
    public class StageReadyInitInterceptor
    {
        [HarmonyPatch("StageStart")]
        [HarmonyPostfix]
        public static void Postfix()
        {
            if (PlayData.TSavedata.StageNum == 0 && !string.IsNullOrWhiteSpace(StageSystem.instance?.Map?.StageData?.Key))
            {
                clog.tw($"StageReady:当前场景名为{StageSystem.instance?.Map?.StageData?.Key}");
                var tina = PlayData.TSavedata?.Party?.FirstOrDefault(t => t.KeyData == TinaKeyWords.Tina);
                
                var iseubi = PlayData.TSavedata?.Party?.FirstOrDefault(t => t.KeyData == "Iseubi");
                
                if (tina != null && tina.LV <= 1)
                {
                    try
                    {
                        var facetina = UIManager.inst?.CharstatUI?.GetComponent<CharStatV4>()?.CharInfos?.FirstOrDefault(t => t.AllyCharacter.Info.KeyData == TinaKeyWords.Tina);
                        if (facetina == null) throw new Exception();
						if (!GlobalSetting.PositiveDevelop)
						{
							facetina.Upgrade(true);
							facetina.Upgrade(true);
							facetina.Upgrade(true);
							facetina.Upgrade(true);
						}
						PartyInventory.InvenM.AddNewItem(1, ItemBase.GetItem(new GDESkillData(TinaKeyWords.CL_tina1)));
                    }
                    catch (Exception)
                    {
                        FieldSystem.DelayInput(new StageReadyInitInterceptor().ienum0());
                    }
                }
                else if (iseubi != null && (PlayData.TSavedata?.LucySkillList_Legendary?.All(t => t != TinaKeyWords.CL_tina1) ?? false) && (PlayData.TSavedata?.LucySkills?.All(t => t != TinaKeyWords.CL_tina1) ?? false) && PlayData.TSavedata.Inventory.All(t => !(t is Item_Skill && (t as Item_Skill).SkillData.KeyID == TinaKeyWords.CL_tina1)))
                {
                    try
                    {
						clog.tw($"StageReady: 第57行判定成功，准备给予技能书");
						var faceiseubi = UIManager.inst?.CharstatUI?.GetComponent<CharStatV4>()?.CharInfos?.FirstOrDefault(t => t.AllyCharacter.Info.KeyData == "Iseubi");
                        if (faceiseubi == null) throw new Exception();
						PartyInventory.InvenM.AddNewItem(1, ItemBase.GetItem(new GDESkillData(TinaKeyWords.CL_tina1)));
                    }
                    catch (Exception)
                    {
                        FieldSystem.DelayInput(new StageReadyInitInterceptor().ienum1());
                    }
                }
            }
        }

        public IEnumerator ienum0()
        {
            yield return new WaitForSecondsRealtime(1f);
            var facetina = UIManager.inst?.CharstatUI?.GetComponent<CharStatV4>()?.CharInfos?.FirstOrDefault(t => t.AllyCharacter.Info.KeyData == TinaKeyWords.Tina);
            if(facetina == null) yield break;
			PartyInventory.InvenM.AddNewItem(1, ItemBase.GetItem(new GDESkillData(TinaKeyWords.CL_tina1)));
            facetina.Upgrade(true);
            facetina.Upgrade(true);
            facetina.Upgrade(true);
            facetina.Upgrade(true);
            yield break;
        }
        public IEnumerator ienum1()
        {
            yield return new WaitForSecondsRealtime(1f);
            var faceiseubi = UIManager.inst?.CharstatUI?.GetComponent<CharStatV4>()?.CharInfos?.FirstOrDefault(t => t.AllyCharacter.Info.KeyData == "Iseubi");
            if (faceiseubi == null) yield break;
			PartyInventory.InvenM.AddNewItem(1, ItemBase.GetItem(new GDESkillData(TinaKeyWords.CL_tina1)));
            yield break;
        }
    }
}
