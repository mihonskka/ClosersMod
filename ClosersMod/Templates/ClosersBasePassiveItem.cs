using ClosersFramework.Service.CodeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Templates
{
	public class ClosersBasePassiveItem : PassiveItemBase, IClosersUnit
	{
		public virtual string ClosersDesc(string desc) => desc;

		[NoReference]
		public virtual string ClosersExtendName(string name) => name;
		public override string DescExtended(string desc)=> string.IsNullOrEmpty(ClosersDesc(desc)) ? base.DescExtended(desc) : ClosersDesc(desc);

		public override string DescInit()
		{
			return base.DescInit();
		}


	}
}
