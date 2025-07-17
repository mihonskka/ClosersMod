using ClosersFramework.Models;
using ClosersFramework.Services;
using ClosersFramework.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersItem.Equipments
{
	public class E_EmployeeCard : ClosersBaseEquipmentEffect, IP_SkillUse_User_After,IP_PlayerTurn, IP_SkillUse_User
	{
		public override void Init()
		{
			base.Init();
			this.PlusStat.maxhp = 12;
			this.PlusStat.def = 10;
		}

		int CardCount = 0;
		public void SkillUseAfter(Skill SkillD)
		{
			
		}
		public void SkillUse(Skill SkillD, List<BattleChar> Targets)
		{
			CardCount += 1;
			//clog.iw($"EEC: CC: {CardCount}; TN:{BattleSystem.instance.TurnNum}");
			if (CardCount == BattleSystem.instance.TurnNum)
			{
				this.BChar.MyTeam.BasicSkillRefill(this.BChar, this.BChar.BattleBasicskillRefill);
				this.BChar.MyTeam.BasicSkillRefill(this.BChar, this.BChar.BattleBasicskillRefill);
			}
		}

		public void Turn()
		{
			CardCount = 0;
		}

		List<TranslationItem> SylviInfos = new List<TranslationItem>()
		{
			new TranslationItem()
			{
				SimplifiedChinese="姓名: 李瑟钰",
				TraditionalChinese = "姓名: 李瑟鈺",
				English = "Name: Sylvi Lee",
				Japanese = "氏名: ミコト アマミヤ/雨宮美琴",
				Korean = "이슬비(李瑟鈺)",
			},
			new TranslationItem()
			{
				SimplifiedChinese="出生: 2003年4月30日",
				TraditionalChinese = "出生: 公元2003年4月30日",
				English = "DOB: April 30, 2003",
				Japanese = "平成 15年 4月 30日 生",
				Korean = "생년월일: 2003년 4월 30일",
			},
			new TranslationItem()
			{
				SimplifiedChinese="职务: 指挥",
				TraditionalChinese = "職務: 指揮",
				English = "Pos: Squad Leader",
				Japanese = "役職：指揮者",
				Korean = "직책: 대장",
			},
			new TranslationItem()
			{
				SimplifiedChinese="部门: 黑羊队",
				TraditionalChinese = "部門: 黑羊隊",
				English = "Department: BlackLambs",
				Japanese = "所属部署: BlackLambs",
				Korean = "부서: 검은양 팀",
			},
			new TranslationItem()
			{
				SimplifiedChinese="职称: A级封印者",
				TraditionalChinese = "職稱: A級封印者",
				English = "Ranks: A",
				Japanese = "職名等級: A級クロザス",
				Korean = "직함: A급 클로저스",
			}
		};

		public override string ClosersDesc(string desc)
		{
			return base.ClosersDesc(desc)+ "\n<color=#919191>- " + SylviInfos.Random().TransToLocalization+ "</color>";
		}

		
	}
}
