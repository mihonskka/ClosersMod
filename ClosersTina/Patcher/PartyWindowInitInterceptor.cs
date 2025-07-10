using ClosersTina.FrontScript;
using ClosersTina.KeyWords;
using ClosersTina.Services;
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
	[HarmonyPatch(typeof(FieldSystem), "PartyWindowInit")]
	public class PartyWindowInitInterceptor
	{
		[HarmonyPostfix]
		public static void Postfix()
		{
			if (!TinaService.CheckPresence(false)) return;
			FieldSystem.instance.StartCoroutine(new PartyWindowInitInterceptor().InstUIAsync());
		}
		public IEnumerator InstUIAsync()
		{
			yield return new WaitForSecondsRealtime(0.1f);

			if (FieldSystem.instance.PartyWindow.FirstOrDefault(t => t.Info.KeyData == TinaKeyWords.Tina).transform.GetComponentInChildren<ProgressBar_Tina_Script>() != null) yield break;

			var ProgressBar = AddressableLoadManager.Instantiate(new GDEGameobjectDatasData(TinaKeyWords.Closers_Tina_ProgressBar).Gameobject_Path, AddressableLoadManager.ManageType.Character);
			//FieldSystem.instance.PartyWindow.Select(t => t.Info.KeyData).ToList().ForEach(t => clog.iw($"PWI: {t}"));
			ProgressBar.transform.SetParent(FieldSystem.instance.PartyWindow.FirstOrDefault(t => t.Info.KeyData == TinaKeyWords.Tina).transform, false);

			ProgressBar.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
			ProgressBar.transform.position += new Vector3(0.05f * 16, 0.05f * 20, 0);

			TinaService.FieldTinaPB = ProgressBar.AddComponent<ProgressBar_Tina_Script>();
			TinaService.FieldTinaPB.SetAbrasion((int)ExpService.getExp().Obj);
			TinaService.FieldTinaPB.SetSupply((TinaService.FindTinaInInvest().Passive as P_Tina).PassiveCounter, true);
		}
	}
}
