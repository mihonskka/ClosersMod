using ClosersIseubi.Service;
using ClosersFramework.Models;
using ClosersFramework.Models.Interface;
using ClosersFramework.Service;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ClosersFramework.Patchers.Registration;

namespace ClosersIseubi.Patchers.Registration
{
    public class IseubiBroadcast : ClosersBroadcast
    {
        public override void mainfunction(string Text, Vector3 Pos, Transform PosT=null)
        {
            (long SentenceID, string ActionName) = IseubiModalMessageService.GetActionInfo(Text);
            if (SentenceID != -1 && !string.IsNullOrWhiteSpace(ActionName))
            {
                clog.iw("准备播报语音");
                ActionName = IseubiModalMessageService.WordMap(ActionName);
                if(Pos != null && Pos != new Vector3())
                    IseubiSoundService.Sound(ActionName + SentenceID, new SoundsComponentMsg() { ComponentCoordinate = Pos });
                else if (PosT != null)
                    IseubiSoundService.Sound(ActionName + SentenceID, new SoundsComponentMsg() { ComponentTransform = PosT });
                
            }
        }
    }
}
