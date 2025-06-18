using ChronoArkMod;
using ClosersFramework.KeyWords;
using ClosersFramework.Models;
using ClosersFramework.Services;
using ClosersFramework.Templates;
using ClosersHumanity.De_Closers;
using ClosersHumanity.KeyWords;
using Dialogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ClosersFramework.Services.Enum;
using TalkingKeyWords = ClosersHumanity.KeyWords.TalkingKeyWords;

namespace ClosersHumanity.Intro
{
	public class T_IntroP2 : ClosersTalkingTree
	{
		public override string Key => IseubiTalkingKeyWords.iseubiArkTalkingA;
		public override Type FirstNodeType => typeof(Intro2Node_1);
		public override string Owner => TalkingKeyWords.PublicTalkingOwner;

		public override TalkingScene Scene => TalkingScene.Others;
	}
	public class Intro2Node_1 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node0);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "虽然这个“石巨人”的体型很庞大，但还好它并不强。",
			TraditionalChinese = "雖然這個“石巨人”的體型很龐大，但還好它并不強。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => TinaTalkingKeyWords.TinaStanding_normal;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			//var item2 = ScriptableObject.CreateInstance<De_ClosersBGMStop>();
			var item2 = ScriptableObject.CreateInstance<De_ClosersBGMStart>();
			item2.LoadModel(SoundKeyWords.COM_CampAmbi);
			return new List<DialogueEvent>() { item1, item2};
		}
	}
	public class Intro2Node0 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node1);
		public override string Name => TalkingKeyWords.HeinName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "你们两个别动！",
			TraditionalChinese = "你們兩個別動！",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Default,
			BrightCharacter0 = false
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			var item2 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			item2.LoadModel(SoundKeyWords.COA_iM);
			return new List<DialogueEvent>() { item1, item2 };
		}
	}
	public class Intro2Node1 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node2);
		public override string Name => TalkingKeyWords.LianName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "你们是谁？你们在这里做什么？",
			TraditionalChinese = "你們是誰？你們在這里做什么？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Default,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Default,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node2 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node3);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "我们是来自Union的封印者，在外部次元行动的过程中被传送来到这里。我们没有敌意。",
			TraditionalChinese = "我們是來自Union的封印者，在外部次元行動的過程中被傳送來到這里。我們沒有敵意。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Default,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Default,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_normal" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node3 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node4);
		public override string Name => TalkingKeyWords.HeinName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "哈？封印者？外部次元？你这家伙在说什么乱七八糟的！",
			TraditionalChinese = "哈？封印者？外部次元？你這家伙在說什么亂七八糟的！",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Angry2,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node4 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node5);
		public override string Name => TalkingKeyWords.LianName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "冷静一点，海因。",
			TraditionalChinese = "冷靜一點，海因。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Angry1,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Default2,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node5 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node6);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "他们好像不知道union和封印者。看他们的着装，似乎更像是cosplay。",
			TraditionalChinese = "他們好像不知道union和封印者。看他們的著裝，似乎更像是cosplay。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_beloweye,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Default,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Default,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node6 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node7);
		public override string Name => TalkingKeyWords.LianName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "虽然不知道你们在说什么，但是看你们打败了石魔，我姑且相信你们不是怪物。",
			TraditionalChinese = "雖然不知道你們在說什么，但是看你們打敗了石魔，我姑且相信你們不是怪物。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Default,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Default2,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node7 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node8);
		public override string Name => TalkingKeyWords.LianName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "侦查任务差不多结束了，我们带她们回方舟吧。",
			TraditionalChinese = "偵查任務差不多結束了，我們帶她們回方舟吧。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Default,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Default2,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node8 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node9);
		public override string Name => TalkingKeyWords.HeinName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "为什么？我有意见！这么轻易地就相信她们？万一她们是破坏分子呢？！",
			TraditionalChinese = "為什么？我有意見！這么輕易地就相信她們？萬一她們是破壞分子呢？！",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Angry2,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			var item2 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			item2.LoadModel(SoundKeyWords.COA_iM);
			return new List<DialogueEvent>() { item1, item2 };
		}
	}
	public class Intro2Node9 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node10);
		public override string Name => TalkingKeyWords.LianName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "那把她们留在这里？还是说你有更好的地方？",
			TraditionalChinese = "那把她們留在這里？還是說你有更好的地方？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Embarrass1,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Default2,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node10 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node11);
		public override string Name => TalkingKeyWords.LianName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "误入扭曲之地的人并不少，调查团已经不是第一次寻回这种人了。",
			TraditionalChinese = "誤入扭曲之地的人并不少，調查團已經不是第一次尋回這種人了。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Embarrass1,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Default2,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node11 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node12);
		public override string Name => TalkingKeyWords.HeinName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "……",
			TraditionalChinese = "……",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Sigh1,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			var item2 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			item2.LoadModel(SoundKeyWords.COA_Fail);
			return new List<DialogueEvent>() { item1, item2 };
		}
	}
	public class Intro2Node12 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node13);
		public override string Name => TalkingKeyWords.LianName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "跟我们回去吧，你们二位怎么称呼？",
			TraditionalChinese = "跟我們回去吧，你們二位怎么稱呼？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Default,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Smile2,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node13 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node14);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "李瑟钰。",
			TraditionalChinese = "李瑟鈺。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Default,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Smile1,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_normal" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node14 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node15);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "我叫缇娜。",
			TraditionalChinese = "我叫緹娜。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Default,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Default,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node15 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node16);
		public override string Name => TalkingKeyWords.LianName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "缇娜，这个名字挺常见的。\n李瑟钰…这名字也太特别了吧。",
			TraditionalChinese = "緹娜，這個名字挺常見的。\n李瑟鈺…這名字也太特別了吧。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Default,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Default2,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node16 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node17);
		public override string Name => TalkingKeyWords.LianName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "我叫莉安，是方舟的调查团团长。那位是调查团的成员海因。",
			TraditionalChinese = "我叫莉安，是方舟的調查團團長。那位是調查團的成員海因。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Default,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Smile2,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node17 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node18);
		public override string Name => TalkingKeyWords.HeinName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "你们刚才说你们是封印者？",
			TraditionalChinese = "你們剛才說你們是封印者？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Smile1,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node18 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node19);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "是。",
			TraditionalChinese = "是。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Smile1,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Default,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node19 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node20);
		public override string Name => TalkingKeyWords.HeinName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "方舟那边有个叫卡伦的人，应该会和你们相处得比较好。",
			TraditionalChinese = "方舟那邊有個叫卡倫的人，應該會和你們相處得比較好。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_HeinR_Smile2,
			CharacterAssetPath2 = TalkingKeyWords.St_LianRogue_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_Forest);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node20 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node21);
		public override string Name => TalkingKeyWords.LianName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "你们二位就先住在这边吧。",
			TraditionalChinese = "你們二位就先住在這邊吧。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.St_LianRogue_Default,
			BrightCharacter0 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			var item2 = ScriptableObject.CreateInstance<DE_Wait>();
			item2.WaitTime = 2;
			var item3 = ScriptableObject.CreateInstance<De_ClosersBGMStart>();
			item3.LoadModel(SoundKeyWords.COM_ArkSight);
			var item4 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			item4.LoadModel(SoundKeyWords.COA_Walking);
			return new List<DialogueEvent>() { item1, item2, item3, item4 };
		}
	}
	public class Intro2Node21 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node22);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "谢谢你。",
			TraditionalChinese = "謝謝你。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_smile,
			CharacterAssetPath1 = TalkingKeyWords.St_LianRogue_Default,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node22 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node23);
		public override string Name => TalkingKeyWords.LianName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "这附近有酒馆和杂货店。如果有需要的话可以用这袋盘缠去买东西。",
			TraditionalChinese = "這附近有酒館和雜貨店。如果有需要的話可以用這袋盤纏去買東西。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_smile,
			CharacterAssetPath1 = TalkingKeyWords.St_LianRogue_Default,
			BrightCharacter0 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node23 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node24);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "多谢了，都不知道该怎么回报你了。",
			TraditionalChinese = "多謝了，都不知道該怎么回報你了。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_smile,
			CharacterAssetPath1 = TalkingKeyWords.St_LianRogue_Default,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node24 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node25);
		public override string Name => TalkingKeyWords.LianName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "不必客气，这是刚才讨伐石魔的报酬。\n石魔还挺难处理的，倒是我该替调查团感谢你们。",
			TraditionalChinese = "不必客氣，這是剛才討伐石魔的報酬。\n石魔還挺難處理的，倒是我該替調查團感謝你們。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_smile,
			CharacterAssetPath1 = TalkingKeyWords.St_LianRogue_Smile1,
			BrightCharacter0 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node25 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(Intro2Node26);
		public override string Name => TalkingKeyWords.LianName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "我先回去了，有需要的话可以来调查团找我。",
			TraditionalChinese = "我先回去了，有需要的話可以來調查團找我。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_smile,
			CharacterAssetPath1 = TalkingKeyWords.St_LianRogue_Smile1,
			BrightCharacter0 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class Intro2Node26 : ClosersTalkingNode
	{
		public override Type NextNode => null;
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "慢走，莉安团长。",
			TraditionalChinese = "慢走，莉安團長。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 2,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_smile,
			CharacterAssetPath1 = TalkingKeyWords.St_LianRogue_Smile1,
			BrightCharacter0 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_smile" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
}