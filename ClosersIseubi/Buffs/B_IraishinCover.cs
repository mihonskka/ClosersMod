using ClosersFramework.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Buffs
{
    public class B_IraishinCover : ClosersBaseBuff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.dod = 5*this.StackNum;
            this.PlusStat.AggroPer = -20* this.StackNum;
        }
    }
}
