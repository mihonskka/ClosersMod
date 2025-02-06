using ClosersFramework.KeyWords;
using ClosersFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClosersHumanity.KeyWords
{
    public static class TalkingKeyWords
    {
		#region Lucy
		public static string LucyName => new TranslationItem()
        {
            SimplifiedChinese = "露西",
            TraditionalChinese = "露西",
            English = "Lucy",
            Japanese = "ルシー",
            Korean = "루시"
        }.TransToLocalization;
		const string SmallLucyFolderPath = @"Assets/ClosersMod/Standing/Ark/Lucy/Talking/";
		public const string LucyFaceChip0 = SmallLucyFolderPath + "F_Lucy_0.png";
        public const string LucyFaceChip1 = SmallLucyFolderPath + "F_Lucy_1.png";
        public const string LucyFaceChip2 = SmallLucyFolderPath + "F_Lucy_2.png";
        public const string LucyFaceChip3 = SmallLucyFolderPath + "F_Lucy_3.png";
        public const string LucyFaceChip4 = SmallLucyFolderPath + "F_Lucy_4.png";
        public const string LucyFaceChip5 = SmallLucyFolderPath + "F_Lucy_5.png";
        public const string LucyFaceChip6 = SmallLucyFolderPath + "F_Lucy_6.png";
        public const string LucyFaceChip7 = SmallLucyFolderPath + "F_Lucy_7.png";
        public const string LucyFaceChip8 = SmallLucyFolderPath + "F_Lucy_8.png";
        public const string LucyFaceChip9 = SmallLucyFolderPath + "F_Lucy_9.png";
        public const string LucyFaceChip10 = SmallLucyFolderPath + "F_Lucy_SP.png";
        public const string LucyFaceChip_normal = LucyFaceChip0;
        public const string LucyFaceChip_say = LucyFaceChip1;
        public const string LucyFaceChip_doubt = LucyFaceChip2;
        public const string LucyFaceChip_realize = LucyFaceChip3;
        public const string LucyFaceChip_panic = LucyFaceChip4;
        public const string LucyFaceChip_nervous = LucyFaceChip5;
        public const string LucyFaceChip_strict = LucyFaceChip6;
        public const string LucyFaceChip_pain = LucyFaceChip7;
        public const string LucyFaceChip_smile = LucyFaceChip8;
        public const string LucyFaceChip_scare = LucyFaceChip9;
        public const string LucyFaceChip_gray = LucyFaceChip10;
		#endregion

		#region Closers
		const string ClosersFolderPath = @"Assets/ClosersMod/Standing/Closers/";

		#region Konomi
		public static string KonomiName => new TranslationItem()
		{
			SimplifiedChinese = "安琪儿",
			TraditionalChinese = "安琪兒",
			English = "Anzier",
			Japanese = "星名このみ",
			Korean = "오세린"
		}.TransToLocalization;
		const string KonomiFolderPath = ClosersFolderPath;
		public const string KonomiStanding1 = KonomiFolderPath + "HoshinaKonomi1.png";
		public const string KonomiStanding2 = KonomiFolderPath + "HoshinaKonomi2.png";
		public const string KonomiStanding3 = KonomiFolderPath + "HoshinaKonomi3.png";
		public const string KonomiStanding4 = KonomiFolderPath + "HoshinaKonomi4.png";
		public const string KonomiStanding5 = KonomiFolderPath + "HoshinaKonomi5.png";
		public const string KonomiStanding6 = KonomiFolderPath + "HoshinaKonomi6.png";
		public const string KonomiStanding7 = KonomiFolderPath + "HoshinaKonomi7.png";
		public const string KonomiStanding8 = KonomiFolderPath + "HoshinaKonomi8.png";
		public const string KonomiStanding9 = KonomiFolderPath + "HoshinaKonomi9.png";
		public const string KonomiStanding_Default = KonomiStanding1;
		public const string KonomiStanding_Smile = KonomiStanding2;
		public const string KonomiStanding_Angry = KonomiStanding3;
		public const string KonomiStanding_Embarrass = KonomiStanding4;
		public const string KonomiStanding_Upset = KonomiStanding5;
		public const string KonomiStanding_Worry = KonomiStanding6;
		public const string KonomiStanding_Sad = KonomiStanding7;
		#endregion
		#region Orie
		public static string OrieName => new TranslationItem()
		{
			SimplifiedChinese = "伊织静",
			TraditionalChinese = "伊織靜",
			English = "Izjing",
			Japanese = "小鳥遊折絵",
			Korean = "김유정"
		}.TransToLocalization;
		const string OrieFolderPath = ClosersFolderPath;
		public const string OrieStanding1 = OrieFolderPath + "TakanashiOrie1.png";
		public const string OrieStanding2 = OrieFolderPath + "TakanashiOrie2.png";
		public const string OrieStanding3 = OrieFolderPath + "TakanashiOrie3.png";
		public const string OrieStanding4 = OrieFolderPath + "TakanashiOrie4.png";
		public const string OrieStanding5 = OrieFolderPath + "TakanashiOrie5.png";
		public const string OrieStanding6 = OrieFolderPath + "TakanashiOrie6.png";
		public const string OrieStanding7 = OrieFolderPath + "TakanashiOrie7.png";
		public const string OrieStanding_Default = OrieStanding1;
		public const string OrieStanding_Smile = OrieStanding2;
		public const string OrieStanding_Worry = OrieStanding3;
		public const string OrieStanding_Strict = OrieStanding4;
		public const string OrieStanding_Unhappy = OrieStanding5;
		public const string OrieStanding_Embarrass = OrieStanding6;
		public const string OrieStanding_Sad = OrieStanding7;
		#endregion
		#region Mahiro
		public static string MahiroName => new TranslationItem()
		{
			SimplifiedChinese = "宋恩伊",
			TraditionalChinese = "宋恩伊",
			English = "Song Enyi",
			Japanese = "宇津木眞尋",
			Korean = "송은이"
		}.TransToLocalization;
		const string MahiroFolderPath = ClosersFolderPath;
		public const string MahiroStanding1 = MahiroFolderPath + "UtsukiMahiro1.png";
		public const string MahiroStanding2 = MahiroFolderPath + "UtsukiMahiro2.png";
		public const string MahiroStanding3 = MahiroFolderPath + "UtsukiMahiro3.png";
		public const string MahiroStanding4 = MahiroFolderPath + "UtsukiMahiro4.png";
		public const string MahiroStanding5 = MahiroFolderPath + "UtsukiMahiro5.png";
		public const string MahiroStanding6 = MahiroFolderPath + "UtsukiMahiro6.png";
		public const string MahiroStanding7 = MahiroFolderPath + "UtsukiMahiro7.png";
		public const string MahiroStanding_Default = MahiroStanding1;
		public const string MahiroStanding_Smile = MahiroStanding2;
		public const string MahiroStanding_Unhappy = MahiroStanding3;
		public const string MahiroStanding_Strict = MahiroStanding4;
		public const string MahiroStanding_Worry = MahiroStanding5;
		public const string MahiroStanding_Proud = MahiroStanding6;
		public const string MahiroStanding_Fear = MahiroStanding7;
		#endregion
		#endregion
		#region Ark
		const string ArkFolderPath = @"Assets/ClosersMod/Standing/Ark/";
		#region Azar
		public static string AzarName => new TranslationItem()
		{
			SimplifiedChinese = "阿扎尔",
			TraditionalChinese = "阿扎爾",
			English = "Azar",
			Japanese = "アザール",
			Korean = "아자르"
		}.TransToLocalization;
		const string AzarFolderPath = ArkFolderPath+"Azar/";
		public const string ST_Azar_0 = AzarFolderPath + nameof(ST_Azar_0) + ".png";
		public const string ST_Azar_1 = AzarFolderPath + nameof(ST_Azar_1) + ".png";
		public const string ST_Azar_1_1 = AzarFolderPath + nameof(ST_Azar_1_1) + ".png";
		public const string ST_Azar_1_2 = AzarFolderPath + nameof(ST_Azar_1_2) + ".png";
		public const string ST_Azar_1_3 = AzarFolderPath + nameof(ST_Azar_1_3) + ".png";
		public const string ST_Azar_2 = AzarFolderPath + nameof(ST_Azar_2) + ".png";
		public const string ST_Azar_3 = AzarFolderPath + nameof(ST_Azar_3) + ".png";
		public const string ST_Azar_3_1 = AzarFolderPath + nameof(ST_Azar_3_1) + ".png";
		public const string ST_Azar_4 = AzarFolderPath + nameof(ST_Azar_4) + ".png";
		public const string ST_Azar_4_1 = AzarFolderPath + nameof(ST_Azar_4_1) + ".png";
		public const string ST_Azar_5 = AzarFolderPath + nameof(ST_Azar_5) + ".png";
		public const string ST_Azar_5_1 = AzarFolderPath + nameof(ST_Azar_5_1) + ".png";
		public const string ST_Azar_5_2 = AzarFolderPath + nameof(ST_Azar_5_2) + ".png";
		public const string ST_Azar_5_3 = AzarFolderPath + nameof(ST_Azar_5_3) + ".png";
		public const string ST_Azar_6 = AzarFolderPath + nameof(ST_Azar_6) + ".png";
		public const string ST_Azar_6_1 = AzarFolderPath + nameof(ST_Azar_6_1) + ".png";
		public const string ST_Azar_7 = AzarFolderPath + nameof(ST_Azar_7) + ".png";
		public const string ST_Azar_7_1 = AzarFolderPath + nameof(ST_Azar_7_1) + ".png";
		public const string ST_Azar_7_2 = AzarFolderPath + nameof(ST_Azar_7_2) + ".png";
		public const string ST_Azar_8 = AzarFolderPath + nameof(ST_Azar_8) + ".png";
		public const string ST_Azar_8_1 = AzarFolderPath + nameof(ST_Azar_8_1) + ".png";
		public const string ST_Azar_8_2 = AzarFolderPath + nameof(ST_Azar_8_2) + ".png";
		public const string ST_Azar_8_3 = AzarFolderPath + nameof(ST_Azar_8_3) + ".png";
		public const string ST_Azar_9 = AzarFolderPath + nameof(ST_Azar_9) + ".png";
		public const string ST_Azar_9_1 = AzarFolderPath + nameof(ST_Azar_9_1) + ".png";
		public const string ST_Azar_9_2 = AzarFolderPath + nameof(ST_Azar_9_2) + ".png";
		public const string ST_Azar_10 = AzarFolderPath + nameof(ST_Azar_10) + ".png";
		public const string ST_Azar_10_2 = AzarFolderPath + nameof(ST_Azar_10_2) + ".png";
		public const string ST_Azar_11 = AzarFolderPath + nameof(ST_Azar_11) + ".png";
		public const string ST_Azar_11_1 = AzarFolderPath + nameof(ST_Azar_11_1) + ".png";
		public const string ST_Azar_12 = AzarFolderPath + nameof(ST_Azar_12) + ".png";
		public const string ST_Azar_13 = AzarFolderPath + nameof(ST_Azar_13) + ".png";
		public const string ST_Azar_14 = AzarFolderPath + nameof(ST_Azar_14) + ".png";
		public const string ST_Azar_14_1 = AzarFolderPath + nameof(ST_Azar_14_1) + ".png";
		public const string St_Azar_Tears1 = AzarFolderPath + nameof(St_Azar_Tears1) + ".png";
		public const string St_Azar_Tears2 = AzarFolderPath + nameof(St_Azar_Tears2) + ".png";
		public const string St_Azar_Tears3 = AzarFolderPath + nameof(St_Azar_Tears3) + ".png";
		public const string St_Azar_Tears4 = AzarFolderPath + nameof(St_Azar_Tears4) + ".png";
		public const string St_Azar_Tears5 = AzarFolderPath + nameof(St_Azar_Tears5) + ".png";
		public const string St_Azar_Tears6 = AzarFolderPath + nameof(St_Azar_Tears6) + ".png";
		#endregion
		#region Hein
		public static string HeinName => new TranslationItem()
		{
			SimplifiedChinese = "海因",
			TraditionalChinese = "海因",
			English = "Hein",
			Japanese = "ヘイン",
			Korean = "헤인"
		}.TransToLocalization;
		const string HeinFolderPath = ArkFolderPath + "Hein/";
		public const string St_HeinR_Angry1 = HeinFolderPath + nameof(St_HeinR_Angry1) + ".png";
		public const string St_HeinR_Angry2 = HeinFolderPath + nameof(St_HeinR_Angry2) + ".png";
		public const string St_HeinR_Default = HeinFolderPath + nameof(St_HeinR_Default) + ".png";
		public const string St_HeinR_Default2 = HeinFolderPath + nameof(St_HeinR_Default2) + ".png";
		public const string St_HeinR_Embarrass1 = HeinFolderPath + nameof(St_HeinR_Embarrass1) + ".png";
		public const string St_HeinR_Embarrass2 = HeinFolderPath + nameof(St_HeinR_Embarrass2) + ".png";
		public const string St_HeinR_Pain1 = HeinFolderPath + nameof(St_HeinR_Pain1) + ".png";
		public const string St_HeinR_Pain2 = HeinFolderPath + nameof(St_HeinR_Pain2) + ".png";
		public const string St_HeinR_Serious1 = HeinFolderPath + nameof(St_HeinR_Serious1) + ".png";
		public const string St_HeinR_Serious2 = HeinFolderPath + nameof(St_HeinR_Serious2) + ".png";
		public const string St_HeinR_Sigh1 = HeinFolderPath + nameof(St_HeinR_Sigh1) + ".png";
		public const string St_HeinR_Sigh2 = HeinFolderPath + nameof(St_HeinR_Sigh2) + ".png";
		public const string St_HeinR_Smile1 = HeinFolderPath + nameof(St_HeinR_Smile1) + ".png";
		public const string St_HeinR_Smile2 = HeinFolderPath + nameof(St_HeinR_Smile2) + ".png";
		public const string St_HeinR_Smile3 = HeinFolderPath + nameof(St_HeinR_Smile3) + ".png";
		#endregion
		#region Lian
		public static string LianName => new TranslationItem()
		{
			SimplifiedChinese = "莉安",
			TraditionalChinese = "莉安",
			English = "Lian",
			Japanese = "リーアン",
			Korean = "리안"
		}.TransToLocalization;
		const string LianFolderPath = ArkFolderPath + "Lian/";
		public const string St_LianRogue_0 = LianFolderPath + nameof(St_LianRogue_0) + ".png";
		public const string St_LianRogue_1 = LianFolderPath + nameof(St_LianRogue_1) + ".png";
		public const string St_LianRogue_Default = LianFolderPath + nameof(St_LianRogue_Default) + ".png";
		public const string St_LianRogue_Default2 = LianFolderPath + nameof(St_LianRogue_Default2) + ".png";
		public const string St_LianRogue_Depression = LianFolderPath + nameof(St_LianRogue_Depression) + ".png";
		public const string St_LianRogue_Depression2 = LianFolderPath + nameof(St_LianRogue_Depression2) + ".png";
		public const string St_LianRogue_Embarrass1 = LianFolderPath + nameof(St_LianRogue_Embarrass1) + ".png";
		public const string St_LianRogue_Embarrass2 = LianFolderPath + nameof(St_LianRogue_Embarrass2) + ".png";
		public const string St_LianRogue_PainA1 = LianFolderPath + nameof(St_LianRogue_PainA1) + ".png";
		public const string St_LianRogue_PainA2 = LianFolderPath + nameof(St_LianRogue_PainA2) + ".png";
		public const string St_LianRogue_PainB1 = LianFolderPath + nameof(St_LianRogue_PainB1) + ".png";
		public const string St_LianRogue_PainB2 = LianFolderPath + nameof(St_LianRogue_PainB2) + ".png";
		public const string St_LianRogue_Sad = LianFolderPath + nameof(St_LianRogue_Sad) + ".png";
		public const string St_LianRogue_Sad2 = LianFolderPath + nameof(St_LianRogue_Sad2) + ".png";
		public const string St_LianRogue_Shout = LianFolderPath + nameof(St_LianRogue_Shout) + ".png";
		public const string St_LianRogue_Smile1 = LianFolderPath + nameof(St_LianRogue_Smile1) + ".png";
		public const string St_LianRogue_Smile2 = LianFolderPath + nameof(St_LianRogue_Smile2) + ".png";
		#endregion
		#region Phoenix
		public static string PhoenixName => new TranslationItem()
		{
			SimplifiedChinese = "凤凰",
			TraditionalChinese = "鳳凰",
			English = "Phoenix",
			Japanese = "フェニックス",
			Korean = "피닉스"
		}.TransToLocalization;
		const string PhoenixFolderPath = ArkFolderPath + "Phoenix/";
		public const string St_Phoenix_Angry1 = PhoenixFolderPath + nameof(St_Phoenix_Angry1) + ".png";
		public const string St_Phoenix_Angry2 = PhoenixFolderPath + nameof(St_Phoenix_Angry2) + ".png";
		public const string St_Phoenix_Default = PhoenixFolderPath + nameof(St_Phoenix_Default) + ".png";
		public const string St_Phoenix_Default2 = PhoenixFolderPath + nameof(St_Phoenix_Default2) + ".png";
		public const string St_Phoenix_Embarrass = PhoenixFolderPath + nameof(St_Phoenix_Embarrass) + ".png";
		public const string St_Phoenix_Giggle1 = PhoenixFolderPath + nameof(St_Phoenix_Giggle1) + ".png";
		public const string St_Phoenix_Giggle2 = PhoenixFolderPath + nameof(St_Phoenix_Giggle2) + ".png";
		public const string St_Phoenix_Proud1 = PhoenixFolderPath + nameof(St_Phoenix_Proud1) + ".png";
		public const string St_Phoenix_Proud2 = PhoenixFolderPath + nameof(St_Phoenix_Proud2) + ".png";
		public const string St_Phoenix_Question1 = PhoenixFolderPath + nameof(St_Phoenix_Question1) + ".png";
		public const string St_Phoenix_Question2 = PhoenixFolderPath + nameof(St_Phoenix_Question2) + ".png";
		public const string St_Phoenix_Serious = PhoenixFolderPath + nameof(St_Phoenix_Serious) + ".png";
		public const string St_Phoenix_Shock = PhoenixFolderPath + nameof(St_Phoenix_Shock) + ".png";
		public const string St_Phoenix_Stretch1 = PhoenixFolderPath + nameof(St_Phoenix_Stretch1) + ".png";
		public const string St_Phoenix_Stretch2 = PhoenixFolderPath + nameof(St_Phoenix_Stretch2) + ".png";
		public const string St_Phoenix_Talk1 = PhoenixFolderPath + nameof(St_Phoenix_Talk1) + ".png";
		public const string St_Phoenix_Talk2 = PhoenixFolderPath + nameof(St_Phoenix_Talk2) + ".png";
		public const string St_Phoenix_Think1 = PhoenixFolderPath + nameof(St_Phoenix_Think1) + ".png";
		public const string St_Phoenix_Think2 = PhoenixFolderPath + nameof(St_Phoenix_Think2) + ".png";
		#endregion
		#endregion

		#region BackGround
		const string BackGroundFolderPath = "Assets/ClosersMod/BG/";
		public const string BG_JiangNanCGV = BackGroundFolderPath + nameof(BG_JiangNanCGV) + ".png";
		public const string BG_WhiteFort = BackGroundFolderPath + nameof(BG_WhiteFort) + ".png";
		#endregion

		public const string PublicTalkingOwner = InfoKeyWords.Closers;

		public static List<(string Key, string Value)> GetFieldsAndProperties()
		{
			var type = typeof(TalkingKeyWords);
			var result = new List<(string, string)>();

			// 获取所有字段
			FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo field in fields)
			{
				result.Add((field.Name, (string)field.GetValue(null)));
			}

			// 获取所有属性
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (PropertyInfo property in properties)
			{
				result.Add((property.Name, (string)property.GetValue(null)));
			}

			return result;
		}
	}
}
