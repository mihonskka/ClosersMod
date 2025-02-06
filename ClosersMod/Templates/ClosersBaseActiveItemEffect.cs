using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Templates
{
    public class ClosersBaseActiveItemEffect : Skill_Extended, IClosersUnit
    {
        public override string DescExtended(string desc) => base.DescExtended(ClosersDesc(desc));
        public override string ExtendedName() => ClosersExtendName(base.ExtendedName());

        public virtual string ClosersDesc(string desc) => desc;

        public virtual string ClosersExtendName(string name) => name;
    }
}
