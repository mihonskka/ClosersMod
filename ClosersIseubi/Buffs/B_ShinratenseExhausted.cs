using ClosersFramework.Templates;
using ClosersIseubi.Service;
using GameDataEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersIseubi.Buffs
{
    public class B_ShinratenseExhausted : ClosersBaseBuff, IP_PlayerTurn_1
    {
        public void Turn1()
        {
            this.SelfDestroy();
        }
    }
}
