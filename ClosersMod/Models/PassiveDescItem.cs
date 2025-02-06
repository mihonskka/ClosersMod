using ClosersFramework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Service.Enum;

namespace ClosersFramework.Models
{
    public class PassiveDescItem
    {
        public int Id { get; set; }
        public int Exp { get; set; }
        public CardType sect { get; set; }
        public TranslationItem Desc { get; set; }
    }
}
