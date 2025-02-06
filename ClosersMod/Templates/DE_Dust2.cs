using DarkTonic.MasterAudio;
using Dialogical;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Templates
{
	[Serializable]
	public class DE_Dust2 : DialogueEvent
	{
		public override string returnName()
		{
			return "Closers de_dust2";
		}

		public override IEnumerator EventOn()
		{
			return base.EventOn();
		}
	}
}
