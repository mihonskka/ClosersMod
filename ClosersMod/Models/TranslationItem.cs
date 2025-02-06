using ChronoArkMod;
using ClosersFramework.Service;
using I2.Loc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Models
{
    public class TranslationItem
    {
        public long Id { get; set; } = SnowService.instance.nextId();

		public string SimplifiedChinese { get; set; }
        public string TraditionalChinese { get; set; }
        public string Korean { get; set; }
        public string Japanese { get; set; }
        public string English { get; set; }
        public string TransToLocalization
        {
            get
            {
                string rv = string.Empty;
                switch (LocalizationManager.CurrentLanguage)
                {
                    case "Chinese":
                        rv = this.SimplifiedChinese ?? string.Empty;
                        break;
                    case "Chinese-TW":
                        rv = this.TraditionalChinese ?? string.Empty;
                        break;
                    case "Korean":
                        rv = this.Korean ?? string.Empty;
                        break;
                    case "English":
                        rv = this.English ?? string.Empty;
                        break;
                    case "Japanese":
                        rv = this.Japanese ?? string.Empty;
                        break;
                    default:
                        rv = this.SimplifiedChinese ?? string.Empty;
                        break;
                }
                if(string.IsNullOrWhiteSpace(rv))
                    rv = this.English??this.SimplifiedChinese??string.Empty;
                return rv;
            }
        }
    }
}
