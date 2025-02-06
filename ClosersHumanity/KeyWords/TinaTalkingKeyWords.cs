using ClosersFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersHumanity.KeyWords
{
    public static class TinaTalkingKeyWords
    {
        public static string TinaName = new TranslationItem()
        {
            
            SimplifiedChinese = "缇娜",
            TraditionalChinese = "緹娜",
            English = "Tina",
            Japanese = "Tina",
            Korean = "티나(Tina)" 
        }.TransToLocalization;
        public const string QStandingKey = "Closers_QTina_Skeleton";
        const string FolderPath = "Assets/ClosersMod/Tina/Talking/";
		public const string TinaStanding_beloweye = FolderPath + "beloweye.png";
        public const string TinaStanding_bigsmile = FolderPath + "bigsmile.png";
        public const string TinaStanding_nervous = FolderPath + "nervous.png";
        public const string TinaStanding_normal = FolderPath + "normal.png";
        public const string TinaStanding_pain = FolderPath + "pain.png";
        public const string TinaStanding_smile = FolderPath + "smile.png";
        public const string TinaStanding_unhappy = FolderPath + "unhappy.png";

        public const string TinaArkTalkingA = nameof(TinaArkTalkingA);
        public const string TinaForeKingA = nameof(TinaForeKingA);
        public const string TinaArchiveTalkingA = nameof(TinaArchiveTalkingA);
        public const string TinaClockTowerTalkingA = nameof(TinaClockTowerTalkingA);
    }
}
