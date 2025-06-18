using ClosersFramework.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Services
{
    public abstract class ClosersCharacterSoundService
    {
        public abstract void _Sound(string SoundName, ICharacterSoundsToken model);
        public abstract void _RandomSound(string SoundName, int RandNum, ICharacterSoundsToken model);
    }
}
