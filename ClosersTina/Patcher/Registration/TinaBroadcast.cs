using ClosersFramework.Models;
using ClosersFramework.Models.Interface;
using ClosersFramework.Patchers.Registration;
using ClosersFramework.Service;
using ClosersTina.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersTina.Patcher.Registration
{
    public class TinaBroadcast : ClosersBroadcast
    {
        public override void mainfunction(string Text, Vector3 Pos, Transform PosT = null)
        {
            (long SentenceID, string ActionName) = TinaModalMessageService.GetActionInfo(Text);
            if (SentenceID != -1 && !string.IsNullOrWhiteSpace(ActionName))
            {
                clog.tw("准备播报语音");
                ActionName = TinaModalMessageService.WordMap(ActionName);
                if (Pos != null && Pos != new Vector3())
                    TinaSoundService.Sound(ActionName + SentenceID, new SoundsComponentMsg() { ComponentCoordinate = Pos });
                else if (PosT != null)
                    TinaSoundService.Sound(ActionName + SentenceID, new SoundsComponentMsg() { ComponentTransform = PosT });

            }
        }
    }
}
