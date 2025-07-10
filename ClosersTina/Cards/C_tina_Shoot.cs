using ClosersFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Cards
{
	public class C_tina_Shoot:TinaBaseCard
	{
		public C_tina_Shoot():base(false, 0)
		{
			Weapon = TinaWeapons.Continue;
		}
		public override void Init()
		{
			base.Init();
			clog.tw("init cts");
		}
	}
}
