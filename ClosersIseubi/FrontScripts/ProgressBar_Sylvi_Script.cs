using ChronoArkMod.Plugin;
using ClosersFramework.Models;
using ClosersFramework.Services;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ClosersIseubi.FrontScripts
{
	public class ProgressBar_Sylvi_Script : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
	{
		public List<Image> Units = new List<Image>();
		public Text Number;
		public Sprite GreenUnit;
		public Sprite YellowUnit;
		public Sprite RedUnit;
		public Animator NumberAnimator;
		void Awake()
		{
			if (Units.Count == 0)
			{
				var unitParent = this.transform.GetChild(0);
				var unitCount = unitParent.childCount;
				for (var i = 0; i < unitCount; i++) Units.Add(unitParent.GetChild(i).GetComponent<Image>());
			}
			Number = this.transform.GetChild(1).GetComponent<Text>();
			NumberAnimator = this.transform.GetChild(1).GetComponent<Animator>();

			GreenUnit = this.transform.GetChild(2).GetComponent<Image>().sprite;
			YellowUnit = this.transform.GetChild(3).GetComponent<Image>().sprite;
			RedUnit = this.transform.GetChild(4).GetComponent<Image>().sprite;

			this.GetComponent<Image>().raycastTarget = true;

			HasAwaked = true;
		}
		public bool HasAwaked { get; private set; } = false;
		public void ChangeNumber(int num, Buff NowBuff = null)
		{
			if (!HasAwaked) return;

			MyBuff = NowBuff;

			if (num > int.Parse(Number.text))
			{
				NumberAnimator.SetTrigger("Increase");
			}
			else if (num < int.Parse(Number.text))
			{
				NumberAnimator.SetTrigger("Decrease");
			}
			Number.text = num.ToString();
			Units.ForEach(t => t.gameObject.SetActive(false));
			Sprite TargetSprite;
			if (num <= 5)
			{
				TargetSprite = RedUnit;
			}
			else if (num <= 15)
			{
				TargetSprite = YellowUnit;
			}
			else
			{
				TargetSprite = GreenUnit;
			}
			Units?.Take(num)?.ToList().ForEach(t =>
			{
				t.gameObject.SetActive(true);
				t.GetComponent<Image>().sprite = TargetSprite;
			});
		}
		Buff MyBuff;
		public bool fieldobject = false;
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (this.MyBuff != null)
			{
				if (this.fieldobject)
				{
					ToolTipWindow.BuffToolTip(base.transform, this.MyBuff, 0, 1);
				}
				else
				{
					ToolTipWindow.BuffToolTip(base.transform, this.MyBuff, 0, 0);
				}
			}
			else
			{
				ToolTipWindow.ToolTipDestroy();
				ToolTipWindow.NewToolTip(base.transform, new TranslationItem()
				{
					SimplifiedChinese = "<b>魔法碎片储备</b>\n  该能量条表示李瑟钰当前拥有的魔法碎片数量。\n  当前没有魔法碎片。",
					TraditionalChinese = "<b>魔法碎片儲備</b>\n  該能量條表示李瑟鈺當前擁有的魔法碎片數量。\n  當前沒有魔法碎片。",
					English = "<b>Magic Bit Stock</b>\n  Sylvi has no Magic Bit now.",
					Japanese = "<b>ビット候補数</b>\n  現在ビットはありません",
					Korean = "<b>비트 비축 수량</b>\n  현재 비트가 없습니다."
				}.TransToLocalization);
			}
		}
		public void OnPointerExit(PointerEventData eventData)
		{
			ToolTipWindow.ToolTipDestroy();
		}
		public void Hide()
		{
			if (this.gameObject.activeSelf)
			{
				this.gameObject.SetActive(false);
			}
		}
		public void Show()
		{
			if (!this.gameObject.activeSelf)
			{
				this.gameObject.SetActive(true);
			}
		}
	}
}
