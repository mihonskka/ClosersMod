using ClosersFramework.Models;
using ClosersFramework.Services;
using ClosersTina.Buffs;
using ClosersTina.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ClosersTina.FrontScript
{
	//Closers_Tina_ProgressBar
	public class ProgressBar_Tina_Script : MonoBehaviour
	{
		Text SubPanelText;
		Text MainPanelText;
		Text SupplyPanelText;
		Image MainPanelFill;
		Image WarningIcon;
		Image SupplyPanelBG;
		ProgressBar_MainPanel_Tina_Script MainPanelScript;
		ProgressBar_SubPanel_Tina_Script SubPanelScript;
		ProgressBar_SupplyPanel_Tina_Script SupplyPanelScript;
		Animator MainPannelNumberAnimator;
		Animator SupplyPanelNumberAnimator;

		public void Start()
		{

		}
		public void Awake()
		{
			SubPanelText = this.transform.GetChild(1).GetChild(0).GetComponent<Text>();
			WarningIcon = this.transform.GetChild(3).GetComponent<Image>();

			MainPanelText = this.transform.GetChild(2).GetChild(0).GetComponent<Text>();
			MainPanelFill = this.transform.GetChild(2).GetChild(1).GetComponent<Image>();
			MainPannelNumberAnimator = this.transform.GetChild(2).GetChild(0).GetComponent<Animator>();

			SupplyPanelText = this.transform.GetChild(0).GetChild(1).GetComponent<Text>();
			SupplyPanelNumberAnimator = this.transform.GetChild(0).GetChild(1).GetComponent<Animator>();
			SupplyPanelBG = this.transform.GetChild(0).GetChild(0).GetComponent<Image>();

			MainPanelScript = this.transform.GetChild(2).gameObject.AddComponent<ProgressBar_MainPanel_Tina_Script>();
			SubPanelScript = this.transform.GetChild(1).gameObject.AddComponent<ProgressBar_SubPanel_Tina_Script>();
			SupplyPanelScript = this.transform.GetChild(0).gameObject.AddComponent<ProgressBar_SupplyPanel_Tina_Script>();

			WarningIcon.gameObject.SetActive(false);

			SetHeat(0);
			SetAbrasion(0);
			SetSupply(0);
		}

		public void SetSubPanelText(string text)
		{
			if (SubPanelText != null)
			{
				SubPanelText.text = text;
			}
		}
		public void SetMainPanelText(string text)
		{
			if (MainPanelText != null)
			{
				MainPanelText.text = text;
			}
		}
		public void SetMainPanelFill(float fillAmount)
		{
			if (MainPanelFill != null)
			{
				MainPanelFill.fillAmount = fillAmount;
			}
		}

		public void SetHeat(int Heat, Buff HeatBuff = null)
		{
			if (MainPanelFill != null)
			{
				WarningIcon.gameObject.SetActive(false);
				WarningIcon.color = new Color(1, 1, 1, 0);
				//MainPanelFill.fillAmount = Heat / 15f;
				if (BattleSystem.instance != null) StartCoroutine(ChangeFillSmoothly(Heat));
				else MainPanelFill.fillAmount = Heat / 15f; // Assuming max heat is 15
				if (Heat >= 12)
				{
					MainPanelFill.color = new Color(1f, 0.2f, 0.2f, 1f); // Red
					if (Heat >= 15)
					{
						WarningIcon.gameObject.SetActive(true);
						WarningIcon.color = new Color(1, 1, 1, 1);
					}
				}
				else if (Heat >= 6)
				{
					//MainPanelFill.color = new Color(1f, 0.8f, 0.2f, 1f); // Yellow
				}
				else
				{
					//MainPanelFill.color = new Color(0.2f, 1f, 0.2f, 1f); // Green
				}

			}
			if (MainPanelText != null)
			{
				MainPanelText.text = Heat.ToString();
				MainPanelScript.MyBuff = HeatBuff;
				if (Heat > int.Parse(MainPanelText.text))
				{
					MainPannelNumberAnimator.SetTrigger("Increase");
				}
				else if (Heat < int.Parse(MainPanelText.text))
				{
					MainPannelNumberAnimator.SetTrigger("Decrease");
				}
			}
		}
		public void SetAbrasion(int Abrasion, Buff AbrasionBuff = null)
		{
			if (SubPanelText != null)
			{
				SubPanelText.text = Abrasion.ToString();
				SubPanelScript.MyBuff = AbrasionBuff;
				SubPanelScript.BuffCount = Abrasion;
			}
		}
		public void SetSupply(int Supply, bool NoBlink = false)
		{
			if (SupplyPanelNumberAnimator != null)
			{
				if (Supply > int.Parse(SupplyPanelText.text))
				{
					SupplyPanelNumberAnimator.SetTrigger("Increase");
				}
				else if (Supply < int.Parse(SupplyPanelText.text))
				{
					SupplyPanelNumberAnimator.SetTrigger("Decrease");
				}
			}
			if (SupplyPanelScript != null) SupplyPanelScript.SupplyCount = Supply;

			if(SupplyPanelText !=null) SupplyPanelText.text = Supply.ToString();

			if (SupplyPanelBG != null && !NoBlink)
			{
				if (Supply == 48)
				{
					StartCoroutine(SupplyGreenAnim());
				}
				else if (Supply == 30)
				{
					StartCoroutine(SupplyGreenAnim());
				}
				else if(Supply==18)
				{
					StartCoroutine(SupplyGreenAnim());
				}
			}
		}
		public IEnumerator SupplyGreenAnim()
		{
			if (SupplyPanelBG != null)
			{
				SupplyPanelBG.color = new Color(0.2f, 1f, 0.2f, 1f); // Green
				yield return new WaitForSeconds(1.5f);
				SupplyPanelBG.color = new Color(1f, 1f, 1f, 1f); // Reset to white
			}
		}

		public IEnumerator ChangeFillSmoothly(int Heat)
		{
			if (MainPanelFill != null)
			{
				float targetFill = Heat / 15f;
				float currentFill = MainPanelFill.fillAmount;
				float duration = 1f; // Duration of the transition
				float elapsedTime = 0f;
				while (elapsedTime < duration)
				{
					elapsedTime += Time.deltaTime;
					MainPanelFill.fillAmount = Mathf.Lerp(currentFill, targetFill, elapsedTime / duration);
					yield return null;
				}
				MainPanelFill.fillAmount = targetFill; // Ensure it ends at the exact target value
			}
		}

		public void StateHasChanged()
		{
			clog.tw("缇娜进度条状态更新");
			var oh = TinaService.GetOverheat();
			if (oh != null)
			{
				SetHeat(oh.StackNum, oh);
				clog.tw("overheat !=null");
			}
			else SetHeat(0);
			SetAbrasion((int)ExpService.getExp().Obj);
			SetSupply((TinaService.FindTinaInInvest().Passive as P_Tina).PassiveCounter, true);
		}

		public IEnumerator StateHasChanged_Async()
		{
			yield return new WaitForEndOfFrame();
			StateHasChanged();
		}
	}

	public class ProgressBar_MainPanel_Tina_Script : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
	{
		public Buff MyBuff;
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
					SimplifiedChinese = "<b>过热值进度条</b>\n  该进度条与数字表示缇娜当前的过热值。\n  当前过热值为0。",
					TraditionalChinese = "<b>過熱值進度條</b>\n  該進度條與數字表示緹娜當前的過熱值\n  當前過熱值為0。",
					English = "<b>Overheat Panel</b>\n  Overheat: 0",
					Japanese = "<b>【熱い】状態計器盤</b>\n  現在【熱い】はありません.",
					Korean = "<b>[과열치] 카운터</b>\n  현재 [과열] 값은 0입니다."
				}.TransToLocalization);
			}
		}
		public void OnPointerExit(PointerEventData eventData)
		{
			ToolTipWindow.ToolTipDestroy();
		}
	}
	public class ProgressBar_SubPanel_Tina_Script : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
	{
		public Buff MyBuff;
		public bool fieldobject = false;
		public int BuffCount;
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
				string extraString = "";
				if (BuffCount > 0)
				{
					extraString += "\n";
					if (BuffCount > 1)
					{
						extraString += new TranslationItem()
						{
							SimplifiedChinese = $"攻击力 {(int)(-0.5 * this.BuffCount)}%",
							TraditionalChinese = $"攻擊力 {(int)(-0.5 * this.BuffCount)}%",
							English = $"Attack Power {(int)(-0.5 * this.BuffCount)}%",
							Japanese = $"攻擊力 {(int)(-0.5 * this.BuffCount)}%",
							Korean = $"공격력 {(int)(-0.5 * this.BuffCount)}%"
						}.TransToLocalization;
						extraString += "\n";
					}
					extraString += new TranslationItem()
					{
						SimplifiedChinese = $"最大体力值 {(-1 * this.BuffCount)}%",
						TraditionalChinese = $"最大體力值 {(-1 * this.BuffCount)}%",
						English = $"Maximum Health {(-1 * this.BuffCount)}%",
						Japanese = $"最大体力 {(-1 * this.BuffCount)}%",
						Korean = $"최대 체력 {(-1 * this.BuffCount)}%"
					}.TransToLocalization;
					extraString += "\n";
					if (BuffCount > 10)
					{
						extraString += B_Abrasion.descExt;
					}
				}
				ToolTipWindow.ToolTipDestroy();
				ToolTipWindow.NewToolTip(base.transform, new TranslationItem()
				{
					SimplifiedChinese = $"<b>磨损值进度条</b>\n  该进度条与数字表示缇娜当前的磨损值。\n  当前磨损值: {BuffCount}。",
					TraditionalChinese = $"<b>磨損值進度條</b>\n  該進度條與數字表示緹娜當前的磨損值\n  當前磨損值: {BuffCount}。",
					English = $"<b>Abrasion Panel</b>\n  Abrasion: {BuffCount}",
					Japanese = $"<b>【関節摩耗】状態計器盤</b>\n  現在の【関節摩耗】は{BuffCount}",
					Korean = $"<b>【마모치】 카운터</b>\n  현재 【마모】 값은 {BuffCount}입니다."
				}.TransToLocalization + extraString);
			}
		}
		public void OnPointerExit(PointerEventData eventData)
		{
			ToolTipWindow.ToolTipDestroy();
		}
	}
	public class ProgressBar_SupplyPanel_Tina_Script : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
	{
		public int SupplyCount = 0;
		public void OnPointerEnter(PointerEventData eventData)
		{
			ToolTipWindow.ToolTipDestroy();
			ToolTipWindow.NewToolTip(base.transform, new TranslationItem()
			{
				SimplifiedChinese = $"<b>补给计数器</b>\n  团队每进行18次攻击或使用技能后，随机获得一张【手榴弹】或【紧急闪避】；30次，随机获得一张【我想静静】或【急救包】；48次，随机获得一张【三连发】或拥有的露西技能(不包括血色迷雾和露西诅咒技能)；\n  当前计数: {SupplyCount}",
				TraditionalChinese = $"<b>補給計數器</b>\n  團隊每進行18次攻擊或使用技能後，隨機獲得一張【手榴彈】或【緊急閃避】；30次，隨機獲得一張【我想靜靜】或【急救包】；48次，隨機獲得一張【三連發】或擁有的露西技能(不包括血色迷霧和露西詛咒技能)；\n  當前計數: {SupplyCount}",
				English = $"<b>Supply Counter</b>\n  Team conducts 18 attacks or uses skills every time, get a HE Grenade or Step back randomly; 30 time: Freezer or First Aid Kit; 48 time: Burst Fire or a positive Lucy skill.\n  Count: {SupplyCount}",
				Japanese = $"<b>ほきゅう計數盤</b>\n  チームは18回の攻撃やスキルを使用した後、Randomに【MK3手榴弾】または【緊急回避】を獲得します。30回、Randomに【タイムアローン Time Iron】または【救急箱】を手に入れた。48回、Randomに【3連バースト】または持っているLucy Card（血霧やLucyのJinxを除く）を1枚獲得する。\n  Count: {SupplyCount}",
				Korean = $"<b>【보급】계수기</b>\n  팀은 매 18회 공격 또는 스킬 사용 후 랜덤으로 【고폭 수류탄】 또는 【긴급 회피】 1장 획득; 30회, 랜덤으로 【혼자 있고 싶다】 또는 【구급가방】 1장 획득; 48회, 【3점사가】 또는 소유한 루시 스킬을스킬 1장을 랜덤으로 획득(핏빛 안개와 루시의 저주 스킬 포함하지 않음).\n  Count: {SupplyCount}"
			}.TransToLocalization);
		}
		public void OnPointerExit(PointerEventData eventData)
		{
			ToolTipWindow.ToolTipDestroy();
		}
	}
}
