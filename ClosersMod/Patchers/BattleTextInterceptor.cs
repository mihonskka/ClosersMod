using ClosersFramework.Models;
using ClosersFramework.Models.Interface;
using ClosersFramework.Patchers.Registration;
using ClosersFramework.Service;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersFramework.Patchers
{
    public class BattleTextInterceptorData
    {
        public static List<ClosersBroadcast> Broadcasts { get; set; } = new List<ClosersBroadcast>();
    }

    /// <summary>
    /// 战斗阶段一般消息弹窗
    /// </summary>
    [HarmonyPatch(typeof(BattleText), "InstBattleTextAlly_Co", new Type[] { typeof(Vector3), typeof(string), typeof(bool) })]
    public class BroadcastA
    {
        public BattleChar ComponentMaster => throw new NotImplementedException();

        [HarmonyPrefix]
        public static bool Prefix(string Text, Vector3 Pos)
        {
            clog.iw("Patch消息弹窗：" + Text);
            BattleTextInterceptorData.Broadcasts.ForEach(t => t.InstBattleTextAlly_Co(Text, Pos));
            return true;
        }
    }

    //战斗阶段特殊消息弹窗，例如戈多遇见枪哥，普瑞斯特击杀光女，西斯遇见魔女
    //[HarmonyPatch(typeof(BattleText), "InstBattleTextAlly_Co", new Type[] { typeof(BattleChar), typeof(string), typeof(bool) })]

    /// <summary>
    /// 探索阶段一般消息弹窗
    /// </summary>
    [HarmonyPatch(typeof(BattleText), "InstFieldText", new Type[] { typeof(Transform), typeof(string) })]
    public class BroadcastB
    {
        [HarmonyPrefix]
        public static bool Prefix(string Text, Transform Pos)
        {
            clog.iw("Patch消息弹窗：" + Text);
            BattleTextInterceptorData.Broadcasts.ForEach(t => t.InstFieldText(Text, Pos));
            return true;
        }
    }

    /// <summary>
    /// 自定义消息弹窗
    /// </summary>
    [HarmonyPatch(typeof(BattleText), "CustomText", new Type[] { typeof(Vector3), typeof(string) })]
    public class BroadcastC
    {
        [HarmonyPrefix]
        public static bool Prefix(string Text, Vector3 Pos)
        {
            clog.iw("Patch消息弹窗：" + Text);
            BattleTextInterceptorData.Broadcasts.ForEach(t => t.CustomText(Text, Pos));
            return true;
        }
    }

    /// <summary>
    /// 战斗阶段协程方式消息弹窗
    /// </summary>
    [HarmonyPatch(typeof(BattleText), "InstBattleText_Co", new Type[] { typeof(Vector3), typeof(string) })]
    public class BroadcastD
    {
        [HarmonyPrefix]
        public static bool Prefix(string Text, Vector3 Pos)
        {
            clog.iw("Patch消息弹窗：" + Text);
            BattleTextInterceptorData.Broadcasts.ForEach(t => t.InstBattleText_Co(Text, Pos));
            return true;
        }
    }

    /// <summary>
    /// 休整阶段协程方式消息弹窗
    /// </summary>
    [HarmonyPatch(typeof(BattleText), "InstCampText_Co", new Type[] { typeof(Vector3), typeof(string), typeof(Transform) })]
    public class BroadcastE
    {
        [HarmonyPrefix]
        public static bool Prefix(string Text, Vector3 Pos, Transform CampTr)
        {
            clog.iw("Patch消息弹窗：" + Text);
            BattleTextInterceptorData.Broadcasts.ForEach(t => t.InstCampText_Co(Text, Pos, CampTr));
            return true;
        }
    }

    /// <summary>
    /// 探索阶段协程方式消息弹窗
    /// </summary>
    [HarmonyPatch(typeof(BattleText), "InstFieldText_CO", new Type[] { typeof(Transform), typeof(string) })]
    public class BroadcastF
    {
        [HarmonyPrefix]
        public static bool Prefix(string Text, Transform Pos)
        {
            clog.iw("Patch消息弹窗：" + Text);
            BattleTextInterceptorData.Broadcasts.ForEach(t => t.InstFieldText_CO(Text, Pos));
            return true;
        }
    }
}
