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
    public class ArchiveTalkingA : ClosersTalkingTree
    {
        public override string Key => TinaTalkingKeyWords.TinaArchiveTalkingA;
        public override Type FirstNodeType => typeof(ArchiveTalkingA0);
        public override string Owner => TinaKeyWords.Tina;
        public override TalkingScene Scene => TalkingScene.Archives;
    }
    public class ArchiveTalkingA0 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArchiveTalkingA1);
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "露西。",
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
	public class ArchiveTalkingA1 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArchiveTalkingA2);
        public override string Name => TalkingKeyWords.LucyName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "缇娜？",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => TinaTalkingKeyWords.TinaStanding_normal;
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
	public class ArchiveTalkingA2 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArchiveTalkingA3);
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "档案馆没有记录我和李瑟钰的详细信息。",
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
	public class ArchiveTalkingA3 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArchiveTalkingA4);
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "在循环开始时，方舟加载我和李瑟钰的数据时，出现了报错。\n只有我们的身体信息被成功重置，其他数据一概无法重置。",
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
	public class ArchiveTalkingA4 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArchiveTalkingA5);
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "每一次循环，都是这样。",
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
	public class ArchiveTalkingA5 : ClosersTalkingNode
    {
        public override Type NextNode => typeof(ArchiveTalkingA6);
        public override string Name => TalkingKeyWords.LucyName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "那这样的话…你们…",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => TinaTalkingKeyWords.TinaStanding_beloweye;
        public override string FaceChipPath => TalkingKeyWords.LucyFaceChip_nervous;
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
        public override Type NextNode => null;
        public override string Name => TinaTalkingKeyWords.TinaName;
        public override string Content => new TranslationItem()
        {
            
            SimplifiedChinese = "我有很不好的预感。我会在之后把这个发现向李瑟钰报告。",
            TraditionalChinese = "", //todo
            English = "", //todo
            Japanese = "", //todo
            Korean = ""//todo
        }.TransToLocalization;
        public override string StandingPath => TinaTalkingKeyWords.TinaStanding_unhappy;
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