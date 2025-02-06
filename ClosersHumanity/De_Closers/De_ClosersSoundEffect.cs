using ClosersFramework.Models;
using ClosersFramework.Services;
using ClosersFramework.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersHumanity.De_Closers
{
	public class De_ClosersSoundEffect : ClosersBaseDialogueEvent
	{
		public De_ClosersSoundEffect()
		{
		}
		public De_ClosersSoundEffect(string soundName)
		{
			Model = new SoundEffectUnit() { SoundType = soundName };
		}
		public De_ClosersSoundEffect(SoundEffectUnit model)
		{
			Model = model;
		}
		public void LoadModel(string soundName)
		{
			Model = new SoundEffectUnit() { SoundType = soundName };
		}
		public SoundEffectUnit Model { get; set; }
		public string SoundName { get; set; }
		public override string ClosersComponentName()
		{
			return nameof(De_ClosersBGMStart);
		}

		public override void ClosersEvent()
		{
			SoundService.StartMusicOnce(Model);
		}
	}
}
