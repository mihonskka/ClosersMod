using ClosersFramework.KeyWords;
using ClosersFramework.Models;
using Dialogical.ParameterSets;
using Dialogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ClosersFramework.Services.Enum;
using ClosersHumanity.KeyWords;
using ChronoArkMod;
using ClosersHumanity.De_Closers;
using ClosersFramework.Services;
using TalkingKeyWords = ClosersHumanity.KeyWords.TalkingKeyWords;

namespace ClosersHumanity.Intro
{
	public class T_IntroP1 : ClosersTalkingTree
	{
		public override string Key => nameof(T_IntroP1);
		public override Type FirstNodeType => typeof(IntroNode0);
		public override string Owner => TalkingKeyWords.PublicTalkingOwner;

		public override TalkingScene Scene => TalkingScene.Others;
	}
	public class IntroNode0 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode1);
		public override string Name => TalkingKeyWords.KonomiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "瑟钰，缇娜，你们来啦。",
			TraditionalChinese = "瑟鈺，緹娜，你們來啦。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => TalkingKeyWords.KonomiStanding_Smile;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_JiangNanCGV);
			var item2 = ScriptableObject.CreateInstance<De_ClosersBGMStart>();
			item2.LoadModel(SoundKeyWords.M_ClosersReadyToGo);
			return new List<DialogueEvent>() { item1, item2 };
		}
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
	public class IntroNode1 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode2);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "安琪儿前辈，我们收到了平原之门发来的简讯。",
			TraditionalChinese = "安琪兒前輩，我們收到了平原之門發來的簡訊。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => TalkingKeyWords.KonomiStanding_Default;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_normal" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_JiangNanCGV);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode2 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode3);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "具体的情况如何？",
			TraditionalChinese = "具體的情況如何？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding1,
			CharacterAssetPath1 = TinaTalkingKeyWords.TinaStanding_normal,
			BrightCharacter0 = false
		});
		public override bool RuntimeStanding => true;

		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_JiangNanCGV);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode3 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode4);
		public override string Name => TalkingKeyWords.KonomiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "嗯，你们来得正好，目前蓝区的【爱娜温庭园】出现了一条次元裂缝，蓝区的次元压力正在和这条次元裂缝进行对抗。",
			TraditionalChinese = "嗯，你們來得正好，目前藍區的【愛娜溫庭園】出現了一條次元裂縫，藍區的次元壓力正在和這條次元裂縫進行對抗。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding1,
			CharacterAssetPath1 = TinaTalkingKeyWords.TinaStanding_normal,
			BrightCharacter1 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_JiangNanCGV);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode4 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode5);
		public override string Name => TalkingKeyWords.KonomiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "昨天纳塔和李世赫已经对裂缝的周边进行了探索。这个裂缝的次元压力异常强大，如果放任不管，很快就会影响到我们的据点。",
			TraditionalChinese = "昨天納塔和李世赫已經對裂縫的周邊進行了探索。這個裂縫的次元壓力異常強大，如果放任不管，很快就會影響到我們的據點。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding7,
			CharacterAssetPath1 = TinaTalkingKeyWords.TinaStanding_normal,
			BrightCharacter1 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_JiangNanCGV);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode5 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode6);
		public override string Name => TalkingKeyWords.KonomiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "所以，希望瑟钰和缇娜前去封印这一裂缝，保护好我们的据点。",
			TraditionalChinese = "所以，希望瑟鈺和緹娜前去封印這一裂縫，保護好我們的據點。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding1,
			CharacterAssetPath1 = TinaTalkingKeyWords.TinaStanding_normal,
			BrightCharacter1 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_JiangNanCGV);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode6 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode7);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "我明白了，但是具体要怎么做？",
			TraditionalChinese = "我明白了，但是具體要怎么做？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding1,
			CharacterAssetPath1 = TinaTalkingKeyWords.TinaStanding_normal,
			BrightCharacter0 = false,
			BrightCharacter1 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_normal" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_JiangNanCGV);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode7 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode8);
		public override string Name => TalkingKeyWords.KonomiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "首先，各位需要先抵达现场。\n李世赫已经在具体的位置设置了信号发射器。",
			TraditionalChinese = "首先，各位需要先抵達現場。\n李世赫已經在具體的位置設置了信號發射器。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding1,
			CharacterAssetPath1 = TinaTalkingKeyWords.TinaStanding_normal,
			BrightCharacter1 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_JiangNanCGV);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode8 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode9);
		public override string Name => TalkingKeyWords.KonomiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "找到裂缝位置后，请瑟钰使用大量的魔力堵塞裂缝。\n这个过程可能要用比较长的时间。",
			TraditionalChinese = "找到裂縫位置后，請瑟鈺使用大量的魔力堵塞裂縫。\n這個過程可能要用比較長的時間。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding1,
			CharacterAssetPath1 = TinaTalkingKeyWords.TinaStanding_normal,
			BrightCharacter1 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_JiangNanCGV);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode9 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode10);
		public override string Name => TalkingKeyWords.KonomiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "在此期间，由于次元压力的影响，附近的次元兽会处于狂躁的状态。\n缇娜请务必保障瑟钰的安全。",
			TraditionalChinese = "在此期間，由于次元壓力的影響，附近的次元獸會處于狂躁的狀態。\n緹娜請務必保障瑟鈺的安全。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding1,
			CharacterAssetPath1 = TinaTalkingKeyWords.TinaStanding_normal,
			BrightCharacter1 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_JiangNanCGV);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode10 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode11);
		public override string Name => TalkingKeyWords.KonomiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "在瑟钰成功封印裂缝后，缇娜请掩护瑟钰进行撤离。",
			TraditionalChinese = "在瑟鈺成功封印裂縫后，緹娜請掩護瑟鈺進行撤離。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding1,
			CharacterAssetPath1 = TinaTalkingKeyWords.TinaStanding_normal,
			BrightCharacter1 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_JiangNanCGV);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode11 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode12);
		public override string Name => TalkingKeyWords.KonomiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "以上就是本次行动的计划。\n昨天调查的信息已经发到邮箱里了。",
			TraditionalChinese = "以上就是本次行動的計劃。\n昨天調查的信息已經發到郵箱里了。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding1,
			CharacterAssetPath1 = TinaTalkingKeyWords.TinaStanding_normal,
			BrightCharacter1 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_JiangNanCGV);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode12 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode13);
		public override string Name => TalkingKeyWords.KonomiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "各位可以先准备一会儿，准备完毕后就在这里集合吧。",
			TraditionalChinese = "各位可以先準備一會兒，準備完畢后就在這里集合吧。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding2,
			CharacterAssetPath1 = TinaTalkingKeyWords.TinaStanding_normal,
			BrightCharacter1 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_JiangNanCGV);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode13 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode14);
		public override string Name => TalkingKeyWords.KonomiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "报告，瑟钰和缇娜已经出发了。",
			TraditionalChinese = "報告，瑟鈺和緹娜已經出發了。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => TalkingKeyWords.KonomiStanding_Default;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item0 = ScriptableObject.CreateInstance<DE_CutSceneEnd>();
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_WhiteFort);
			var item2 = ScriptableObject.CreateInstance<De_ClosersBGMStop>();
			return new List<DialogueEvent>() { item0, item1, item2 };
		}
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
	public class IntroNode14 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode15);
		public override string Name => TalkingKeyWords.OrieName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "应该没有出问题吧。",
			TraditionalChinese = "應該沒有出問題吧。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding1,
			CharacterAssetPath1 = TalkingKeyWords.OrieStanding1,
			BrightCharacter0 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_WhiteFort);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode15 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode16);
		public override string Name => TalkingKeyWords.KonomiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "没有异常。等等…",
			TraditionalChinese = "沒有異常。等等…",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding4,
			CharacterAssetPath1 = TalkingKeyWords.OrieStanding1,
			BrightCharacter1 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_WhiteFort);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode16 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode17);
		public override string Name => TalkingKeyWords.KonomiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "瑟钰和缇娜传来了求救信号。",
			TraditionalChinese = "瑟鈺和緹娜傳來了求救信號。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding4,
			CharacterAssetPath1 = TalkingKeyWords.OrieStanding1,
			BrightCharacter1 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_WhiteFort);
			var item2 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			item2.LoadModel(SoundKeyWords.COA_iM);
			var item3 = ScriptableObject.CreateInstance<De_ClosersBGMStart>();
			item3.LoadModel(SoundKeyWords.COM_OutBreak);
			return new List<DialogueEvent>() { item1, item2, item3 };
		}
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
	public class IntroNode17 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode18);
		public override string Name => TalkingKeyWords.OrieName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "怎么回事？她们怎么了？",
			TraditionalChinese = "怎么回事？她們怎么了？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding9,
			CharacterAssetPath1 = TalkingKeyWords.OrieStanding4,
			BrightCharacter0 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_WhiteFort);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode18 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode19);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "次元裂缝在迅速扩大！我们被吸进去了！",
			TraditionalChinese = "次元裂縫在迅速擴大！我們被吸進去了！",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding9,
			CharacterAssetPath1 = TalkingKeyWords.OrieStanding4,
			BrightCharacter0 = false,
			BrightCharacter1 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_WhiteFort);
			return new List<DialogueEvent>() { item1 };
		}//无线电噪音
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
	public class IntroNode19 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode20);
		public override string Name => TalkingKeyWords.OrieName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "你们周围的情况怎样？我这就派其他封印者来增援！",
			TraditionalChinese = "你們周圍的情況怎樣？我這就派其他封印者來增援！",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding9,
			CharacterAssetPath1 = TalkingKeyWords.OrieStanding4,
			BrightCharacter0 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_WhiteFort);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode20 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode21);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "周围是森林，就像在晚上，还有黑色的迷雾。",
			TraditionalChinese = "周圍是森林，就像在晚上，還有黑色的迷霧。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding9,
			CharacterAssetPath1 = TalkingKeyWords.OrieStanding4,
			BrightCharacter0 = false,
			BrightCharacter1 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_WhiteFort);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode21 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode22);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "我们好像被传送走了，我不知道我在哪里！坐标也没法计算！",
			TraditionalChinese = "我們好像被傳送走了，我不知道我在哪里！坐標也沒法計算！",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding9,
			CharacterAssetPath1 = TalkingKeyWords.OrieStanding4,
			BrightCharacter0 = false,
			BrightCharacter1 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_WhiteFort);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode22 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode23);
		public override string Name => TalkingKeyWords.OrieName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "先保持在原地，不要移动。黑羊小队和红狼小队的其他成员已经在路上了。",
			TraditionalChinese = "先保持在原地，不要移動。黑羊小隊和紅狼小隊的其他成員已經在路上了。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding9,
			CharacterAssetPath1 = TalkingKeyWords.OrieStanding4,
			BrightCharacter0 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_WhiteFort);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode23 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode24);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "  遇到了  ，     面具，  很多！   危险！",
			TraditionalChinese = "  遇到了  ，     面具，  很多！   危險！",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding9,
			CharacterAssetPath1 = TalkingKeyWords.OrieStanding4,
			BrightCharacter0 = false,
			BrightCharacter1 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_WhiteFort);
			var item2 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			item2.LoadModel(SoundKeyWords.COA_NoiseMemory);
			return new List<DialogueEvent>() { item1, item2 };
		}
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
	public class IntroNode24 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode25);
		public override string Name => TalkingKeyWords.KonomiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "信号被干扰了！",
			TraditionalChinese = "信號被干擾了！",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding4,
			CharacterAssetPath1 = TalkingKeyWords.OrieStanding4,
			BrightCharacter1 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_WhiteFort);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode25 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode26);
		public override string Name => TalkingKeyWords.OrieName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "保护好自己的安全，我们会救你们出来的！",
			TraditionalChinese = "保護好自己的安全，我們會救你們出來的！",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TalkingKeyWords.KonomiStanding9,
			CharacterAssetPath1 = TalkingKeyWords.OrieStanding4,
			BrightCharacter0 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => "todo";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_WhiteFort);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode26 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode27);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "通讯完全被切断了。",
			TraditionalChinese = "通訊完全被切斷了。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => TinaTalkingKeyWords.TinaStanding_beloweye;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item0 = ScriptableObject.CreateInstance<DE_FadeOut>();
			var item1 = ScriptableObject.CreateInstance<DE_CutSceneEnd>();
			var item2 = ScriptableObject.CreateInstance<DE_Wait>();
			item2.WaitTime = 2;
			var item3 = ScriptableObject.CreateInstance<DE_CutScene>();
			item3.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_WhiteFort);
			return new List<DialogueEvent>() { item0, item1, item2, item3 };
		}
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
	public class IntroNode27 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode28);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "可恶，我都没听清楚最后的几句话。",
			TraditionalChinese = "可惡，我都沒聽清楚最后的幾句話。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => TinaTalkingKeyWords.TinaStanding_beloweye;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_strict" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode28 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroNode29);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "这家伙，我感受不到魔力，看起来不是次元兽。",
			TraditionalChinese = "這家伙，我感受不到魔力，看起來不是次元獸。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => "Assets/ClosersMod/Standing/Ark/GolemInDialogue.png";
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_strict" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
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
	public class IntroNode29 : ClosersTalkingNode
	{
		public override Type NextNode => null;
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "做好迎击准备！",
			TraditionalChinese = "做好迎擊準備！",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => "Assets/ClosersMod/Standing/Ark/GolemInDialogue.png";
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_strict" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
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

