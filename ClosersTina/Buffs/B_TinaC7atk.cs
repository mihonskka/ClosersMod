using ClosersFramework.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Buffs
{
    public class B_TinaC7atk : ClosersBaseBuff
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = -30;
        }
    }
}
