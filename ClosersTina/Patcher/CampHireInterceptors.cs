using ClosersFramework;
using ClosersFramework.Services;
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
    [HarmonyPatch(typeof(FieldSystem), "PartyAdd", new Type[] { typeof(GDECharacterData), typeof(int) })]
    public class CampHireInterceptors
    {
        [HarmonyPrefix]
        public static void Prefix(ref GDECharacterData CData, ref int Levelup)
        {
            if (CData.Key == TinaKeyWords.Tina && !string.IsNullOrWhiteSpace(StageSystem.instance?.Map?.StageData?.Key) && !GlobalSetting.PositiveDevelop)
            {
                clog.tw($"缇娜入队！");
                clog.tw($"当前队内人数为{PlayData.TSavedata.Party.Count}");
                clog.tw($"当前场景名为{StageSystem.instance?.Map?.StageData?.Key}");
                FieldSystem.instance.StartCoroutine(new CampHireInterceptors().ienum());
            }

            if (PlayData.TSavedata.LucySkills.All(t => t != TinaKeyWords.CL_tina1) && !string.IsNullOrWhiteSpace(StageSystem.instance?.Map?.StageData?.Key) && PlayData.TSavedata.Party.Any(t => t.KeyData == TinaKeyWords.Tina || t.KeyData == "Iseubi"))
            {
                InventoryManager.Reward(new List<ItemBase>()
                    {
                        ItemBase.GetItem(new GDESkillData(TinaKeyWords.CL_tina1))
                    });
            }
        }

        public IEnumerator ienum()
        {
            yield return new WaitForSecondsRealtime(0.1f);
            List<CharFace> charInfos = UIManager.inst.CharstatUI.GetComponent<CharStatV4>().CharInfos;
            int num = 4;
            if (num >= 0)
            {
                for (int j = 0; j < num; j++)
                {
                    charInfos.ToList().FirstOrDefault(t => t.AllyCharacter.Info.KeyData == TinaKeyWords.Tina).Upgrade(true);
                }
            }
            yield break;
        }
    }
}
