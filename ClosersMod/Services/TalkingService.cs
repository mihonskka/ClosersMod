using ChronoArkMod;
using ChronoArkMod.DialogueCreate;
using ChronoArkMod.ModData;
using ClosersFramework.KeyWords;
using Dialogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersFramework.Services
{
    public class TalkingService : DialogueCreator
    {
        public override Type FirstNodeCreatorType => throw new NotImplementedException();
    }
    public class TalkingNodeService : DialogueNodeCreator
    {
        public TalkingNodeService()
        {
            
        }
    }
    public class TalkingNodeOptionService : DialogueNodeOptionCreator
    {

    }

}

