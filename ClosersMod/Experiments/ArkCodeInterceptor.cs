using ChronoArkMod;
using ChronoArkMod.DialogueCreate;
using ChronoArkMod.ModData;
using ClosersFramework.Data;
using ClosersFramework.Service;
using Dialogical;
using GameDataEditor;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ClosersFramework.Service.Enum;

namespace ClosersFramework.Experiments
{
    internal class ArkCodeInterceptor
    {
    }
    [HarmonyPatch(typeof(ArkCode), "ArkBGMPlay")]
    public class ArkCodeInterceptorA
    {
        [HarmonyPostfix]
        public static void Postfix(ref ArkCode __instance)
        {
            clog.iw("E:ArkCode ArkBGMPlay");
            /*var TestTalking = new TestTalking();
            var EmptyObjectDeclare = new GameObject();
            var EmptyObject = GameObject.Instantiate(EmptyObjectDeclare);
            var diatree = TestTalking.CreateDialogue(EmptyObject).tree;
            diatree.nodes.Add(new TestTalkingNode0().CreateDialogueNode());*/
            //ArkCodeRedict = __instance;
            //FieldSystem.instance.StartCoroutine(new SaveManagerLoadInterceptorA().ienum(ArkCodeRedict));
            /*for(var i = 0; i <  __instance.UnlockMainNPCList.Count; i++)
            {
                __instance.UnlockMainNPCList[i] = AddressableLoadManager.Instantiate(new GDEGameobjectDatasData("Closers_QSylvi_Object").Gameobject_Path, AddressableLoadManager.ManageType.Stage);
                var sylvi = AddressableLoadManager.Instantiate(new GDEGameobjectDatasData("Closers_QSylvi_Object").Gameobject_Path, AddressableLoadManager.ManageType.Stage);
                var mysylvi = GameObject.Find(sylvi.name).GetComponent<Transform>();
                mysylvi.position = FieldSystem.instance.Player.transform.position + new Vector3(i * 0.1f, i * 0.1f, i * 0.1f);
                mysylvi.rotation = FieldSystem.instance.Player.transform.rotation;
                mysylvi.localScale = FieldSystem.instance.Player.transform.localScale;
                sylvi.SetActive(true);
                clog.iw($"E:ABP循环第{i}次");
                clog.iw($"pos:{mysylvi.position.PrintVector()}");
                clog.iw($"rot:{mysylvi.rotation.PrintQuaternion()}");
                clog.iw($"sca:{mysylvi.localScale.PrintVector()}");
                __instance.UnlockMainNPCList[i].SetActive(true);
                
            }*/
            //FieldSystem.instance.StartCoroutine(new SaveManagerLoadInterceptorA().ienum(__instance));
            //__instance.UnlockMainNPCList[0] = AddressableLoadManager.Instantiate(new GDEGameobjectDatasData("Closers_QSylvi_Object").Gameobject_Path, AddressableLoadManager.ManageType.Stage);
            //__instance.UnlockMainNPCList[0].SetActive(true);

            
            //var shadow = GameObject.Find("Shadow");
            //GameObject.Instantiate(shadow, new Vector3(-2.6872f, -0.1029f, 0), Quaternion.identity, sylvi.transform);

            FieldSystem.instance.StartCoroutine(new ArkCodeInterceptorA().ienum0("Iseubi"));
            //FieldSystem.instance.StartCoroutine(new SaveManagerLoadInterceptorA().ienum1(null));
            //NewSylvi();
        }
        public static ArkCode ArkCodeRedict { get; set; }
        public IEnumerator ienum0(string key)
        {
            yield return new WaitForSecondsRealtime(0.8f);
            CharacterLoadedData.Data.ForEach(t => FieldSystem.DelayInput(ienum1(t)));
            //NewQStanding(key);
            yield break;
        }
        public IEnumerator ienum1(string closerscodename)
        {
            if (GameObject.Find(closerscodename + "Ark") != null) yield break;
            yield return new WaitForSecondsRealtime(0.1f);
            NewQStanding(closerscodename);
            yield break;
        }

        public static void NewQStanding(string closerscodename)
        {
            try
            {
                var info = TalkingData.QStandingData[closerscodename];
                var npc0 = GameObject.Find("NPC0");
                var closersbase = GameObject.Instantiate(npc0, info.ArkPosition, Quaternion.identity);
                var basec1 = closersbase.transform.GetChild(0);
                var closers = AddressableLoadManager.Instantiate(new GDEGameobjectDatasData(info.QStandingKey).Gameobject_Path, AddressableLoadManager.ManageType.Stage, basec1.transform.position, basec1.transform.rotation, basec1.transform.parent);
                GameObject.Destroy(basec1.gameObject);
                closersbase.transform.parent = GameObject.Find("MainArk").transform;
                var talking = TalkingData.Data.FirstOrDefault(t => t.Owner == closerscodename && t.Scene==TalkingScene.Ark);
                closersbase.name = closerscodename + "Ark";

                if (talking == null)
                {
                    closersbase.GetComponent<Dialogue>().tree = null;
                    return;
                }
                else
                {
                    var diatree = talking.CreateDialogueTree();
                    closersbase.GetComponent<Dialogue>().tree = diatree;
                }
            }
            catch (Exception e)
            {
                clog.w(e.Message);
                clog.w(e.StackTrace);
            }
        }
    }
}
