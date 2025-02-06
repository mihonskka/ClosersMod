using ClosersFramework.KeyWords;
using ClosersFramework.Models;
using ClosersHumanity.KeyWords;
using ClosersTina.KeyWords;
using Dialogical;
using Dialogical.ParameterSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ClosersFramework.Service.Enum;
using TalkingKeyWords = ClosersHumanity.KeyWords.TalkingKeyWords;

namespace ClosersTina.Talking
{
    public class ArkTalkingA : ClosersTalkingTree
    {
        public override string Key => TinaTalkingKeyWords.TinaArkTalkingA;
        public override Type FirstNodeType => typeof(TinaArkA0);
        public override string Owner => TinaKeyWords.Tina;
        public override TalkingScene Scene => TalkingScene.Ark;
    
    }
    public class TinaArkA0 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(TinaArkA1);
        public override string Name => TalkingKeyWords.LucyName;
        public override string Content => "你就是那位叫缇娜的人？";
        public override string StandingPath => TinaTalkingKeyWords.TinaStanding_normal;
        public override string FaceChipPath => TalkingKeyWords.LucyFaceChip_say;
        public override string AudioPath => string.Empty;
		#region 额外属性

		public override string LocalEvent => default;

		public override Sprite Standing_3DMap => default;

		public override string Standing_3DMap_Number => default;

		public override int NameIndex => default;

		public override int AutoChoiceIndex => default;

		public override DialogueParameterSetBase LocalEventParameterSet => default;

		public override string GlobalEvent => default;

		public override DialogueParameterSetBase GlobalEventParameterSet => default;
		#endregion
	}
	public class TinaArkA1 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(TinaArkA3);
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => "正是。";
        public override string StandingPath => TinaTalkingKeyWords.TinaStanding_smile;
        public override string FaceChipPath => string.Empty;
        public override string AudioPath => string.Empty;
		#region 额外属性

		public override string LocalEvent => default;

		public override Sprite Standing_3DMap => default;

		public override string Standing_3DMap_Number => default;

		public override int NameIndex => default;

		public override int AutoChoiceIndex => default;

		public override DialogueParameterSetBase LocalEventParameterSet => default;

		public override string GlobalEvent => default;

		public override DialogueParameterSetBase GlobalEventParameterSet => default;
		#endregion
	}
	public class TinaArkA3 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(TinaArkA4);
        public override string Name => TalkingKeyWords.LucyName;
        public override string Content => "你和那边那个叫李瑟钰的人很像。都是我没见过的面孔。\n你和她是什么关系？";
        public override string StandingPath => TinaTalkingKeyWords.TinaStanding_smile;
        public override string FaceChipPath => TalkingKeyWords.LucyFaceChip_normal;
        public override string AudioPath => string.Empty;
		#region 额外属性

		public override string LocalEvent => default;

		public override Sprite Standing_3DMap => default;

		public override string Standing_3DMap_Number => default;

		public override int NameIndex => default;

		public override int AutoChoiceIndex => default;

		public override DialogueParameterSetBase LocalEventParameterSet => default;

		public override string GlobalEvent => default;

		public override DialogueParameterSetBase GlobalEventParameterSet => default;
		#endregion
	}
	public class TinaArkA4 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(TinaArkA5);
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => "不愧是预言少女。";
        public override string StandingPath => TinaTalkingKeyWords.TinaStanding_smile;
        public override string FaceChipPath => string.Empty;
        public override string AudioPath => string.Empty;
		#region 额外属性

		public override string LocalEvent => default;

		public override Sprite Standing_3DMap => default;

		public override string Standing_3DMap_Number => default;

		public override int NameIndex => default;

		public override int AutoChoiceIndex => default;

		public override DialogueParameterSetBase LocalEventParameterSet => default;

		public override string GlobalEvent => default;

		public override DialogueParameterSetBase GlobalEventParameterSet => default;
		#endregion
	}
	public class TinaArkA5 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(TinaArkA6);
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => "我是她的……部下。想必瑟钰和你提起过我。";
        public override string StandingPath => TinaTalkingKeyWords.TinaStanding_normal;
        public override string FaceChipPath => string.Empty;
        public override string AudioPath => string.Empty;
		#region 额外属性

		public override string LocalEvent => default;

		public override Sprite Standing_3DMap => default;

		public override string Standing_3DMap_Number => default;

		public override int NameIndex => default;

		public override int AutoChoiceIndex => default;

		public override DialogueParameterSetBase LocalEventParameterSet => default;

		public override string GlobalEvent => default;

		public override DialogueParameterSetBase GlobalEventParameterSet => default;
		#endregion
	}
	public class TinaArkA6 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(TinaArkA7);
        public override string Name => TalkingKeyWords.LucyName;
        public override string Content => "我需要组建一支前往扭曲之地调查的小队，目前正缺人手，你有意向加入么？";
        public override string StandingPath => TinaTalkingKeyWords.TinaStanding_normal;
        public override string FaceChipPath => TalkingKeyWords.LucyFaceChip_say;
        public override string AudioPath => string.Empty;
		#region 额外属性

		public override string LocalEvent => default;

		public override Sprite Standing_3DMap => default;

		public override string Standing_3DMap_Number => default;

		public override int NameIndex => default;

		public override int AutoChoiceIndex => default;

		public override DialogueParameterSetBase LocalEventParameterSet => default;

		public override string GlobalEvent => default;

		public override DialogueParameterSetBase GlobalEventParameterSet => default;
		#endregion
	}
	public class TinaArkA7 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(TinaArkA8);
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => "我愿意跟你去扭曲之地，但是我需要向瑟钰请示一下。";
        public override string StandingPath => TinaTalkingKeyWords.TinaStanding_normal;
        public override string FaceChipPath => string.Empty;
        public override string AudioPath => string.Empty;
		#region 额外属性

		public override string LocalEvent => default;

		public override Sprite Standing_3DMap => default;

		public override string Standing_3DMap_Number => default;

		public override int NameIndex => default;

		public override int AutoChoiceIndex => default;

		public override DialogueParameterSetBase LocalEventParameterSet => default;

		public override string GlobalEvent => default;

		public override DialogueParameterSetBase GlobalEventParameterSet => default;
		#endregion
	}
	public class TinaArkA8 : ClosersTalkingNode
    {
        public override Type NextNode => null;
        public override string Name => TalkingKeyWords.LucyName;
        public override string Content => "好，我现在还不太着急，我再逛一逛。";
        public override string StandingPath => TinaTalkingKeyWords.TinaStanding_normal;
        public override string FaceChipPath => TalkingKeyWords.LucyFaceChip_normal;
        public override string AudioPath => string.Empty;
		#region 额外属性

		public override string LocalEvent => default;

		public override Sprite Standing_3DMap => default;

		public override string Standing_3DMap_Number => default;

		public override int NameIndex => default;

		public override int AutoChoiceIndex => default;

		public override DialogueParameterSetBase LocalEventParameterSet => default;

		public override string GlobalEvent => default;

		public override DialogueParameterSetBase GlobalEventParameterSet => default;
		#endregion
	}
}

