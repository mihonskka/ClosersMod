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
    public class ForeKingA : ClosersTalkingTree
    {
        public override string Key => IseubiTalkingKeyWords.iseubiForeKingA;
        public override Type FirstNodeType => typeof(ForeKingA0);
        public override string Owner => IseubiKeyWords.Iseubi;
        public override TalkingScene Scene => TalkingScene.ForeKing;
    }
    public class ForeKingA0 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ForeKingA1);
        public override string Name => TalkingKeyWords.LucyName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "准备好了么？瑟钰。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_normal;
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
	public class ForeKingA1 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ForeKingA2);
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "我随时都可以。",
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
	public class ForeKingA2 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ForeKingA3);
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "我以前和许多比他更强的敌人交手过。\n阿施塔特、杰拉德、提亚玛特…他们都比这位“被遗忘的王”更有压迫力。",
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
	public class ForeKingA3 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ForeKingA4);
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "可最后他们都被我打败了。",
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
	public class ForeKingA4 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ForeKingA5);
        public override string Name => TalkingKeyWords.LucyName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "看来这场战斗对你来说不会很难。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => IseubiTalkingKeyWords.iseubiStanding_smile;
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
	public class ForeKingA5 : ClosersTalkingNode
    {
        public override Type NextNode => null;
        public override string Name => IseubiTalkingKeyWords.iseubiName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "那是当然。",
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