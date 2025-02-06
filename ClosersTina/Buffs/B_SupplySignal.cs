using ClosersFramework.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Buffs
{
    public class B_SupplySignal:ClosersBaseBuff,IP_TurnEnd
    {
        public void TurnEnd()
        {
            this.BChar.MyTeam.Draw();
        }
    }
}
