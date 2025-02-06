using ClosersFramework.Templates;
using ClosersTina.KeyWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Buffs
{
    public class B_Fridge : ClosersBaseBuff, IP_BuffAdd
    {
        public override void Init()
        {
            base.Init();
            this.BarrierHP = this.Usestate_F.GetStat.maxhp;
            this.PlusStat.PerfectShield = true;
            this.PlusStat.Stun = true;
            this.PlusStat.AggroPer = 100;
            this.PlusStat.RES_DOT = 300;
        }

        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (addedbuff.BuffData.Key == TinaKeyWords.B_Overheat) addedbuff.SelfDestroy();
        }
    }
}
