using ClosersFramework.Service;
using ClosersFramework.Templates;
using ClosersTina.KeyWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Buffs
{
    public class B_tina2_0:ClosersBaseBuff,IP_TurnEnd
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.def = -this.BChar.GetStat.def;
            this.PlusStat.dod = -this.BChar.GetStat.dod;
            this.PlusStat.RES_DEBUFF = -this.BChar.GetStat.RES_DEBUFF;
            this.PlusStat.RES_DOT = -this.BChar.GetStat.RES_DOT;
            this.PlusStat.RES_CC = -this.BChar.GetStat.RES_CC;
        }

        public override void FixedUpdate()
        {
            if (BattleSystem.instance != null)
            {
                if (ThrottleService.SearchRegistration(ThrottleKeyWords.B20Checking)?.isTimeout ?? true)
                {
                    this.PlusStat.def = -this.BChar.GetStat.def;
                    this.PlusStat.dod = -this.BChar.GetStat.dod;
                    this.PlusStat.RES_DEBUFF = -this.BChar.GetStat.RES_DEBUFF;
                    this.PlusStat.RES_DOT = -this.BChar.GetStat.RES_DOT;
                    this.PlusStat.RES_CC = -this.BChar.GetStat.RES_CC;
                    ThrottleService.AddRegistrationMilliSeconds(ThrottleKeyWords.B20Checking, 300);
                }
            }
            base.FixedUpdate();
        }

        public void TurnEnd()
        {
            this.SelfDestroy();
        }
    }
}
