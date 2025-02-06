using ChronoArkMod.Template;
using ClosersFramework.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Templates
{
    public abstract class ClosersBaseCharacter: IClosersTalkingRegister
    {
        public abstract string ClosersCodeName { get; set; }
        public abstract void ClosersInit();

        public abstract string SkeletonDataPath { get; }
        public string SkeletonDataFaceLeftPath => SkeletonDataPath;
        public abstract string SkeletonDataFaceRightPath { get; }
    }
}
