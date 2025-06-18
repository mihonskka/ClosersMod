using ChronoArkMod;
using ChronoArkMod.ModData;
using ChronoArkMod.Template;
using ClosersFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using HarmonyLib;
using GameDataEditor;
using System.Collections;
using System.Management.Instrumentation;
using ChronoArkMod.Plugin;
using ClosersFramework.KeyWords;
using ChronoArkMod.DialogueCreate;
using ChronoArkMod.ModData.Settings;
using ClosersFramework.Models;
using static ClosersFramework.Services.Enum;
using ClosersFramework.Models.Interface;
using ClosersFramework.Templates;
using Dialogical;
using ClosersFramework;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.IO.Pipes;
using System.Runtime.Serialization.Json;
using ClosersFramework.Services;
using System.Reflection;
using ClosersFramework.Patchers;

namespace ClosersSolidarity
{
    
    [PluginConfig("ClosersModPlugin", "ClosersMod", "23m11e")]
    public class ClosersModPlugin : ChronoArkPlugin
    {
        public static bool Allin
        {
            get
            {
                var rv = ModManager.getModInfo(InfoKeyWords.Closers).GetSetting<ToggleSetting>("Allin").Value;
				GlobalSetting.Allin = rv;
				return rv;
            }
            set
            {
                ModInfo modInfo = ModManager.getModInfo(InfoKeyWords.Closers);
                modInfo.GetSetting<ToggleSetting>("Allin").Value = value;
                modInfo.SaveSetting();
                GlobalSetting.Allin = value;
            }
        }

        public static bool CompletePassive
        {
            get
            {
                var rv = ModManager.getModInfo(InfoKeyWords.Closers).GetSetting<ToggleSetting>("CompletePassive").Value;
                GlobalSetting.CompletePassive = rv;
                return rv;
            }
            set
            {
                ModInfo modInfo = ModManager.getModInfo(InfoKeyWords.Closers);
                modInfo.GetSetting<ToggleSetting>("CompletePassive").Value = value;
                modInfo.SaveSetting();
                GlobalSetting.CompletePassive = value;
            }
        }
        public static bool PositiveDevelop
        {
            get
            {
                var rv = ModManager.getModInfo(InfoKeyWords.Closers).GetSetting<ToggleSetting>("PositiveDevelop").Value;
                GlobalSetting.PositiveDevelop = rv;
                return rv;
            }
            set
            {
                ModInfo modInfo = ModManager.getModInfo(InfoKeyWords.Closers);
                modInfo.GetSetting<ToggleSetting>("PositiveDevelop").Value = value;
                modInfo.SaveSetting();
                GlobalSetting.PositiveDevelop = value;
            }
        }
        public static bool ClosersDebugMode
        {
            get
            {
                var rv = ModManager.getModInfo(InfoKeyWords.Closers).GetSetting<ToggleSetting>("ClosersDebugMode").Value;
                GlobalSetting.ClosersDebugMode = rv;
                return rv;
            }
            set
            {
                ModInfo modInfo = ModManager.getModInfo(InfoKeyWords.Closers);
                modInfo.GetSetting<ToggleSetting>("ClosersDebugMode").Value = value;
                modInfo.SaveSetting();
                SaveManager.savemanager._DebugMode = value;
                GlobalSetting.ClosersDebugMode = value;
            }
        }
        public override void Dispose()
        {
            clog.iw("正在卸载封印者组件");
            this.harmony.UnpatchSelf();
        }

        public override void Initialize()
        {
			clog.iw("正在广播封印者全局设置", true);
            GlobalSetting.ClosersDebugMode = ClosersDebugMode;
            GlobalSetting.PositiveDevelop = PositiveDevelop;
            GlobalSetting.CompletePassive = CompletePassive;
            GlobalSetting.Allin = Allin;
			clog.iw("正在初始化封印者组件");
            this.harmony = new Harmony(InfoKeyWords.Closers);
			//this.harmony.PatchAll();
			clog.iw($"尝试加载程序集{typeof(ClosersConfig).Assembly.FullName}");
			this.harmony.PatchAll(typeof(ClosersConfig).Assembly);//ClosersFramework
            var AssemblyList = AppDomain.CurrentDomain.GetAssemblies().Where(t => t.FullName.Contains(InfoKeyWords.Closers)).ToList();
			foreach (var assembly in AssemblyList)
            {
                if (assembly == typeof(ClosersModDefinition).Assembly) continue;
                if (assembly == typeof(ClosersConfig).Assembly) continue;
                clog.iw($"尝试加载程序集{assembly.FullName}");
                this.harmony.PatchAll(assembly);
                assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ClosersBaseCharacter))).ToList().ForEach(t => {
                    var obj = Activator.CreateInstance(t) as ClosersBaseCharacter;
                    clog.iw($"尝试加载角色{obj.ClosersCodeName}");
                    obj.ClosersInit();
                });
            }
			clog.iw($"尝试加载程序集{typeof(ClosersModDefinition).Assembly.FullName}");
			this.harmony.PatchAll(typeof(ClosersModDefinition).Assembly);//ClosersSoliderity
            new Startup().Configure();

            LoadReadyInterceptorsData.Data.Add(ProcessMessengerService.SyncCacheXML);
		}
		Harmony harmony;
	}
	public class ClosersModDefinition : ModDefinition
	{
	}
}
