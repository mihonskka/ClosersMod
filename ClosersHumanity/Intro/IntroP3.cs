using ChronoArkMod;
using ChronoArkMod.DialogueCreate;
using ClosersFramework.KeyWords;
using ClosersFramework.Models;
using ClosersFramework.Services;
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
	public class T_IntroP3 : ClosersTalkingTree
	{
		public override string Key => IseubiTalkingKeyWords.iseubiArkTalkingA;
		public override Type FirstNodeType => typeof(IntroP3Node0);
        public override string Owner => TalkingKeyWords.PublicTalkingOwner;

		public override TalkingScene Scene => TalkingScene.Others;
	}
	public class IntroP3Node0 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node1);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "她回去了。",
			TraditionalChinese = "她回去了。",
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
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			var item2 = ScriptableObject.CreateInstance<De_ClosersBGMStart>();
			item2.LoadModel(SoundKeyWords.COM_bangjoo);
			return new List<DialogueEvent>() { item1, item2 };
		}
	}
	public class IntroP3Node1 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node2);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "这到底是哪里？",
			TraditionalChinese = "這到底是哪里？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => TinaTalkingKeyWords.TinaStanding_normal;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_strict" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node2 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node3);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "她给我们的货币，黄色的圆形钱币，似乎是金质的。可没有哪国会直接用黄金进行交易。",
			TraditionalChinese = "她給我們的貨幣，黃色的圓形錢幣，似乎是金質的。可沒有哪國會直接用黃金進行交易。",
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
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node3 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node4);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "没有收到新首尔支部的信号，其他信号也没有。\nGPS、BDS也没法定位到我们这里。", 

			TraditionalChinese = "沒有收到新首爾支部的信號，其他信號也沒有。\nGPS、BDS也沒法定位到我們這里。",

			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => TinaTalkingKeyWords.TinaStanding_beloweye;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node4 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node5);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "他们管这里叫方舟？我们刚刚的那个地方叫扭曲之地？这是什么，游戏设定么？",
			TraditionalChinese = "他們管這里叫方舟？我們剛剛的那個地方叫扭曲之地？這是什么，游戲設定么？",
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
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			var item2 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			item2.LoadModel(SoundKeyWords.COA_Idea);
			return new List<DialogueEvent>() { item1, item2 };
		}
	}
	public class IntroP3Node5 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node6);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "我甚至不敢说我们还在外部次元。",
			TraditionalChinese = "我甚至不敢說我們還在外部次元。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => TinaTalkingKeyWords.TinaStanding_beloweye;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node6 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node7);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "我也发现了，这里没有外部次元压力。就好像，我们到一个新世界了一样。",
			TraditionalChinese = "我也發現了，這里沒有外部次元壓力。就好像，我們到一個新世界了一樣。",
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
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node7 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node8);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "有可能真的是到一个新世界了。",
			TraditionalChinese = "有可能真的是到一個新世界了。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => TinaTalkingKeyWords.TinaStanding_beloweye;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node8 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node9);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "之前在扭曲之地的时候，我还想试一下开虫洞传送回去。但是我甚至都感受不到我之前残留的魔力。",
			TraditionalChinese = "之前在扭曲之地的時候，我還想試一下開蟲洞傳送回去。但是我甚至都感受不到我之前殘留的魔力。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => TinaTalkingKeyWords.TinaStanding_normal;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_upset" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node9 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node10);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "先在这里生活一段时间吧，之后我们回我们刚来的那个地方，说不定有回去的线索。",
			TraditionalChinese = "先在這里生活一段時間吧，之后我們回我們剛來的那個地方，說不定有回去的線索。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => TinaTalkingKeyWords.TinaStanding_normal;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_unhappy" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node10 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node11);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "遵命，我还记着过来时的路径。",
			TraditionalChinese = "遵命，我還記著過來時的路徑。",
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
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node11 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node12);
		public override string Name => "？？？";
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "请问李瑟钰小姐和缇娜小姐在么？",
			TraditionalChinese = "請問李瑟鈺小姐和緹娜小姐在么？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => string.Empty;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			var item2 = ScriptableObject.CreateInstance<DE_Wait>();
			item2.WaitTime = 1;
			var item3 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			item3.LoadModel(SoundKeyWords.A_Knockout);
			return new List<DialogueEvent>() { item1, item2, item3 };
		}
	}
	public class IntroP3Node12 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node13);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "有客人？",
			TraditionalChinese = "有客人？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => string.Empty;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_normal" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node13 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node14);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "请进。",
			TraditionalChinese = "請進。",
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
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			var item2 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			item2.LoadModel(SoundKeyWords.COA_DoorOpen);
			return new List<DialogueEvent>() { item1, item2 };
		}
	}
	public class IntroP3Node14 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node15);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "请问这位先生是？\n你的宠物好亮。",
			TraditionalChinese = "請問這位先生是？\n你的寵物好亮。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_normal" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node15 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node16);
		public override string Name => TalkingKeyWords.PhoenixName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "才不是宠物！",
			TraditionalChinese = "才不是寵物！",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Angry2,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			var item2 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			item2.LoadModel(SoundKeyWords.COA_sh);
			return new List<DialogueEvent>() { item1, item2 };
		}
	}
	public class IntroP3Node16 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node17);
		public override string Name => TalkingKeyWords.PhoenixName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "我可是传说中的神兽凤凰！",
			TraditionalChinese = "我可是傳說中的神獸鳳凰！",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Angry2,
			BrightCharacter0 = false,
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
	public class IntroP3Node17 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node18);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "鸟在说话？！难道是鹦鹉？",
			TraditionalChinese = "鳥在說話？！難道是鸚鵡？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Angry2,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_strict" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node18 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node19);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "帕切斯的布谷鸟也是鸟，也会说话。",
			TraditionalChinese = "帕切斯的布谷鳥也是鳥，也會說話。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_smile,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Angry2,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node19 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node20);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "布谷鸟是无人机啊！不是真的鸟呀！",
			TraditionalChinese = "布谷鳥是無人機啊！不是真的鳥呀！",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_smile,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Angry2,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_nervous" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			var item2 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			item2.LoadModel(SoundKeyWords.COA_Fail);
			return new List<DialogueEvent>() { item1, item2 };
		}
	}
	public class IntroP3Node20 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node21);
		public override string Name => TalkingKeyWords.PhoenixName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "都说了我不是鸟！是凤凰！",
			TraditionalChinese = "都說了我不是鳥！是鳳凰！",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_smile,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Angry2,
			BrightCharacter0 = false,
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
	public class IntroP3Node21 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node22);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "冒昧了，凤凰是我的同伴。我叫阿扎尔，是调查团的团员。",
			TraditionalChinese = "冒昧了，鳳凰是我的同伴。我叫阿扎爾，是調查團的團員。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_1_3,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Angry1,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node22 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node23);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "调查团……派我来询问一下你们是如何来到扭曲之地的。",
			TraditionalChinese = "調查團……派我來詢問一下你們是如何來到扭曲之地的。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_1_3,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node23 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node24);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "方舟的大门没有你们的出境记录，而且方舟居民名单上也没有你们的名字。",
			TraditionalChinese = "方舟的大門沒有你們的出境記錄，而且方舟居民名單上也沒有你們的名字。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_5_3,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node24 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node25);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "不是已经和你们的调查团长说过了么？",
			TraditionalChinese = "不是已經和你們的調查團長說過了么？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_5_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_unhappy" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node25 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node26);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "再和我陈述一遍也无妨。这是我的调查团证件。",
			TraditionalChinese = "再和我陳述一遍也無妨。這是我的調查團證件。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_5_3,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node26 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node27);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "好吧，倒也不是什么不好说的事。",
			TraditionalChinese = "好吧，倒也不是什么不好說的事。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_5_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_unhappy" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node27 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node28);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "我们是Union的封印者，在外部次元填补次元裂缝的过程中遭遇意外，不慎被次元裂缝吸入。就像一瞬间的事情，就被传送到了外面的森林……",
			TraditionalChinese = "我們是Union的封印者，在外部次元填補次元裂縫的過程中遭遇意外，不慎被次元裂縫吸入。就像一瞬間的事情，就被傳送到了外面的森林……",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_5_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_normal" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node28 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node29);
		public override string Name => TalkingKeyWords.PhoenixName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "……就像是在听卡伦讲那些中二的台词。",
			TraditionalChinese = "……就像是在聽卡倫講那些中二的臺詞。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_1_3,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Embarrass,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			var item2 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			item2.LoadModel(SoundKeyWords.COA_Fail);
			return new List<DialogueEvent>() { item1, item2 };
		}
	}
	public class IntroP3Node29 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node30);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "（瑟钰，你说这些他们听不懂的。）",
			TraditionalChinese = "（瑟鈺，你說這些他們聽不懂的。）",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_1_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Embarrass,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node30 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node31);
		public override string Name => TalkingKeyWords.AzarName;
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
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_1,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Embarrass,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node31 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node32);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "好吧，我记下了。",
			TraditionalChinese = "好吧，我記下了。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_1,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Embarrass,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node32 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node33);
		public override string Name => TalkingKeyWords.PhoenixName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "总之就是，不知道怎么回事，啪的一下，就来了咯。",
			TraditionalChinese = "總之就是，不知道怎么回事，啪的一下，就來了咯。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_1_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Embarrass,
			BrightCharacter0 = false,
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
	public class IntroP3Node33 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node34);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "是的。",
			TraditionalChinese = "是的。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_1_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Embarrass,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node34 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node35);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "对了，刚才我在路上遇到了调查团长。她让我帮忙问一下。",
			TraditionalChinese = "對了，剛才我在路上遇到了調查團長。她讓我幫忙問一下。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			var item2 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			item2.LoadModel(SoundKeyWords.COA_Idea);
			return new List<DialogueEvent>() { item1, item2 };
		}
	}
	public class IntroP3Node35 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node36);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "缇娜，刚才遇到的石魔，是被你独自打败的吗？",
			TraditionalChinese = "緹娜，剛才遇到的石魔，是被你獨自打敗的嗎？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node36 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node37);
		public override string Name => string.Empty;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "（李瑟钰向缇娜使了个眼神。）",
			TraditionalChinese = "（李瑟鈺向緹娜使了個眼神。）",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_normal" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node37 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node38);
		public override string Name => string.Empty;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "（缇娜点了点头。）",
			TraditionalChinese = "（緹娜點了點頭。）",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node38 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node39);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "对，是我打倒的。石魔并没有想象中那么强。",
			TraditionalChinese = "對，是我打倒的。石魔并沒有想象中那么強。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node39 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node40);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "团长希望你能加入调查团，并且以精英队员的待遇雇佣你。",
			TraditionalChinese = "團長希望你能加入調查團，并且以精英隊員的待遇雇傭你。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node40 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node41);
		public override string Name => string.Empty;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "",
			TraditionalChinese = "",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_beloweye,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_upset" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node41 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node42);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "嗯。",
			TraditionalChinese = "嗯。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_smile,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node42 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node43);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "调查团的成员需要经常去扭曲之地探索，对吧。",
			TraditionalChinese = "調查團的成員需要經常去扭曲之地探索，對吧。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node43 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node44);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "对不起，请您转告团长，我不想离李瑟钰太远，可否有其他不常远行的工作？",
			TraditionalChinese = "對不起，請您轉告團長，我不想離李瑟鈺太遠，可否有其他不常遠行的工作？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node44 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node45);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "当然也有，团长可以把你推荐到方舟防御人员那边。",
			TraditionalChinese = "當然也有，團長可以把你推薦到方舟防御人員那邊。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_3_1,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node45 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node46);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "只需要在方舟巡逻就可以，工作很轻松。你也可以天天见到李瑟钰小姐。",
			TraditionalChinese = "只需要在方舟巡邏就可以，工作很輕松。你也可以天天見到李瑟鈺小姐。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_smile,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_3_1,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node46 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node47);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "或许是一个不错的选择，瑟钰你觉得呢？",
			TraditionalChinese = "或許是一個不錯的選擇，瑟鈺你覺得呢？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_smile,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_3,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node47 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node48);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "要想这里生活下去，还是需要有个工作的。",
			TraditionalChinese = "要想這里生活下去，還是需要有個工作的。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_smile,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_3,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node48 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node49);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "那我一会儿去跟团长转告咯。",
			TraditionalChinese = "那我一會兒去跟團長轉告咯。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_smile,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_4_1,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node49 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node50);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "接下来是一些基本的信息登记。",
			TraditionalChinese = "接下來是一些基本的信息登記。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node50 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node51);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "二位的姓名是？",
			TraditionalChinese = "二位的姓名是？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node51 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node52);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "我叫李瑟钰，她叫缇娜。",
			TraditionalChinese = "我叫李瑟鈺，她叫緹娜。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_normal" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node52 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node52_1);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "二位是什么关系？",
			TraditionalChinese = "二位是什么關系？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
		public override IEnumerable<Type> OptionCreatorTypes => base.OptionCreatorTypes;
	}

	public class IntroP3Node52_1 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node53);
		public override string Name => string.Empty;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "你希望我如何回答呢？",
			TraditionalChinese = "你希望我如何回答呢？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
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
		public override IEnumerable<Type> OptionCreatorTypes => new List<Type> { typeof(IntroP3Node52O1), typeof(IntroP3Node52O2) , typeof(IntroP3Node52O3) };
	}

	public class IntroP3Node52O1 : ClosersTalkingOption
	{
		public override Type GoTo => typeof(IntroP3Node52O1_1);

		public override string Text => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "同事",
			TraditionalChinese = "同事",
			English = "Workmate.", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
	}

	public class IntroP3Node52O1_1 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node52O1_2);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "同事关系罢了。",
			TraditionalChinese = "同事關係罷了。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_normal" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node52O1_2 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node53);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "嗯，下一个问题。",
			TraditionalChinese = "嗯，下一個問題。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_unhappy,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_3_1,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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

	public class IntroP3Node52O2 : ClosersTalkingOption
	{
		public override Type GoTo => typeof(IntroP3Node52O2_1);

		public override string Text => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "挚友",
			TraditionalChinese = "摯友",
			English = "Good friend",
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
	}

	public class IntroP3Node52O2_1 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node52O2_2);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "缇娜是我的挚友。",
			TraditionalChinese = "緹娜是我的摯友。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node52O2_2 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node53);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "看来二位关系很好啊。",
			TraditionalChinese = "看來二位關係很好啊。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_smile,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_3_1,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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

	public class IntroP3Node52O3 : ClosersTalkingOption
	{
		public override Type GoTo => typeof(IntroP3Node52O3_1);

		public override string Text => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "恋人",
			TraditionalChinese = "戀人",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
	}

	public class IntroP3Node52O3_1 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node52O3_2);
		public override string Name => string.Empty;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "（我挽住了缇娜的手）",
			TraditionalChinese = "（我挽住了緹娜的手）",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_shy" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}

	public class IntroP3Node52O3_2 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node52O3_3);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "恋人关系。",
			TraditionalChinese = "戀人關係。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_nervous,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_shy" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node52O3_3 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node52O3_4);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "……对。",
			TraditionalChinese = "……對。",
			English = "...Yes",
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_nervous,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_1_3,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Question2,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node52O3_4 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node52O3_5);
		public override string Name => TalkingKeyWords.PhoenixName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "哈？你认真的么？",
			TraditionalChinese = "哈？你認真的麼？",
			English = "Wait wait wait, are you sure?!",
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_nervous,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_1_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Question2,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			//var item2 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			//item2.LoadModel(SoundKeyWords.COA_sh);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node52O3_5 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node52O3_6);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "当然咯，我们已经相爱很久啦。",
			TraditionalChinese = "當然咯，我們已經相愛很久啦。",
			English = "",
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_smile,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_1_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Question2,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_shy" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node52O3_6 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node53);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "罢了，下一个问题。",
			TraditionalChinese = "罷了，下一個問題。",
			English = "",
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_smile,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_1_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Question2,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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


	public class IntroP3Node53 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node54);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "出生地。",
			TraditionalChinese = "出生地。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node54 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node55);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "丽水市。",
			TraditionalChinese = "麗水市。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_normal" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node55 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node56);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "韩国汉城。",
			TraditionalChinese = "韓國漢城。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node56 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node57);
		public override string Name => TalkingKeyWords.PhoenixName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "都是我没听过的地方。",
			TraditionalChinese = "都是我沒聽過的地方。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_1_1,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Embarrass,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node57 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node58);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "年龄。",
			TraditionalChinese = "年齡。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node58 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node59);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "18岁。",
			TraditionalChinese = "18歲。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_normal" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node59 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node60);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "（说你的人类年龄，缇娜。）",
			TraditionalChinese = "（說你的人類年齡，緹娜。）",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_normal" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node60 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node61);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "14岁。",
			TraditionalChinese = "14歲。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node61 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node62);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "身高体重。",
			TraditionalChinese = "身高體重。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node62 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node63);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "156cm，45kg。",
			TraditionalChinese = "156cm，45kg。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node63 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node64);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "嗯，啊……\n一米五五，80斤。",
			TraditionalChinese = "嗯，啊……\n一米五五，80斤。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_nervous" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node64 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node65);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "三围。",
			TraditionalChinese = "三圍。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node65 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node66);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "B74、W57、H77",
			TraditionalChinese = "B74、W57、H77",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter1 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node66 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node67);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "71、52、75……等等问这些是要做什么啊！",
			TraditionalChinese = "71、52、75……等等問這些是要做什么啊！",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_nervous" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			//var item2 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			//item2.LoadModel(SoundKeyWords.COA_sh);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node67 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node68);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "基本的健康登记而已。\n有没有什么身体不舒服，或者感觉不正常的？",
			TraditionalChinese = "基本的健康登記而已。\n有沒有什么身體不舒服，或者感覺不正常的？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_5_1,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node68 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node69);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "暂时还没有，只是我有点不太知道这是哪里？什么是方舟？",
			TraditionalChinese = "暫時還沒有，只是我有點不太知道這是哪里？什么是方舟？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_5,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_normal" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node69 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node70);
		public override string Name => TalkingKeyWords.PhoenixName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "咳咳，就让本神兽来为你们讲解一下吧。",
			TraditionalChinese = "咳咳，就讓本神獸來為你們講解一下吧。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Proud2,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			var item2 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			item2.LoadModel(SoundKeyWords.COA_fl);
			return new List<DialogueEvent>() { item1, item2 };
		}
	}
	public class IntroP3Node70 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node71);
		public override string Name => TalkingKeyWords.PhoenixName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "大概几百年前，人类在这里定居，那时候世界一片祥和。",
			TraditionalChinese = "大概幾百年前，人類在這里定居，那時候世界一片祥和。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Stretch2,
			BrightCharacter0 = false,
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
	public class IntroP3Node71 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node72);
		public override string Name => TalkingKeyWords.PhoenixName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "但是渐渐的，随着时间的流逝，历史的车轮滚滚向前，人类的领地不断扩张。这里的怪物变得越来越多，同时还出现了景色多变的扭曲之地和杀人的黑色迷雾。",
			TraditionalChinese = "但是漸漸的，隨著時間的流逝，歷史的車輪滾滾向前，人類的領地不斷擴張。這里的怪物變得越來越多，同時還出現了景色多變的扭曲之地和殺人的黑色迷霧。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default2,
			BrightCharacter0 = false,
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
	public class IntroP3Node72 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node73);
		public override string Name => TalkingKeyWords.PhoenixName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "为了生存下去，我们将定居点保护起来，防止黑色迷雾和怪物的入侵。",
			TraditionalChinese = "為了生存下去，我們將定居點保護起來，防止黑色迷霧和怪物的入侵。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Think2,
			BrightCharacter0 = false,
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
	public class IntroP3Node73 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node74);
		public override string Name => TalkingKeyWords.PhoenixName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "但我们依然希望世界重归和平，于是我们等待着一位预言少女的到来，她的名字叫露西。",
			TraditionalChinese = "但我們依然希望世界重歸和平，于是我們等待著一位預言少女的到來，她的名字叫露西。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Talk2,
			BrightCharacter0 = false,
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
	public class IntroP3Node74 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node75);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "露西？",
			TraditionalChinese = "露西？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Talk2,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_strict" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			var item2 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			item2.LoadModel(SoundKeyWords.COA_Idea);
			return new List<DialogueEvent>() { item1, item2 };
		}
	}
	public class IntroP3Node75 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node76);
		public override string Name => TalkingKeyWords.PhoenixName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "是的，她会带领我们探索扭曲之地，收集一个名为“时光之影”的道具，然后用时光之影启动钟楼。这样世界就能回到80年前。",
			TraditionalChinese = "是的，她會帶領我們探索扭曲之地，收集一個名為“時光之影”的道具，然后用時光之影啟動鐘樓。這樣世界就能回到80年前。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Giggle2,
			BrightCharacter0 = false,
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
	public class IntroP3Node76 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node77);
		public override string Name => TalkingKeyWords.PhoenixName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "那个时候我们的世界仍然很和平，没有这么多的怪物，也没有黑色迷雾。\n这样我们就有充足的时间应对扭曲之地和黑色迷雾的扩散。",
			TraditionalChinese = "那個時候我們的世界仍然很和平，沒有這么多的怪物，也沒有黑色迷霧。\n這樣我們就有充足的時間應對扭曲之地和黑色迷霧的擴散。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Giggle2,
			BrightCharacter0 = false,
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
	public class IntroP3Node77 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node78);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "嗯……嗯。",
			TraditionalChinese = "嗯……嗯。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Proud1,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_unhappy" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node78 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node79);
		public override string Name => TalkingKeyWords.PhoenixName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "差不多就是这样，有什么疑问么？",
			TraditionalChinese = "差不多就是這樣，有什么疑問么？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Proud2,
			BrightCharacter0 = false,
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
	public class IntroP3Node79 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node80);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "没有了。",
			TraditionalChinese = "沒有了。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_0,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Proud2,
			BrightCharacter0 = false,
			BrightCharacter1 = false,
		});
		public override bool RuntimeStanding => true;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_unhappy" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node80 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node81);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "看起来也没有什么别的能问出来的了。",
			TraditionalChinese = "看起來也沒有什么別的能問出來的了。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_5_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node81 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node82);
		public override string Name => TalkingKeyWords.PhoenixName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "阿扎尔，时间差不多到了，我们该走了。",
			TraditionalChinese = "阿扎爾，時間差不多到了，我們該走了。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_5_2,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default2,
			BrightCharacter0 = false,
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
	public class IntroP3Node82 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node83);
		public override string Name => TalkingKeyWords.AzarName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "是呀，我们好久没看到新面孔了。我们走吧。\n二位，我们先告辞了。",
			TraditionalChinese = "是呀，我們好久沒看到新面孔了。我們走吧。\n二位，我們先告辭了。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => ProcessMessengerService.ContactWithArtist(new ArtistMessage()
		{
			CharacterNum = 3,
			CharacterAssetPath0 = TinaTalkingKeyWords.TinaStanding_normal,
			CharacterAssetPath1 = TalkingKeyWords.ST_Azar_4_1,
			CharacterAssetPath2 = TalkingKeyWords.St_Phoenix_Default,
			BrightCharacter0 = false,
			BrightCharacter2 = false,
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
	public class IntroP3Node83 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node84);
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "慢走。",
			TraditionalChinese = "慢走。",
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
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			var item2 = ScriptableObject.CreateInstance<De_ClosersSoundEffect>();
			item2.LoadModel(SoundKeyWords.COA_DoorOpen);
			return new List<DialogueEvent>() { item1, item2 };
		}
	}
	public class IntroP3Node84 : ClosersTalkingNode
	{
		public override Type NextNode => typeof(IntroP3Node85);
		public override string Name => IseubiTalkingKeyWords.iseubiName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "缇娜，依你看，那个“预言少女”，会是我想的那个露西吗？",
			TraditionalChinese = "緹娜，依你看，那個“預言少女”，會是我想的那個露西嗎？",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => TinaTalkingKeyWords.TinaStanding_normal;
		public override string FaceChipPath => IseubiTalkingKeyWords.SmallFaceFolderPath + "SmallFace_upset" + ".png";
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
	public class IntroP3Node85 : ClosersTalkingNode
	{
		public override Type NextNode => null;
		public override string Name => TinaTalkingKeyWords.TinaName;
		public override string Content => new TranslationItem()
		{
			Id = 0,
			SimplifiedChinese = "我也希望是褐鼠小队的露西。但我觉得只是同名罢了。",
			TraditionalChinese = "我也希望是褐鼠小隊的露西。但我覺得只是同名罷了。",
			English = "", //todo
			Japanese = "", //todo
			Korean = ""//todo
		}.TransToLocalization;
		public override string StandingPath => TinaTalkingKeyWords.TinaStanding_beloweye;
		public override string FaceChipPath => string.Empty;
		public override string AudioPath => string.Empty;
		public override List<DialogueEvent> GetDEList()
		{
			var item1 = ScriptableObject.CreateInstance<DE_CutScene>();
			item1.CutSceneSprite = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, BackGoundKeyWords.BG_ArkPrivateHome);
			return new List<DialogueEvent>() { item1 };
		}
	}
}