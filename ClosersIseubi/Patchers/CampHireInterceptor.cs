using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.KeyWords;
using ClosersFramework.Services;
using GameDataEditor;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UseItem;

namespace ClosersIseubi.Patchers
{
    [HarmonyPatch(typeof(FieldSystem), "PartyAdd", new Type[] { typeof(GDECharacterData), typeof(int) })]
    public class CampHireInterceptor
    {
        [HarmonyPostfix]
        public static void Postfix(ref GDECharacterData CData)
        {
            if (CData.Key == IseubiKeyWords.Iseubi)
            {
                clog.iw($"李瑟钰入队！");
                clog.iw($"当前队内人数为{PlayData.TSavedata.Party.Count}");
                if (PlayData.TSavedata.Party.Count == 3)
                {
                    clog.iw("李瑟钰为第三位调查员，初始战斗场次为3。");
                    ExpService.AddExp(3);
                }
                if (PlayData.TSavedata.Party.Count == 4)
                {
                    clog.iw("李瑟钰为第四位调查员，初始战斗场次为12。");
                    ExpService.AddExp(12);
                }
            }
        }
    }
}
