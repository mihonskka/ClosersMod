using ClosersFramework.KeyWords;
using ClosersFramework.Models;
using ClosersHumanity.KeyWords;
using ClosersIseubi.KeyWords;
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

namespace ClosersIseubi.Talking
{
    public class ArkTalkingA : ClosersTalkingTree
    {
        public override string Key => IseubiTalkingKeyWords.iseubiArkTalkingA;
        public override Type FirstNodeType => typeof(ArkTalkingA0);
        public override string Owner => IseubiKeyWords.Iseubi;
        public override TalkingScene Scene => TalkingScene.Ark;
    }
    public class ArkTalkingA0 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArkTalkingA1);

        public override string Name => IseubiTalkingKeyWords.iseubiName;

		public override string Content => new TranslationItem()
		{
			
			SimplifiedChinese = "露西，我们又见面了。",
			TraditionalChinese = "", //todo
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo

		}.TransToLocalization;

		public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_smile;

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
	public class ArkTalkingA1 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArkTalkingA2);

        public override string Name => IseubiTalkingKeyWords.iseubiName;

		public override string Content => new TranslationItem()
		{
			
			SimplifiedChinese = "我说得没错吧？我们还会再见面的。",
			TraditionalChinese = "", //todo
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo

		}.TransToLocalization;

		public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_smile;

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
	public class ArkTalkingA2 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArkTalkingA3);

        public override string Name => TalkingKeyWords.LucyName;

		public override string Content => new TranslationItem()
		{
			
			SimplifiedChinese = "我可不记得你，你是谁？",
			TraditionalChinese = "", //todo
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo

		}.TransToLocalization;

		public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_smile;

        public override string FaceChipPath => TalkingKeyWords.LucyFaceChip_doubt;

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
	public class ArkTalkingA3 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArkTalkingA4);

        public override string Name => IseubiTalkingKeyWords.iseubiName;

		public override string Content => new TranslationItem()
		{
			
			SimplifiedChinese = "果然…",
			TraditionalChinese = "", //todo
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo

		}.TransToLocalization;

		public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_unhappy;

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
	public class ArkTalkingA4 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArkTalkingA5);

        public override string Name => IseubiTalkingKeyWords.iseubiName;

		public override string Content => new TranslationItem()
		{
			
			SimplifiedChinese = "我是方舟的一名普通居民，你可以叫我李瑟钰。",
			TraditionalChinese = "", //todo
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo

		}.TransToLocalization;

		public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_normal;

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
	public class ArkTalkingA5 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArkTalkingA6);

        public override string Name => IseubiTalkingKeyWords.iseubiName;

		public override string Content => new TranslationItem()
		{
			
			SimplifiedChinese = "如果要去扭曲之地的话，可以带上我么？",
			TraditionalChinese = "", //todo
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo

		}.TransToLocalization;

		public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_normal;

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
	public class ArkTalkingA6 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArkTalkingA7);

        public override string Name => TalkingKeyWords.LucyName;

		public override string Content => new TranslationItem()
		{
			
			SimplifiedChinese = "我确实需要人手，但是那里很危险，你确定要跟我一起去？",
			TraditionalChinese = "", //todo
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo

		}.TransToLocalization;

		public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_normal;

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
	public class ArkTalkingA7 : ClosersTalkingNode
    {
        public override Type NextNode => null;

        public override string Name => IseubiTalkingKeyWords.iseubiName;

        public override string Content => new TranslationItem()
		{
			
            SimplifiedChinese = "我虽然很弱，但是我可以叫上我的同伴缇娜一起，你可以相信她的实力。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo

		}.TransToLocalization;

        public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_smile;

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
