using ChronoArkMod;
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
using static ClosersFramework.Services.Enum;
using TalkingKeyWords = ClosersHumanity.KeyWords.TalkingKeyWords;

namespace ClosersIseubi.Talking
{
    public class ArchiveTalkingA : ClosersTalkingTree
    {
        public override string Key => IseubiTalkingKeyWords.iseubiArchiveA;
        public override Type FirstNodeType => typeof(ArchiveTalkingA0);
        public override string Owner => IseubiKeyWords.Iseubi;
        public override TalkingScene Scene => TalkingScene.Archives;
    }
    public class ArchiveTalkingA0 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArchiveTalkingA1);
        public override string Name => ClosersHumanity.KeyWords.TalkingKeyWords.LucyName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "瑟钰…",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_upset;
        public override string FaceChipPath => TalkingKeyWords.LucyFaceChip_realize;
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
	public class ArchiveTalkingA1 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArchiveTalkingA2);
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "露西，为什么，这里没有我的信息？",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_upset;
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
	public class ArchiveTalkingA2 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArchiveTalkingA3);
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "既然这里是虚拟世界，既然这里是记录了一切的档案馆。\n那我又是谁，为什么我游离在它的控制之外？",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_upset;
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
	public class ArchiveTalkingA3 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArchiveTalkingA4);
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "我还是人类吗？",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_upset;
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
	public class ArchiveTalkingA4 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArchiveTalkingA5);
        public override string Name => TalkingKeyWords.LucyName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "我…我也不知道…\n对不起，李瑟钰。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_upset;
        public override string FaceChipPath => TalkingKeyWords.LucyFaceChip_realize;
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
	public class ArchiveTalkingA5 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArchiveTalkingA6);
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "不是你的错，露西。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_upset;
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
	public class ArchiveTalkingA6 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArchiveTalkingA7);
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "而是…",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_upset;
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
	public class ArchiveTalkingA7 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArchiveTalkingA8);
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "我在方舟，本就是一个错误。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_upset;
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
	public class ArchiveTalkingA8 : ClosersTalkingNode
    {
        public override Type NextNode => null;
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "我之后要和缇娜讨论一下这件事。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_upset;
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