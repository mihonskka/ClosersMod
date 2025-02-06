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
    public class ClockTowerTalkingA : ClosersTalkingTree
    {
        public override string Key => TinaTalkingKeyWords.TinaClockTowerTalkingA;
        public override Type FirstNodeType => typeof(ClockTowerTalkingA0);
        public override string Owner => TinaKeyWords.Tina;
        public override TalkingScene Scene => TalkingScene.ClockTower;
    }
    public class ClockTowerTalkingA0 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ClockTowerTalkingA1);
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "任务完成了，露西。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
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
	public class ClockTowerTalkingA1 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ClockTowerTalkingA2);
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "或许我就只能陪你到这里了。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
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
	public class ClockTowerTalkingA2 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ClockTowerTalkingA3);
        public override string Name => TalkingKeyWords.LucyName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "启动了之后，缇娜和瑟钰都不在了吧。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
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
	public class ClockTowerTalkingA3 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ClockTowerTalkingA4);
        public override string Name => TalkingKeyWords.LucyName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "缇娜和瑟钰总算能回家了。在扭曲之地的这段时间，让你们受苦了。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => TinaTalkingKeyWords.TinaStanding_smile;
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
	public class ClockTowerTalkingA4 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ClockTowerTalkingA5);
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "不会，我这段时间过得很享受，我相信瑟钰也是一样想的。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
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
	public class ClockTowerTalkingA5 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ClockTowerTalkingA6);
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "只是很遗憾，我和瑟钰仍是封印者，不得不归队。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
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
	public class ClockTowerTalkingA6 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ClockTowerTalkingA7);
        public override string Name => TalkingKeyWords.LucyName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "嗯……这也是没办法的事。\n开心一点吧，毕竟我们成功了，你们也能回去了。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
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
	public class ClockTowerTalkingA7 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ClockTowerTalkingA8);
        public override string Name => TalkingKeyWords.LucyName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "缇娜似乎和我一样，不怎么会笑呢。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
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
	public class ClockTowerTalkingA8 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ClockTowerTalkingA9);
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "确实，严肃地告别可不好。\n送你一颗子弹吧，我也不知道在启动钟楼，我们回去之后它还在不在。\n如果还在的话，就当是这次的纪念。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
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
	public class ClockTowerTalkingA9 : ClosersTalkingNode
    {
        public override Type NextNode => null;
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "和你在一起的时光很开心。\n再见了，露西。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => TinaTalkingKeyWords.TinaStanding_bigsmile;
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
}