using ChronoArkMod;
using ClosersFramework.Service.CodeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Templates
{
    public class ClosersBaseActiveItem: UseitemBase, IClosersUnit
    {
        public override string DescExtended(string desc)=> string.IsNullOrEmpty(ClosersDesc(desc)) ? base.DescExtended(desc) : ClosersDesc(desc);

        public virtual string ClosersDesc(string desc) => desc;

        [NoReference]
        public virtual string ClosersExtendName(string name) => name;
    }
}
