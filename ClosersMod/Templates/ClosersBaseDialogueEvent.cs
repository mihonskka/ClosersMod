using ClosersFramework.Services;
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
	public abstract class ClosersBaseDialogueEvent : DialogueEvent
	{
		public override string returnName()
		{
			return ClosersComponentName() + SnowService.instance.nextId();
		}
		public abstract string ClosersComponentName();
		public abstract void ClosersEvent();

		public override IEnumerator EventOn()
		{
			ClosersEvent();
			return base.EventOn();
		}
	}
}
