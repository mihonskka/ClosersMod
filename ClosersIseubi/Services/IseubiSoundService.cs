using ClosersIseubi.Service;
using ClosersFramework.KeyWords;
using ClosersFramework.Models.Interface;
using ClosersFramework.Services;
using ClosersFramework.Service.CodeManager;
using DarkTonic.MasterAudio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

namespace ClosersIseubi.Service
{
	public class IseubiSoundService : ClosersCharacterSoundService
	{		
		public static IseubiSoundService instance { get; set; }
		public static IseubiSoundService getInstance() => instance ?? new IseubiSoundService();

        public override void _Sound(string SoundName, ICharacterSoundsToken model)
		{
			clog.iw("语音服务-收到单条语音播报请求。");
			if (IseubiService.isIseubi(model))
			{
                clog.iw("语音服务-验证通过，正式开始播报");
                MasterAudio.PlaySound(SoundName, 1f, null, 0f, null, null, false, false);
            }	
		}
        public override void _RandomSound(string SoundName, int RandNum, ICharacterSoundsToken model)
        {
            clog.iw("语音服务-收到随机语音播报请求。");
            if (IseubiService.isIseubi(model))
            {
                clog.iw("语音服务-验证通过，正式开始播报");
                MasterAudio.PlaySound(SoundName + new Random().Next(0, RandNum + 1), 1f, null, 0f, null, null, false, false);
            }
        }
		public static void Sound(string SoundName, ICharacterSoundsToken model)
		{
			instance = getInstance();
			instance._Sound(SoundName, model);
		}
		public static void RandomSound(string SoundName, int RandNum, ICharacterSoundsToken model)
		{
			instance = getInstance();
			instance._RandomSound(SoundName, RandNum, model);
		}

        [NoReference]
		public static async Task BattleStart()
		{
			if (_battleStartNoShaking) return;
            await new Task(() => 
			{
				_battleStartNoShaking = true;
				//RandomSound(ClosersKeyWords.V_Intro, 5);
				new WaitForSecondsRealtime(4f);
				_battleStartNoShaking = false;
			});
        }
		static bool _battleStartNoShaking = false;
	}
}
