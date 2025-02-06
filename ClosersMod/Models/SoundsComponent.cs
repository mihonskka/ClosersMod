using ClosersFramework.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersFramework.Models
{
    public class SoundsComponentMsg : ICharacterSoundsToken
    {
        public BattleChar ComponentMaster { get; set; }

        public Vector3 ComponentCoordinate { get; set; }

        public Transform ComponentTransform { get; set; }
    }
}
