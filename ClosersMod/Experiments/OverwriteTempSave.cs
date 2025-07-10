using ChronoArkMod;
using ClosersFramework.Services;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TileTypes;
using UnityEngine;

namespace ClosersFramework.Experiments
{
	[HarmonyPatch(typeof(SaveManager))]
	public class OverwriteTempSave
	{
		[HarmonyTranspiler]
		[HarmonyPatch("XMLDeserialize_TempData")]
		public static IEnumerable<CodeInstruction> Fix1(IEnumerable<CodeInstruction> instructions, MethodBase original)
		{
			if(!GlobalSetting.ClosersDebugMode) return instructions;
			clog.w("存档管理补丁方法A：正在获取临时存档加载的IL语句！");
			var codes = instructions.ToList();

			if (codes.Count==95 && codes[91].opcode == OpCodes.Endfinally)
			{
				if (codes[84].opcode == OpCodes.Ldloc_2) codes[84].opcode = OpCodes.Ldloc_1;

				var label86 = new Label();
				codes[86].labels.Add(label86);
				codes[83] = new CodeInstruction(codes[83].opcode, label86);
				//codes[83].operand = 0x00F8 - 0x00F0;
				if (codes[82].opcode == OpCodes.Ldloc_2) codes[82].opcode = OpCodes.Ldloc_1;
				if (codes[79].opcode == OpCodes.Ldloc_3) codes[79].opcode = OpCodes.Ldloc_2;

				var label81 = new Label();
				codes[81].labels.Add(label81);
				codes[78] = new CodeInstruction(codes[78].opcode, label81);
				//codes[78].operand = 0x00EE - 0x00E6;
				if (codes[77].opcode == OpCodes.Ldloc_3) codes[77].opcode = OpCodes.Ldloc_2;

				var label92 = new Label();
				codes[92].labels.Add(label92);
				codes[76] = new CodeInstruction(codes[76].opcode, label92);
				//codes[76].operand = 0x00F9 - 0x00E3;

				var label92_1 = new Label();
				codes[92].labels.Add(label92_1);
				codes[72] = new CodeInstruction(codes[72].opcode, label92_1);
				//codes[72].operand = 0x00F9 - 0x00D6;
				if (codes[66].opcode == OpCodes.Ldloc_3) codes[66].opcode = OpCodes.Ldloc_2;
				if (codes[55].opcode == OpCodes.Stloc_3) codes[55].opcode = OpCodes.Stloc_2;

				//del 87-91
				codes.RemoveAt(91);
				codes.RemoveAt(90);
				codes.RemoveAt(89);
				codes.RemoveAt(88);
				codes.RemoveAt(87);

				codes.RemoveAt(52);
				codes.RemoveAt(51);
				codes.RemoveAt(50);
				codes.RemoveAt(49);
				codes.RemoveAt(48);
				codes.RemoveAt(47);
				codes.RemoveAt(46);

				clog.w("存档管理补丁方法A：临时存档加载方法的IL语句已被修改！");
			}
			else
			{
				clog.w("存档管理补丁方法A：警告！临时存档加载方法已被修改，补丁方法已暂停行动。");
			}
			return codes.AsEnumerable();
		}
	}
	[HarmonyPatch(typeof(SaveManager), new Type[] { typeof(TempSaveData), typeof(string)})]
	public class OverwriteTempSaveB
	{
		[HarmonyTranspiler]
		[HarmonyPatch("XMLSerialize")]
		public static IEnumerable<CodeInstruction> Fix2(IEnumerable<CodeInstruction> instructions, MethodBase original)
		{
			if (!GlobalSetting.ClosersDebugMode) return instructions;
			clog.w("存档管理补丁方法B：正在获取临时存档保存的IL语句！");
			var codes = instructions.ToList();
			if (codes.Count == 58 && codes[7].opcode == OpCodes.Ldarg_0)
			{
				var label51 = new Label();
				codes[51].labels.Add(label51);
				codes[48] = new CodeInstruction(codes[48].opcode, label51);
				//codes[48].operand = 0x007C - 0x0074;

				codes[47].opcode = OpCodes.Ldloc_0;

				var label46 = new Label();
				codes[46].labels.Add(label46);
				codes[43] = new CodeInstruction(codes[43].opcode, label46);
				//codes[43].operand = 0x0072 - 0x006A;

				var label57 = new Label();
				codes[57].labels.Add(label57);
				codes[41] = new CodeInstruction(codes[41].opcode, label46);
				//codes[41].operand = 0x007D - 0x0067;

				codes[37] = new CodeInstruction(codes[37].opcode, label57);
				//codes[37].operand = 0x007D - 0x005A;

				codes[26].opcode = OpCodes.Ldloc_1;
				codes[16].opcode = OpCodes.Stloc_1;

				codes.RemoveAt(53);
				codes.RemoveAt(52);
				codes.RemoveAt(51);
				codes.RemoveAt(50);
				codes.RemoveAt(49);

				codes.RemoveAt(13);
				codes.RemoveAt(12);
				codes.RemoveAt(11);
				codes.RemoveAt(10);
				codes.RemoveAt(9);
				codes.RemoveAt(8);
				codes.RemoveAt(7);
				clog.w("存档管理补丁方法B：临时存档保存方法的IL语句已被修改！");
			}
			else
			{
				clog.w("存档管理补丁方法B：警告！临时存档保存方法已被修改，补丁方法已暂停行动。");
			}


			return codes.AsEnumerable();
		}
	}
}
