using ClosersFramework.Models;
using ClosersFramework.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Data
{
    public class TalkingData
    {
        public static List<ClosersTalkingTree> Data { get; set; } = new List<ClosersTalkingTree>();
        public static List<IClosersTalkingRegister> Characters { get; set; } = new List<IClosersTalkingRegister>();
        public static Dictionary<string, QStandingInfo> QStandingData { get; set; } = new Dictionary<string, QStandingInfo>();
    }
}
