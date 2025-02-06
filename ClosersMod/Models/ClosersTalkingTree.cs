using ChronoArkMod.DialogueCreate;
using ClosersFramework.Service;
using ClosersFramework.Services;
using Dialogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ClosersFramework.Service.Enum;

namespace ClosersFramework.Models
{
    public abstract class ClosersTalkingTree : DialogueCreator
    {
        public abstract string Key { get; }
        public abstract Type FirstNodeType { get; }
        public virtual string Owner { get; } = string.Empty;
        public override Type FirstNodeCreatorType => FirstNodeType;
        public abstract TalkingScene Scene { get; }
        public override DialogueParameter SetDialogueParameter(GameObject gameObject)
        {
            var diaEnd = new UnityEngine.Events.UnityEvent();
            diaEnd.AddListener(delegate ()
            {
                SoundService.StopLooping();
                clog.iw("检测到对话结束。");
            });

			return new DialogueParameter()
            {
                AutoPlay = true,
                UIOffDialogue = true,
                StoryDialogue = true,
                DialogueEnd = diaEnd
            };
        }

		public override Dialogue CreateDialogue(GameObject gameObject)
		{
			var d = base.CreateDialogue(gameObject);
            d.DialogueEnd.AddListener(delegate ()
			{
				SoundService.StopLooping();
				clog.iw("检测到对话结束。");
			});
            return d;
		}
	}
}
