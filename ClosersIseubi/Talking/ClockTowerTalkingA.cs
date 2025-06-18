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
    public class ClockTowerTalkingA : ClosersTalkingTree
    {
        public override string Key => IseubiTalkingKeyWords.iseubiClockTowerTalkingA;
        public override Type FirstNodeType => typeof(ClockTowerTalkingA0);
        public override string Owner => IseubiKeyWords.Iseubi;
        public override TalkingScene Scene => TalkingScene.ClockTower;
    }
    public class ClockTowerTalkingA0 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ClockTowerTalkingA1);
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "露西，我们做到了！我们终于集齐时光之影了！",
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
	public class ClockTowerTalkingA1 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ClockTowerTalkingA2);
        public override string Name => TalkingKeyWords.LucyName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "嗯，这一路来真的很感谢瑟钰的帮忙。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_smile;
        public override string FaceChipPath => TalkingKeyWords.LucyFaceChip_smile;
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
            
            SimplifiedChinese = "没有瑟钰的话，我们很可能走不到这一步。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_smile;
        public override string FaceChipPath => TalkingKeyWords.LucyFaceChip_smile;
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
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "不用客气啦，露西。\n这比我想象中的要简单啦。",
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
	public class ClockTowerTalkingA4 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ClockTowerTalkingA5);
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "接下来只要启动钟楼，就能回到过去，我也能回到我原先的世界了。",
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
	public class ClockTowerTalkingA5 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ClockTowerTalkingA6);
        public override string Name => TalkingKeyWords.LucyName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "那之后…就再也见不到瑟钰了吗？",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_smile;
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
	public class ClockTowerTalkingA6 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ClockTowerTalkingA7);
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "唔嗯…应该是的。",
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
	public class ClockTowerTalkingA7 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ClockTowerTalkingA8);
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "离开的时候总是很苦恼，很不舍得露西。\n我也没什么能留下来当存在过的证明的东西。",
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
	public class ClockTowerTalkingA8 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ClockTowerTalkingA9);
        public override string Name => TalkingKeyWords.LucyName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "没关系的，瑟钰。\n我会永远记得瑟钰，方舟的各位也一样。我们就是瑟钰存在过的证明。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_upset;
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
	public class ClockTowerTalkingA9 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ClockTowerTalkingA10);
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "好呀，我也会永远记得露西的。",
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
	public class ClockTowerTalkingA10 : ClosersTalkingNode
    {
        public override Type NextNode => null;
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "露西，我们有缘再会。",
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