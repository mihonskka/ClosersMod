using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Models
{
    public class ModalMessages
    {
        public string ActionName { get; set; }
        public List<TranslationItem> Sentences { get; set; } = new List<TranslationItem>();
    }
}
