using ClosersFramework.Services;
using ClosersFramework;
using GameDataEditor;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosersTina.KeyWords;
using System.Collections;
using UnityEngine;

namespace ClosersTina.Patcher
{
    public class LevelInterceptors
    {

    }
    [HarmonyPatch(typeof(FieldSystem))]
    public class LevelReduceInterceptorA
    {
        [HarmonyPatch("StageStart")]
        [HarmonyPostfix]
        public static void Postfix()
        {
            var stagelist = new List<string>()
            {
                GDEItemKeys.Stage_Stage1_2, GDEItemKeys.Stage_Stage2_1, GDEItemKeys.Stage_Stage2_2, GDEItemKeys.Stage_Stage3, GDEItemKeys.Stage_Stage_Crimson
            };
            if (stagelist.Contains(StageSystem.instance.Map.StageData.Key) && !GlobalSetting.PositiveDevelop)
            {
                var tina = PlayData.TSavedata.Party.FirstOrDefault(t => t.KeyData == TinaKeyWords.Tina);
                if (tina != null)
                {
                    tina.LV--;
                }
            }
        }
    }
}
