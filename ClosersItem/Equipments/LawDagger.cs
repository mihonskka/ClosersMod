using ClosersFramework.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersItem.Equipments
{
	public class LawDagger : ClosersBaseEquipmentEffect
	{
		public override void Init()
		{
			base.Init();
			this.PlusStat.atk = -1;
			this.PlusStat.Penetration = 0.15f;
			this.PlusStat.cri = 0.15f;
		}
	}
}
