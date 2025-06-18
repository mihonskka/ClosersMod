using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.Services;
using GameDataEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ClosersFramework.Templates;

namespace ClosersIseubi.Buffs
{
    public class B_MyiseubiProxyBuff : ClosersBaseBuff
    {
        public override void Init()
        {
            this.PlusStat.HIT_CC = BattleSystem.instance.EnemyTeam.AliveChars.Count * 10;
            base.Init();
        }

        public override void FixedUpdate()
        {
            if (ThrottleService.CheckAvailable(ThrottleKeyWords.MyProxyBuff))
            {
                this.PlusStat.HIT_CC = BattleSystem.instance.EnemyTeam.AliveChars.Count * 10;
                ThrottleService.AddRegistrationMilliSeconds(ThrottleKeyWords.MyProxyBuff, 500);
            }
            base.FixedUpdate();
        }
    }
}
