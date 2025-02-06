using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Models.Interface
{
    public interface IClosersTalkingRegister: IClosersCodeName
    {
        string SkeletonDataPath { get; }
        string SkeletonDataFaceLeftPath { get; }
        string SkeletonDataFaceRightPath { get; }
    }
}
