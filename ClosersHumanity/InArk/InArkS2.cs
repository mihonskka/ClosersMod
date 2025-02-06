using ChronoArkMod.DialogueCreate;
using ChronoArkMod;
using ClosersFramework.KeyWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersHumanity.InArk
{
	internal class InArkS2
	{
	}

	public class TestTalking : DialogueCreator
	{
		public override Type FirstNodeCreatorType => typeof(TestTalkingNode0);
		public override DialogueParameter SetDialogueParameter(GameObject gameObject)
		{
			return new DialogueParameter()
			{
				AutoPlay = true,
				UIOffDialogue = true,
				StoryDialogue = true
			};
		}
	}

	public class TestTalkingNode0 : DialogueNodeCreator
	{
		public override Type NextDialogueNodeCreatorType => typeof(TestTalkingNode1);

		public override DialogueNodeParameter SetDialogueNodeParameter()
		{
			return new DialogueNodeParameter()
			{
				Text = "*李瑟钰\n露西，我们又见面了。",
				Standing_Path = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.ImageFromAsset(InfoKeyWords.AssetName, "Assets/ClosersMod/Iseubi/Standing/Talking/smile.png"),
				NameIndex = 0
			};
		}
	}
	public class TestTalkingNode1 : DialogueNodeCreator
	{
		public override Type NextDialogueNodeCreatorType => typeof(TestTalkingNode2);

		public override DialogueNodeParameter SetDialogueNodeParameter()
		{
			return new DialogueNodeParameter()
			{
				Text = "*李瑟钰\n我说得没错吧？我们还会再见面的。",
				Standing_Path = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.ImageFromAsset(InfoKeyWords.AssetName, "Assets/ClosersMod/Iseubi/Standing/Talking/smile.png"),
				NameIndex = 0
			};
		}
	}
	public class TestTalkingNode2 : DialogueNodeCreator
	{
		public override Type NextDialogueNodeCreatorType => typeof(TestTalkingNode3);
		public override DialogueNodeParameter SetDialogueNodeParameter()
		{
			return new DialogueNodeParameter()
			{
				Text = "*露西\n我可不记得你，你是谁？",
				Standing_Path = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.ImageFromAsset(InfoKeyWords.AssetName, "Assets/ClosersMod/Iseubi/Standing/Talking/smile.png"),
				NameIndex = 0,
				FaceChip = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, "Assets/ClosersMod/Lucy/Talking/F_Lucy_2.png")
			};
		}
	}
	public class TestTalkingNode3 : DialogueNodeCreator
	{
		public override Type NextDialogueNodeCreatorType => typeof(TestTalkingNode4);
		public override DialogueNodeParameter SetDialogueNodeParameter()
		{
			return new DialogueNodeParameter()
			{
				Text = "*李瑟钰\n果然…",
				Standing_Path = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.ImageFromAsset(InfoKeyWords.AssetName, "Assets/ClosersMod/Iseubi/Standing/Talking/unhappy.png"),
				NameIndex = 0
			};
		}
	}
	public class TestTalkingNode4 : DialogueNodeCreator
	{
		public override Type NextDialogueNodeCreatorType => typeof(TestTalkingNode5);
		public override DialogueNodeParameter SetDialogueNodeParameter()
		{
			return new DialogueNodeParameter()
			{
				Text = "*李瑟钰\n我是方舟的一名普通居民，可以叫我李瑟钰。",
				Standing_Path = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.ImageFromAsset(InfoKeyWords.AssetName, "Assets/ClosersMod/Iseubi/Standing/Talking/normal.png"),
				NameIndex = 0
			};
		}
	}
	public class TestTalkingNode5 : DialogueNodeCreator
	{
		public override Type NextDialogueNodeCreatorType => typeof(TestTalkingNode6);
		public override DialogueNodeParameter SetDialogueNodeParameter()
		{
			return new DialogueNodeParameter()
			{
				Text = "*李瑟钰\n如果要去扭曲之地的话，可以带上我么？",
				Standing_Path = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.ImageFromAsset(InfoKeyWords.AssetName, "Assets/ClosersMod/Iseubi/Standing/Talking/normal.png"),
				NameIndex = 0
			};
		}
	}
	public class TestTalkingNode6 : DialogueNodeCreator
	{
		public override Type NextDialogueNodeCreatorType => typeof(TestTalkingNode7);
		public override DialogueNodeParameter SetDialogueNodeParameter()
		{
			return new DialogueNodeParameter()
			{
				Text = "*露西\n我确实需要人手，但是那里很危险，你确定要跟我一起去？",
				Standing_Path = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.ImageFromAsset(InfoKeyWords.AssetName, "Assets/ClosersMod/Iseubi/Standing/Talking/normal.png"),
				FaceChip = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, "Assets/ClosersMod/Lucy/Talking/F_Lucy_1.png")
			};
		}
	}
	public class TestTalkingNode7 : DialogueNodeCreator
	{
		public override DialogueNodeParameter SetDialogueNodeParameter()
		{
			return new DialogueNodeParameter()
			{
				Text = "*李瑟钰\n我虽然很弱，但是我可以叫上我的同伴缇娜一起，你可以相信她的实力。",
				Standing_Path = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.ImageFromAsset(InfoKeyWords.AssetName, "Assets/ClosersMod/Iseubi/Standing/Talking/smile.png"),
				NameIndex = 0
			};
		}
	}
}
