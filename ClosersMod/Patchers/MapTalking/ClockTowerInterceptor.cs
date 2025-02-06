using ChronoArkMod;
using ClosersFramework.Data;
using ClosersFramework.Service;
using Dialogical;
using HarmonyLib;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Service.Enum;
using UnityEngine;
using ClosersFramework.KeyWords;

namespace ClosersFramework.Patchers.MapTalking
{
    [HarmonyPatch(typeof(ClockTowerMap), "PartySpine")]
    public class ClockTowerInterceptor
    {
        [HarmonyPrefix]
        public static bool Prefix(ref ClockTowerMap __instance, int Num, string KeyData)
        {
            if (TalkingData.Characters.Any(t => t.ClosersCodeName == KeyData))
            {
                try
                {
                    SkeletonDataAsset skeletonDataAsset = null;
                    skeletonDataAsset = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<SkeletonDataAsset>(InfoKeyWords.AssetName, TalkingData.Characters.FirstOrDefault(t => t.ClosersCodeName == KeyData).SkeletonDataPath);
                    skeletonDataAsset.scale = 0.0021f;
                    __instance.PartyMember_SK[Num].skeletonDataAsset = skeletonDataAsset;
                    __instance.PartyMember_SK[Num].Initialize(true);
                    __instance.PartyMember_SK[Num].loop = true;
                    __instance.PartyMember_Dial[Num].tree = GetDialogueTree(KeyData);
                    __instance.PartyMember[Num].gameObject.SetActive(true);
                    __instance.StartCoroutine(new ClockTowerInterceptor().ienum(Num));
                    return false;
                }
                catch(Exception ex)
                {
                    clog.w($"未找到{KeyData}的待机动画");
                }
            }
            return true;
        }
        public IEnumerator ienum(int num)
        {

            while (GameObject.Find($"ClockTowerPartyMember" + ((num > 0) ? " (" + num + ")" : "")).activeSelf)
            {
                GameObject.Find($"ClockTowerPartyMember" + ((num > 0) ? " (" + num + ")" : "")).transform.rotation = new Quaternion(0, 180, 0, 0);
                yield return new WaitForSecondsRealtime(0.3f);
            }
            yield break;
        }
        public static DialogueTree GetDialogueTree(string ClosersName) => TalkingData.Data.FirstOrDefault(t => t.Scene == TalkingScene.ClockTower && t.Owner == ClosersName).CreateDialogueTree();
    }
}
