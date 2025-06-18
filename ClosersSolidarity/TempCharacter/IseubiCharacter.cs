using ChronoArkMod.ModData;
using ChronoArkMod.Template;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework;
using ClosersFramework.KeyWords;
using ClosersFramework.Models;
using ClosersFramework.Models.Interface;
using ClosersFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Services.Enum;
using ClosersFramework.Patchers;
using ClosersIseubi.Services;
using ClosersFramework.Templates;
using ClosersIseubi.Patchers.Registration;
using ClosersFramework.Data;
using ClosersFramework.Patchers.Registration;
using UnityEngine;
using ChronoArkMod;
using System.Collections;
using ClosersIseubi.Talking;
using Dialogical;
using ClosersHumanity.Intro;
using ClosersHumanity.KeyWords;
using ChronoArkMod.DialogueCreate;
using static System.Net.Mime.MediaTypeNames;
using GameDataEditor;

namespace ClosersSolidarity.TempCharacter
{
	public class IseubiCharacter : CustomCharacterGDE<ClosersModDefinition>
	{
        public override ModGDEInfo.LoadingType GetLoadingType()
        {
            return ModGDEInfo.LoadingType.Add;
        }

        public override void SetValue()
        {
			var TestTalkingP1 = new T_IntroP1();
            var EmptyObjectDeclare = new GameObject();
            //var EmptyObject = GameObject.Instantiate(EmptyObjectDeclare);
            var diatreeP1 = TestTalkingP1.CreateDialogueTree();
			var ngtidP1 = this.modInfo.assetInfo.ConstructObjectByCode(diatreeP1);

			var TestTalkingP2 = new T_IntroP2();
			var diatreeP2 = TestTalkingP2.CreateDialogueTree();
			var ngtidP2 = this.modInfo.assetInfo.ConstructObjectByCode(diatreeP2);

			var TestTalkingP3 = new T_IntroP3();
			var diatreeP3 = TestTalkingP3.CreateDialogueTree();
			var ngtidP3 = this.modInfo.assetInfo.ConstructObjectByCode(diatreeP3);


            base.Dialogue_FriendShipLVTalks.Clear();
            base.Dialogue_FriendShipLVTalks.Add(ngtidP1);
            base.Dialogue_FriendShipLVTalks.Add(ngtidP2);
            base.Dialogue_FriendShipLVTalks.Add(ngtidP3);
            //clog.iw("ngtid: "+ngtid);

		}

        public override string Key()
        {
            return "Iseubi";
        }
    }
}
