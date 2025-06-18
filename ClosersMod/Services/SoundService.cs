using ClosersFramework.Models;
using ClosersFramework.Services;
using DarkTonic.MasterAudio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClosersFramework.Services
{
	public class SoundService
	{
		public static void StopAll()
		{
			MasterAudio.StopBus("StoryBGM");
			MasterAudio.StopBus("StoryBGM");
			MasterAudio.StopBus("BGM");
			MasterAudio.StopBus("BGM");
			//MasterAudio.StopBus("SE");
			MasterAudio.StopBus("Ambi");
			MasterAudio.StopBus("StoryAmbi");
			MasterAudio.StopBus("DREAMSE");
			MasterAudio.StopBus("SideStoryBGM");
			MasterAudio.StopBus("SideStoryBGM");
		}

		public static BGMUnit Model { get; set; }

		public static bool InIntro { get; set; } = false;
		//public static DateTime LoopingStartTime { get; set; }
		public static DateTime IntroEndTime { get; set; }
		public static DateTime LoopingEndTime { get; set; }
		public static void StartBGM(BGMUnit model)
		{
			Model = model;
			if (Model.Intro != null)
			{
				if (Model.Loop)
				{
					InIntro = true;
					//LoopingEndTime = DateTime.UtcNow.AddSeconds(model.Duration);
					IntroEndTime = DateTime.UtcNow.AddSeconds(Model.Intro.Duration);
					UIManager.inst.StartCoroutine(new SoundService().CheckLoopingCoroutine());
				}
				MasterAudio.PlaySound(Model.Intro.SoundType);
				return;
			}

			if (Model.Loop)
			{
				InIntro = false;
				LoopingEndTime = DateTime.UtcNow.AddSeconds(Model.Duration);
				UIManager.inst.StartCoroutine(new SoundService().CheckLoopingCoroutine());
			}
			MasterAudio.PlaySound(Model.SoundType);
			//DialogueSceneMain.Inst.StartCoroutine(new SoundService().CheckLoopingCoroutine());
		}
		public static void StartMusicOnce(SoundEffectUnit model)
		{
			PlaySound(model.SoundType);
		}

		public static void PlaySound(string type)
		{
			MasterAudio.PlaySound(type);
		}

		public static void StopLooping()
		{
			try
			{
				Model.Loop = false;
				Model.Intro.Loop = false;
				clog.w("检测到封印者对话结束。已中断BGM循环。");
			}
			catch
			{
				clog.w("检测到非封印者对话结束。无法中断BGM循环。");
			}
		}
		public IEnumerator CheckLoopingCoroutine()
		{
			while (InIntro)
			{
				if (IntroEndTime <= DateTime.UtcNow)
				{
					PlaySound(Model.SoundType);
					InIntro = false;
					//IntroEndTime = DateTime.UtcNow.AddMinutes(Model.Duration + 0.075);
					break;
				}
				yield return new WaitForSeconds(0.07f);
			}

			while (Model.Loop)
			{
				if (LoopingEndTime <= DateTime.UtcNow)
				{
					//clog.w($"LET: {LoopingEndTime:f}:{LoopingEndTime.Second}");
					PlaySound(Model.SoundType);
					LoopingEndTime = DateTime.UtcNow.AddSeconds(Model.Duration+0.075);
				}
				yield return new WaitForSeconds(0.07f);
			}
			InIntro = false;
			Model = null;
			LoopingEndTime = default;
			IntroEndTime = default;
			yield break;
		}
	}
}
