using ClosersFramework.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Buffs
{
    public class B_C5atk : ClosersBaseBuff
    {
        public override void Init()
        {
            this.PlusPerStat.Damage = -20;
            this.PlusStat.RES_DOT = -20;
            //this.PlusStat.atk = -20f;
            base.Init();
        }
    }
}
