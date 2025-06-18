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
using static ClosersFramework.Services.Enum;
using TalkingKeyWords = ClosersHumanity.KeyWords.TalkingKeyWords;

namespace ClosersTina.Talking
{
    public class ForeKingA : ClosersTalkingTree
    {
        public override string Key => TinaTalkingKeyWords.TinaForeKingA;
        public override Type FirstNodeType => typeof(ForeKingA0);
        public override string Owner => TinaKeyWords.Tina;
        public override TalkingScene Scene => TalkingScene.ForeKing;
    }
    public class ForeKingA0 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ForeKingA1);
        public override string Name => TalkingKeyWords.LucyName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "最后一个时光之影在他那里。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
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
	public class ForeKingA1 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ForeKingA2);
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "看来不得不打败他然后夺取时光之影了。",
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
	public class ForeKingA2 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ForeKingA3);
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "这样的敌人，子弹可能打不穿他的盔甲。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => TinaTalkingKeyWords.TinaStanding_beloweye;
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
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "但是没关系，我的爆炸物还有很多。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => TinaTalkingKeyWords.TinaStanding_beloweye;
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
            
            SimplifiedChinese = "会赢吗？",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => TinaTalkingKeyWords.TinaStanding_beloweye;
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
	public class ForeKingA5 : ClosersTalkingNode
    {
        public override Type NextNode => null;
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "会赢的。",
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
}