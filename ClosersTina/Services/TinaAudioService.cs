using ChronoArkMod.ModData;
using DarkTonic.MasterAudio;
using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersTina.Services
{
    public static class TinaAudioService
    {
        public static void Play(string audioName, float volume)
        {
            if (string.IsNullOrWhiteSpace(audioName)) return;
            var audio = AddressableLoadManager.Instantiate(new GDEGameobjectDatasData(audioName).Gameobject_Path, AddressableLoadManager.ManageType.Battle);
            audio.GetComponent<AudioSource>().Play();
            MonoBehaviour.Destroy(audio, 4);
            //MasterAudio.PlaySound(audioName, volume);
        }
    }
}
