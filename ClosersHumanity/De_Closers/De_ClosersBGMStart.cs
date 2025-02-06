using ClosersFramework.Models;
using ClosersFramework.Services;
using ClosersFramework.Templates;
using DarkTonic.MasterAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersHumanity.De_Closers
{
	public class De_ClosersBGMStart : ClosersBaseDialogueEvent
	{
		public De_ClosersBGMStart()
		{
		}
		public De_ClosersBGMStart(string soundName, int duration)
		{
			Model = new BGMUnit()
			{
				Loop = true,
				SoundType = soundName,
				Duration = duration
			};
		}
		public De_ClosersBGMStart(BGMUnit model)
		{
			Model = model;
		}
		public De_ClosersBGMStart((string, int) model)
		{
			LoadModel(model);
		}
		public void LoadModel((string, int) model)
		{
			Model = new BGMUnit()
			{
				Loop = true,
				SoundType = model.Item1,
				Duration = model.Item2
			};
		}
		public void LoadModel(BGMUnit model)
		{
			Model = model;
		}
		public void LoadModel(((string, int),(string, int)) model)
		{
			Model = new BGMUnit()
			{
				Loop = true,
				Intro = new BGMUnit()
				{
					Loop = false,
					SoundType = model.Item1.Item1,
					Duration = model.Item1.Item2
				},
				SoundType = model.Item2.Item1,
				Duration = model.Item2.Item2
			};
		}
		public BGMUnit Model { get; set; }
		public override string ClosersComponentName()
		{
			return nameof(De_ClosersBGMStart);
		}

		public override void ClosersEvent()
		{
			//MasterAudio.FadeOutAllOfSound("Campfire", 1f);
			//MasterAudio.FadeOutAllOfSound("CampAmbi", 1f);
			SoundService.StopAll();
			SoundService.StartBGM(Model);
		}
	}
}
