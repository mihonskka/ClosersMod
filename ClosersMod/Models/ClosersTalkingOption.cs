using ChronoArkMod;
using ChronoArkMod.DialogueCreate;
using ClosersFramework.KeyWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersFramework.Models
{
	public abstract class ClosersTalkingOption : DialogueNodeOptionCreator
	{
		public abstract Type GoTo { get; }
		public abstract string Text { get; }
		public override Type TargetDialogueNodeCreatorType => GoTo;
		public override DialogueNodeOptionParameter SetDialogueNodeOptionParameter()
		{
			return new DialogueNodeOptionParameter()
			{
				Text = this.Text,
				isShownOncePerConversation = false
			};
		}
	}
}
