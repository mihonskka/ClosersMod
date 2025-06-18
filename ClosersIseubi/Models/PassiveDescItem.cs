using ClosersFramework.Models;
using ClosersFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Services.Enum;

namespace ClosersIseubi.Models
{
    public class PassiveDescItem
    {
        public int Id { get; set; }
        public int Exp { get; set; }
        public CardType sect { get; set; }
        public TranslationItem Desc { get; set; }
    }
}
