using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersFramework.Models.Interface
{
    public interface ICharacterSoundsToken
    {
        BattleChar ComponentMaster { get; }
        Vector3 ComponentCoordinate { get; }
        Transform ComponentTransform { get; }
    }
}
