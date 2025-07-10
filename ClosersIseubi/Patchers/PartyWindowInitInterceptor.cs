using ClosersFramework.Services;
using ClosersIseubi.FrontScripts;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using GameDataEditor;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersIseubi.Patchers
{
	[HarmonyPatch(typeof(FieldSystem), "PartyWindowInit")]
	public class PartyWindowInitInterceptor
	{
		[HarmonyPostfix]
		public static void Postfix()
		{
			if (!IseubiService.CheckPresence(false)) return;
			FieldSystem.instance.StartCoroutine(new PartyWindowInitInterceptor().InstUIAsync());
		}
		public IEnumerator InstUIAsync()
		{
			yield return new WaitForSecondsRealtime(0.1f);
			if (FieldSystem.instance.PartyWindow.FirstOrDefault(t => t.Info.KeyData == IseubiKeyWords.Iseubi).transform.GetComponentInChildren<ProgressBar_Sylvi_Script>() != null) yield break;
			var ProgressBar = AddressableLoadManager.Instantiate(new GDEGameobjectDatasData(IseubiKeyWords.Closers_Sylvi_ProgressBar).Gameobject_Path, AddressableLoadManager.ManageType.Character);
			//FieldSystem.instance.PartyWindow.Select(t => t.Info.KeyData).ToList().ForEach(t => clog.iw($"PWI: {t}"));
			ProgressBar.transform.SetParent(FieldSystem.instance.PartyWindow.FirstOrDefault(t => t.Info.KeyData == IseubiKeyWords.Iseubi).transform, false);

			ProgressBar.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
			ProgressBar.transform.position += new Vector3(0.05f * 6, 0.05f * 21, 0);

			IseubiService.FieldSylviPB = ProgressBar.AddComponent<ProgressBar_Sylvi_Script>();
			//ProgressBar.AddComponent<SandAnimation>();
			IseubiService.FieldSylviPB.ChangeNumber(IseubiService.GetChipNum(),IseubiService.GetChipBuff());
			IseubiService.FieldSylviPB.fieldobject = true;

		}
	}
}
