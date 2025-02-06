using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Templates
{
    public class ClosersBaseExtend : Skill_Extended, IClosersUnit
    {
        public virtual string ClosersDesc(string desc) => desc;
        public virtual string ClosersExtendName(string name) => name;

        public override string ExtendedDes() => ClosersDesc(base.ExtendedDes());
        public override string ExtendedName() => ClosersExtendName(base.ExtendedName());
    }
}
