using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Templates
{
    public class ClosersBaseBuff : Buff, IClosersUnit
    {
        public virtual string ClosersDesc(string desc) => desc;

        public virtual string ClosersExtendName(string name) => name;

        public override string DescInit() => ClosersDesc(base.DescInit());
        public override string NameExtended(string Name) => base.NameExtended(ClosersExtendName(Name));
    }
}
