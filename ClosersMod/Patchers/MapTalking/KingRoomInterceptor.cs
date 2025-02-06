using ChronoArkMod;
using ChronoArkMod.ModData;
using ClosersFramework.Data;
using ClosersFramework.KeyWords;
using ClosersFramework.Models;
using ClosersFramework.Models.Interface;
using ClosersFramework.Service;
using Dialogical;
using GameDataEditor;
using HarmonyLib;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ClosersFramework.Service.Enum;

namespace ClosersFramework.Patchers.MapTalking
{
    public class KingRoomInterceptorData
    {
        
    }
    [HarmonyPatch(typeof(KingRoomScript), "PartySpine")]
    public class KingRoomInterceptorB
    {
        [HarmonyPrefix]
        public static bool Prefix(ref KingRoomScript __instance, int Num, string KeyData)
        {
            if (TalkingData.Characters.Any(t=>t.ClosersCodeName==KeyData))
            {
                try
                {
                    SkeletonDataAsset skeletonDataAsset = null;
                    DialogueTree tree = null;
                    skeletonDataAsset = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<SkeletonDataAsset>(InfoKeyWords.AssetName, TalkingData.Characters.FirstOrDefault(t => t.ClosersCodeName == KeyData).SkeletonDataPath);
                    skeletonDataAsset.scale = 0.0021f;
                    tree = GetDialogueTree(KeyData);
                    __instance.PartyMember_SK[Num].skeletonDataAsset = skeletonDataAsset;
                    __instance.PartyMember_SK[Num].Initialize(true);
                    __instance.PartyMember_SK[Num].loop = true;
                    __instance.PartyMember_Dial[Num].tree = tree;
                    __instance.PartyMember[Num].transform.Rotate(0, 180, 0);
                    //__instance.PartyMember[Num].gameObject.transform.Rotate(0, 180, 0);
                    __instance.PartyMember[Num].gameObject.SetActive(true);
                    __instance.StartCoroutine(new KingRoomInterceptorB().ienum(Num));
                    return false;
                }
                catch
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
                //clog.iw($"ClockTowerPartyMember" + ((num > 0) ? " (" + num + ")" : ""));
                GameObject.Find($"ClockTowerPartyMember" + ((num > 0) ? " (" + num + ")" : "")).transform.rotation = new Quaternion(0, 180, 0, 0);
                yield return new WaitForSecondsRealtime(0.3f);
            }
            yield break;
        }
        public static DialogueTree GetDialogueTree(string ClosersName) => TalkingData.Data.FirstOrDefault(t => t.Scene == TalkingScene.ForeKing && t.Owner == ClosersName).CreateDialogueTree();
    }
}
