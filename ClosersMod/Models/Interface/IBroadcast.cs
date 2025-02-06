using ClosersFramework.Service.CodeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersFramework.Models.Interface
{
    [NoReference]
    public interface IBroadcast
    {
        void InstBattleTextAlly_Co(string Text, Vector3 Pos);
        void InstFieldText(string Text, Transform Pos);
        void CustomText(string Text, Vector3 Pos);
        void InstBattleText_Co(string Text, Vector3 Pos);
        void InstCampText_Co(string Text, Vector3 Pos, Transform CampTr);
        void InstFieldText_CO(string Text, Transform Pos);
    }
}
