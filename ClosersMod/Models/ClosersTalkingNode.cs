using ChronoArkMod;
using ChronoArkMod.DialogueCreate;
using ClosersFramework.KeyWords;
using ClosersFramework.Service;
using Dialogical.ParameterSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersFramework.Models
{
    public abstract class ClosersTalkingNode : DialogueNodeCreator
    {
        public abstract Type NextNode { get; }
        public abstract string Name { get; }
        public abstract string Content { get; }
        public abstract string StandingPath { get; }
        public abstract string FaceChipPath { get; }
        public abstract string AudioPath { get; }
        public virtual bool RuntimeStanding { get => false; }
		public virtual List<Dialogical.DialogueEvent> GetDEList() { return new List<Dialogical.DialogueEvent>(); }
		public virtual string LocalEvent { get; }
		public virtual Sprite Standing_3DMap { get; }
		public virtual string Standing_3DMap_Number { get; }
		public virtual int NameIndex { get; }
		public virtual int AutoChoiceIndex { get; }
		public virtual DialogueParameterSetBase LocalEventParameterSet { get; }
		public virtual string GlobalEvent { get; }
		public virtual DialogueParameterSetBase GlobalEventParameterSet { get; }

		public override Type NextDialogueNodeCreatorType => NextNode;
		string Text => string.IsNullOrWhiteSpace(Name) ? Content : $"*{Name}\n{Content}";

        public override DialogueNodeParameter SetDialogueNodeParameter()
        {
            return new DialogueNodeParameter()
            {
                Text = Text,
                Standing_Path = RuntimeStanding ? ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.ImageFromFile(StandingPath) : ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.ImageFromAsset(InfoKeyWords.AssetName, StandingPath),
                FaceChip = string.IsNullOrWhiteSpace(FaceChipPath) ? null : ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, FaceChipPath),
                Audio = string.IsNullOrWhiteSpace(AudioPath) ? null : ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<AudioClip>(InfoKeyWords.AssetName, AudioPath),
                Standing_3DMap = Standing_3DMap,
                Standing_3DMap_Number = Standing_3DMap_Number,
                NameIndex = NameIndex,
                autoChoiceIndex = AutoChoiceIndex,
                localEventParameterSet = LocalEventParameterSet,
                globalEvent = GlobalEvent,
                globalEventParameterSet = GlobalEventParameterSet,
                Events1 = GetDEList(),
                localEvent = LocalEvent,
            };
        }
    }
}
