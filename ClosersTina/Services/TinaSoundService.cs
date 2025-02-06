using ClosersFramework.Models.Interface;
using ClosersFramework.Service.CodeManager;
using ClosersFramework.Service;
using DarkTonic.MasterAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

namespace ClosersTina.Services
{
    public class TinaSoundService : ClosersCharacterSoundService
    {
        public static TinaSoundService instance { get; set; }
        public static TinaSoundService getInstance() => instance ?? new TinaSoundService();


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

        public override void _Sound(string SoundName, ICharacterSoundsToken model)
        {
            clog.tw("语音服务-收到单条语音播报请求。");
            if (TinaService.IsTina(model))
            {
                clog.tw("语音服务-验证通过，正式开始播报");
                MasterAudio.PlaySound(SoundName, 13f, null, 0f, null, null, false, false);
            }
        }

        public override void _RandomSound(string SoundName, int RandNum, ICharacterSoundsToken model)
        {
            clog.tw("语音服务-收到随机语音播报请求。");
            if (TinaService.IsTina(model))
            {
                clog.tw("语音服务-验证通过，正式开始播报");
                MasterAudio.PlaySound(SoundName + new Random().Next(0, RandNum + 1), 13f, null, 0f, null, null, false, false);
            }
        }

        static bool _battleStartNoShaking = false;

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
    }
}
