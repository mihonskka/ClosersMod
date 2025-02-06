using ClosersFramework.Services;
using ClosersFramework.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersHumanity.De_Closers
{
	public class De_ClosersBGMStop : ClosersBaseDialogueEvent
	{
		public override string ClosersComponentName()
		{
			return nameof(De_ClosersBGMStop);
		}

		public override void ClosersEvent()
		{
			SoundService.StopLooping();
			SoundService.StopAll();
		}
	}
}
