using ClosersFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersHumanity.KeyWords
{
    public static class IseubiTalkingKeyWords
    {
        public const string iseubiArkTalkingA = nameof(iseubiArkTalkingA);
        public const string iseubiForeKingA = nameof(iseubiForeKingA);
        public const string iseubiArchiveA = nameof(iseubiArchiveA);
        public const string iseubiClockTowerTalkingA = nameof(iseubiClockTowerTalkingA);
		const string FolderPath = "Assets/ClosersMod/Iseubi/Standing/Talking/";
		public const string iseubiStanding_smile = FolderPath + "smile.png";
        public const string iseubiStanding_unhappy = FolderPath + "unhappy.png";
        public const string iseubiStanding_normal = FolderPath + "normal.png";
        public const string iseubiStanding_nervous = FolderPath + "nervous.png";
        public const string iseubiStanding_shy = FolderPath + "shy.png";
        public const string iseubiStanding_strict = FolderPath + "strict.png";
        public const string iseubiStanding_upset = FolderPath + "upset.png";

		public const string V2FolderPath = "Assets/ClosersMod/Iseubi/Standing/Talking/V2/";
		public const string SmallFaceFolderPathV2 = "Assets/ClosersMod/Iseubi/Standing/Talking/SmallFace/";
		public const string SmallFaceFolderPath = "Assets/ClosersMod/Iseubi/Standing/Talking/";
        /*public static string GetPicName(SylviPosture body, SylviEmotion face)
        {
            return $"{V2FolderPath}{body.ToString()}-{face}.png";
        }
		public static string GetPicName(string name)
		{
			return $"{V2FolderPath}{name}.png";
		}*/
		public static string iseubiName = new TranslationItem()
        {
            
            SimplifiedChinese = "李瑟钰",
            TraditionalChinese = "李瑟鈺",
            English = "Sylvi Lee",
            Japanese = "雨宮美琴",
            Korean = "이슬비(李瑟鈺)"
		}.TransToLocalization;
        public const string QStandingKey = "Closers_QSylvi_SkeletonV2";

        /*public enum SylviPosture
        {
			akimbo,
			glasses,
            hug,
            normal,
            point,
            praise,
            think
		}
		public enum SylviEmotion
		{
			angry,angry2, angryshy,bigsmile,however,however2,normal,saying,scare,scare2,scare3,shy,shy2,smile,smileshy,unhappy,upset,upset2,wink,wink2,wink3,wrysmile,
		}*/
	}
}
