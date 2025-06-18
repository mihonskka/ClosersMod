using ChronoArkMod.ModData;
using ChronoArkMod.Template;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework;
using ClosersFramework.KeyWords;
using ClosersFramework.Models;
using ClosersFramework.Models.Interface;
using ClosersFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Services.Enum;
using ClosersFramework.Patchers;
using ClosersIseubi.Services;
using ClosersFramework.Templates;
using ClosersIseubi.Patchers.Registration;
using ClosersFramework.Data;
using ClosersFramework.Patchers.Registration;
using UnityEngine;
using ChronoArkMod;
using System.Collections;
using ClosersIseubi.Talking;
using Dialogical;
using ClosersHumanity.Intro;
using ClosersHumanity.KeyWords;
using ChronoArkMod.DialogueCreate;
using static System.Net.Mime.MediaTypeNames;
using GameDataEditor;
using ClosersFramework.Service.CodeManager;
using ClosersIseubi.Models;
using PassiveDescItem = ClosersFramework.Models.PassiveDescItem;

namespace ClosersIseubi
{
	public class IseubiCharacter : ClosersBaseCharacter
    {
        public override string ClosersCodeName { get; set; } = "Iseubi";

        public override string SkeletonDataPath => "Assets/ClosersMod/Iseubi/QStanding/V2/qsylvistand2_SkeletonData.asset";

        public override string SkeletonDataFaceRightPath => throw new NotImplementedException();

        public override void ClosersInit()
        {
            /*
            string faceoripath = "Iseubi\\Obsolete\\FaceOriginChar.png";
            string imageKey = base.assetInfo.ImageFromFile(faceoripath);
            var faceorichar_str = base.assetInfo.SmallFaceGameObject(imageKey, new Vector2(353.51297f, 213.056366f), new Vector2(-404.011017f, -1112.8927f), new Vector2(0.5314829f, 0.8352648f));
            base.FaceOriginChar = faceorichar_str;

            //string facesmallpath = "Iseubi\\Obsolete\\FaceSmallChar.png";
            base.FaceSmallChar = base.assetInfo.FaceGameObject(base.assetInfo.ImageFromFile("Iseubi\\Obsolete\\FaceSmallChar.png"), new Vector2(76.22347f, 82.90286f), new Vector2(-104.464607f, -235.00882f), new Vector2(0.5669027f, 0.7216441f));
            base.BattleChar = base.assetInfo.BattleCharGameObject(base.assetInfo.ImageFromFile("Iseubi\\Obsolete\\BattleChar.png"), new Vector2(383.1431f, 332.7758f), new Vector2(-533.460938f, -1271.62256f), new Vector2(0.581997156f, 0.7925853f));
            clog.iw("立绘设置完毕");*/

            PassiveDescriptionService.NoExp = GlobalSetting.CompletePassive;
            clog.iw("火力全开状态设置完毕");
            IseubiModalMessageService.Init();
            clog.iw("模态消息池初始化完毕");
            PassivePoolInit();
            clog.iw("被动描述池初始化完毕");
            //new ExpDescTask().myfix2();

            EventDispatcher.AddExceptList(new List<string>()
            {
                IseubiEventKeys.PluLV3IScroll,
                IseubiEventKeys.PluLV1ISkill
            });
            clog.iw("事件总线除外表设置完毕");
            StatInterceptorData.DodgePrivilegesList.Add(c => c?.KeyData == IseubiKeyWords.Iseubi);
            clog.iw("闪避注册表添加完毕");
            CharacterInterceptorData.PassivePrivilegesList.Add(c => c?.KeyData == IseubiKeyWords.Iseubi);
            clog.iw("被动注册表添加完毕");
            SkillAddingInterceptorData.SkillPrivilegesList[IseubiKeyWords.Iseubi] = (Character c, bool force) => IseubiService.CheckPresence(false) && (force || c?.KeyData == IseubiKeyWords.Iseubi);
            clog.iw("技能注册表添加完毕");
            BattleTextInterceptorData.Broadcasts.Add(new IseubiBroadcast());
            clog.iw("战斗消息播报表添加完毕");
            ExpPassvieDescInterceptorData.lst.Add(new IseubiPassiveDescCheck());
            clog.iw("经验值拦截器设置完毕");
            ClosersExtendText.RebirthInBattleText[IseubiKeyWords.Iseubi] = new List<TranslationItem>()
            {
                new TranslationItem(){
                    Id=0,
                    SimplifiedChinese="重新开始。",
                    TraditionalChinese="重新開始。",
                    English="Restarting.",
                    Japanese="作戦再開します。",
                    Korean="다시 시작."
                },
                new TranslationItem(){
                    Id=1,
                    SimplifiedChinese="战斗继续，消灭敌方目标。",
                    TraditionalChinese="戰鬥繼續，消滅敵方目標。",
                    English="Continue working.",
                    Japanese="戦闘続行、敵を殲滅します。",
                    Korean="전투가 계속되어 적의 목표물을 소멸하다."
                }
            };
            clog.iw("重生消息设置完毕");
            TalkingData.Data.Add(new ArkTalkingA());
            TalkingData.Data.Add(new ForeKingA());
            TalkingData.Data.Add(new ArchiveTalkingA());
            TalkingData.Data.Add(new ClockTowerTalkingA());
            TalkingData.Characters.Add(this);
            clog.iw("对话数据设置完毕");
            TalkingData.QStandingData[IseubiKeyWords.Iseubi] = new QStandingInfo() { ArkPosition = new Vector3(-2.47f, -0.1616f, 0), QStandingKey = IseubiTalkingKeyWords.QStandingKey };
            clog.iw("Q版小人数据设置完毕");

            var a = new List<string>() {
				GDEItemKeys.SkillExtended_SkillEn_Trisha_0,//特丽莎：出手时获得与支付费用相等的特丽莎凝神增益
                GDEItemKeys.SkillExtended_SkillEn_Trisha_1,//特丽莎：在获得影子分身增益的状态下出手时将再次释放。
                
                GDEItemKeys.SkillExtended_SkillEn_Lian_1,//莉安：赋予倒计时 2 伤害增加 25%
                
                GDEItemKeys.SkillExtended_SkillEn_Queen_1,//卉子：当任意友军拥有治愈鞭痕减益时，此技能的伤害增加 15%，并抽取 1 个技能。
                GDEItemKeys.SkillExtended_SkillEn_Queen_0,//卉子：费用减少 1 点，出手后对自己造成 4 点痛苦伤害
                
                GDEItemKeys.SkillExtended_LucyC_P_Ex2,//露西-灵巧位移：释放此技能时，等待+1 此技能相当于‘位移’增益，可同时存在多个。
                GDEItemKeys.SkillExtended_LucyC_P_Ex,//露西-位移：释放此技能时，等待+1 ‘位移’增益手中只能存在1个。
                
                GDEItemKeys.SkillExtended_SKillEn_Mement_1,//约翰-模拟：释放时生成此技能并拿到手中，附带放逐。该技能不被视为生成技能。
                
                GDEItemKeys.SkillExtended_SkillEn_Azar_0,//阿扎尔：根据支付的费用，将相等数量的阿扎尔的幻影剑拿到手中。
                
                GDEItemKeys.SkillExtended_SkillEn_IlyaPassive2,//伊莉雅-伏特加：从手中释放时，丢弃手中最下面的技能，并抽取一个技能。
                GDEItemKeys.SkillExtended_SkillEn_IlyaPassive,//伊莉雅-伏特加：费用减少 1 点。 从手中释放时，选择丢弃位于手中最上面或最下面的一个技能。
                
                GDEItemKeys.SkillExtended_SkillEn_Phoenix_0,//凤凰：释放时获得本回合期间免疫一次伤害的增益。 该效果在战斗中仅限触发一次。
                
                GDEItemKeys.SkillExtended_SkillEn_Prime_0,//钢铁之心：造成与所有友军的保护罩相等的额外伤害
                
                GDEItemKeys.SkillExtended_SkillEn_ShadowPriest_0,//卡伦：费用减少 1 点，出手后对自己造成 4 点痛苦伤害
                GDEItemKeys.SkillExtended_SkillEn_ShadowPriest_1,//卡伦：释放时对每个敌人造成痛苦伤害，伤害量等于目标自身被赋予的每回合持续伤害量。
                
                GDEItemKeys.SkillExtended_SkillEn_Silver_0,//西尔弗斯坦：当指向西尔弗斯坦的标记目标时，恢复 1 点法力值。
            
                GDEItemKeys.SkillExtended_TW_Blue_3_Ex,//月之祝福：费用增加 2 点，并重复释放该技能。

                GDEItemKeys.SkillExtended_SkillEn_ChangePlus,//通用：出手时本回合的技能交换次数增加 1 次
                GDEItemKeys.SkillExtended_SkillEn_Draw,//通用：抽取一个技能。
                GDEItemKeys.SkillExtended_SkillWe_Count,//通用：倒计时+1
                GDEItemKeys.SkillExtended_SkillWe_SelfpainDMG,//通用：出手后对自身造成 3 点痛苦伤害

                GDEItemKeys.SkillExtended_LucyCurse_CursedClock_Ex,//露西-被诅咒的钟：每当主动释放技能时减少，变成 0 时强制结束回合

                GDEItemKeys.SkillExtended_TheLight_Ex_P,//光明卡洛尔-神圣残骸：释放该技能时，拥有神圣残骸增益的友军将跟着释放。
                GDEItemKeys.SkillExtended_Outlaw_Ex,//靶子射击：释放露西技能时，手中最上面一个技能的主人受到&a点伤害。
                GDEItemKeys.SkillExtended_PharosHealer_Ex_0,//法洛斯-行动干扰魔法：附带倒计时，锁定
                GDEItemKeys.SkillExtended_S4_King_Ex_0,//被遗忘的王-鲁莽的行动：主动释放该技能时，被遗忘的王的攻击力增加 10%，此后该技能被放逐。
            };


            TurnStartInterceptorData.TurnStartActions.Add(() =>
            {
				if (TurnResetInfo.NeedReloadEnemySkill)
				{
					BattleSystem.instance.EnemyTeam.AliveChars.ForEach(t => t.Skills = Skill.CharToSkills(t, BattleSystem.instance.EnemyTeam));
					TurnResetInfo.NeedReloadEnemySkill = false;
				}
			});
			
			CharacterLoadedData.Data.Add(IseubiKeyWords.Iseubi);
            clog.iw("角色注册表添加完毕");


			//ModInfo modInfo = ModManager.getModInfo(InfoKeyWords.Closers);
			//DialogueTree dialogue = DialogueCreator.CreateDialogueTree<T_IntroP1>();
			//var DialoguePath = modInfo.assetInfo.ConstructObjectByCode(dialogue);
			//base.Dialogue_NomalGiftTalk = DialoguePath;
			//base.Dialogue_FriendShipLVTalks = new List<string>
		 //      {
			//       DialoguePath, DialoguePath, DialoguePath
		 //      };
   //         clog.iw("ngtid: " + DialoguePath);

            //IseubiService.FindIseubiOriginal().Dialogue_NomalGiftTalk = DialoguePath;

            //LoadOverInterceptorData.TalkingData.Add((IseubiKeyWords.Iseubi, new List<string> { DialoguePath }));

			/*
			var TestTalking = new T_IntroP1();
			var EmptyObjectDeclare = new GameObject();
			//var EmptyObject = GameObject.Instantiate(EmptyObjectDeclare);
			var diatree = TestTalking.CreateDialogueTree();
			diatree.nodes.Add(new IntroNode0().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode1().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode2().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode3().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode4().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode5().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode6().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode7().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode8().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode9().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode10().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode11().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode12().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode13().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode14().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode15().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode16().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode17().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode18().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode19().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode20().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode21().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode22().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode23().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode24().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode25().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode26().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode27().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode28().CreateDialogueNode());
			diatree.nodes.Add(new IntroNode29().CreateDialogueNode());
			var ngtid = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.ConstructObjectByCode(diatree);
			base.Dialogue_NomalGiftTalk = ngtid;
			base.Dialogue_FriendShipLVTalks.Clear();
			base.Dialogue_FriendShipLVTalks.Add(ngtid);
			base.Dialogue_FriendShipLVTalks.Add(ngtid);
			base.Dialogue_FriendShipLVTalks.Add(ngtid);
			clog.iw("ngtid: " + ngtid);*/


			//base.Dialogue_NomalGiftTalk = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.ObjectFromAsset<DialogueTree>("testunityassetbundle", "Assets/ChronoArkModUnity/ModDialogues/Test1.asset");
		}

        public void PassivePoolInit()
        {
            var descs = new List<PassiveDescItem>()
            {
                new PassiveDescItem()
                {
                      Exp = 4, sect = CardType.Pluralism,
                    Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="回合开始时，若手中没有露西技能，则优先抽取一个露西技能；",
                         TraditionalChinese="回合開始時，若手中沒有露西技能，則優先抽取一個露西技能；",
                         English="At the start of turn, if there have not skill of Lucy in the hand, then draw a skill from the deck, prioritizing Lucy's skills.",
                         Japanese="ラウンド開始時にルシースキルを持っていない場合は、優先的にルシースキルを1つ抽出します。",
                         Korean="턴이 시작될 때 손에 루시 스킬이 없으면 우선적으로 루시 스킬 1개를 뽑습니다."
                     }
                },
                new PassiveDescItem()
                {
                     Id = 1, Exp = 8, sect = CardType.Pluralism,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="每当消耗碎片或等待时，清空露西与第x位调查员的过载。（x为当前回合数÷4的余数。）；",
                         TraditionalChinese="每當消耗碎片或等待時，清空露西與第x位調查員的過載。（x為當前回合數÷4的餘數。）；",
                         English="Everytime cost chip or prase wait button, clear the overload of Lucy and the x-th investigator. (x is the reminder of the turn number divided by 4.); ",
                         Japanese="ビットを消費したり待機したりするたびに、ルーシーとx人目の調査団員の過負荷をクリアします。（xは現在のラウンド数÷4の剰余である。）",
                         Korean="비트 소모 또는 대기할 때마다 루시와 제x번째 조사단원의 과부하를 지웁니다.( x는 현재 턴 수÷4의 나머지 수)"
                     }
                },
                new PassiveDescItem()
                {
                     Id = 2, Exp = 12, sect = CardType.Pluralism,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="立即获得3个道具卷轴；完成诅咒战斗时，获得一个道具卷轴；",
                         TraditionalChinese="立即獲得3個道具捲軸；完成詛咒戰鬥時，獲得一個道具捲軸；",
                         English="Get 3 item scrolls; At the end of a curse battle, get 1 item scroll; ",
                         Japanese="すぐに3つのアイテムリールを取得します。呪われた戦いを終えた時、道具の巻物を手に入れる。",
                         Korean="바로 아이템 스크롤 3개를 획득합니다. 저주받은 전투를 완료하면 아이템 스크롤 1개를 획득합니다."
                     }
                },
                new PassiveDescItem()
                {
                     Id = 3, Exp = 16, sect = CardType.Pluralism,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="回合开始时，若露西拥有魔法碎片，则获得1点法力值；",
                         TraditionalChinese="回合開始時，若露西擁有魔法碎片，則獲得1點法力值；",
                         English="At the start of turn, if Lucy have 'Magic Chip', add 1 AP; ",
                         Japanese="ラウンド開始時、ルシーがbitを持っていれば、法力値を1点獲得する。",
                         Korean="턴이 시작될 때 루시가 비트를 가지고 있으면 마나 1를 획득합니다."
                     }
                },
                new PassiveDescItem()
                {
                     Id = 3, Exp = 20, sect = CardType.Pluralism,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="【协同作战】取消一次性；每当牌堆洗牌时，清空所有角色的过载，恢复法力值至上限，并抽取等同于角色数量的牌。",
                         TraditionalChinese="【協同作戰】取消一次性；每當牌堆洗牌時，清空所有角色的過載，恢復法力值至上限，並抽取等同於角色數量的牌。",
                         English="'Killer Queen' removes once; When shuffling cards, clear all investigators overloads, restore AP to upper limit and draw skills with the number of investigators.",
                         Japanese="【キラークイーン】一回限りのキャンセル、デッキがシャッフルされるたびに、すべてのキャラクタのオーバーロードをクリアし、法力値を上限に戻し、キャラクタの数に等しいカードを抽出します。",
                         Korean="【퀸 오브 하트 포메이션 】일회성 취소; 카드뭉치가 패를 뒤섞을 때마다 모든 캐릭터의 과부하 제거 마나가 상한으로 회복 그리고 캐릭터 수와 동등한 스킬 추출."
                     }
                },
                new PassiveDescItem()
                {
                     Id = 4, Exp = 4, sect = CardType.Electrical,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="战斗开始时，碎片+3；",
                         TraditionalChinese="戰鬥開始時，碎片+3；",
                         English="When battle starting, add 3 chips;",
                         Japanese="戦闘開始時、ビット+3、",
                         Korean="전투 시작시, 비트+3. "
                     }
                },
                new PassiveDescItem()
                {
                     Id = 5, Exp = 8, sect = CardType.Electrical,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="【致命打击】层数增加至8，且每回合李瑟钰第一次被施加减益时，将消耗4层并减少一层即将施加的减益；",
                         TraditionalChinese="【致命打擊】層數增加至8，且每回合李瑟鈺第一次被施加減益時，將消耗4層並減少一層即將施加的減益；",
                         English="Strengthen 'Lethal Strike';",
                         Japanese="【弱点ヒット】を強化する",
                         //【致命打擊】增幅略微增加，層數增加至8
                         //Korean="【치명적인 공략】 성장폭이 약간 증가하면 중첩이 8로 증가되며, 턴 마다 이슬비에게 첫 디버프가 인가되면 2중첩을 소모하고 인가될 디버프1중첩이 줄어듭니다."
                         Korean="【치명적인 공략】 중첩이 8로 증가되며, 턴 마다 이슬비에게 첫 디버프가 인가되면 4중첩을 소모하고 인가될 디버프1중첩이 줄어듭니다."
                     }
                },
                new PassiveDescItem()
                {
                     Id = 6, Exp = 12, sect = CardType.Electrical,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="【风暴之眼】在命中后不解除；【电磁·电磁枪】前两次攻击消耗法力值-1；",
                         TraditionalChinese="【風暴之眼】在命中後不解除；【電磁·電磁槍】前兩次攻擊消耗的法力值-1；",
                         English="'Storm Eye' won't be removed after hit; Casting AP of the first two times of '[E]Thunder Strike' minus 1; ",
                         Japanese="【嵐の目】命中しても消えない、【雷遁・レールガン】最初の2回の攻撃AP-1、",
                         Korean="【폭풍의 눈】 적중 후 해제되지 않으며 [[E]레이건] 첫 2번 공격은 마나 1을 소모합니다"
                     }
                },
                new PassiveDescItem()
                {
                     Id = 7, Exp = 16, sect = CardType.Electrical,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="当消耗完最后一个碎片时，立即获得一个碎片；",
                         TraditionalChinese="當消耗完最後一個碎片時，立即獲得一個碎片；",
                         English="When costing the last chip, add a chip; ",
                         Japanese="最後のビットを消費し終わったら、すぐにビットを獲得します。",
                         Korean="마지막 1개 비트를 소모하게 되면 바로 1개의 비트를 획득합니다."
                     }
                },
                new PassiveDescItem()
                {
                     Id = 7, Exp = 20, sect = CardType.Electrical,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="任意非痛苦伤害均可触发【闪电链】的效果；若场上拥有【闪电链】的单位不多于2，则【闪电链】的伤害提升至25%；",
                         TraditionalChinese="任意非痛苦傷害均可觸發【閃電鏈】的效果；若場上擁有【閃電鏈】的單位不多於2，則【閃電鏈】的傷害提升至25%；",
                         English="'Elect Chain' can be touched off by any attack; If the number of units which has 'Elect Chain' lower to 3, then the damage of 'Elect Chain' will increase to 25%.",
                         Japanese="任意の非苦痛ダメージは【でんりゅう】の効果を誘発することができる、フィールド上に【でんりゅう】を持つ単位が2以下であれば、【でんりゅう】のダメージは25%に上昇し、",
                         Korean="【번개 체인】은 어떠한 공격에도 촉발할 수 있다; 필드에 【번개 체인】 있는 단위가 2보다 많지 않으면 【번개 체인】의 데미지가 25% 증가합니다."
                     }
                },
                new PassiveDescItem()
                {
                     Id = 8, Exp = 4, sect = CardType.Teleport,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="自身受攻击概率增加；【虫洞】增幅强化；【虫洞】持续时间内，体力极限受到保护；",
                         TraditionalChinese="自身受攻擊概率增加；【蟲洞】增幅強化；【蟲洞】持續時間內，體力極限受到保護；",
                         English="Strengthen 'Ultra Insinct'; Aggro Increased;",
                         Japanese="自身が攻撃を受ける確率が増加する；【飛雷神準備】を強化する；【飛雷神準備】持続時間内に回復ゲージが保護され；",
                         Korean="자신이 공격받을 확률 증가; 【윔홀】 성장폭 강화;【윔홀】 지속시간 내 회복게이지 보호.;"
                     }
                },
                new PassiveDescItem()
                {
                     Id = 9, Exp = 8, sect = CardType.Teleport,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="【信标】可以将受到的伤害增加25%；【空间·光速】击杀目标时将生成一张【空间·虫洞穿梭】；",
                         TraditionalChinese="【信標】可以將受到的傷害增加25%；【空間·光速】擊殺目標時將生成一張【空間·蟲洞穿梭】；",
                         English="Receiving Damage of 'Beacon' add 25%; Strengthen '[S]Speed of Light' and '[S]Speed of Light·2s';",
                         Japanese="【飛雷神術式】受けたダメージを25%増加させることができます。【飛雷神・神速】と【飛雷神·神速二の段】ターゲットを撃ち殺すと【飛雷神・ディメンションチェイス】が生成され、",
                         Korean="【비콘】받는 피해량을 25% 증가할 수 있으며, 【[S]광속】 및 【[S]광속 2단】대상을 처치한 경우 【[S]윔홀 왕복】 1장이 생성됩니다."
                     }
                },
                new PassiveDescItem()
                {
                     Id = 10, Exp = 12, sect = CardType.Teleport,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="拥有【虫洞】并成功闪避时，抽取一个技能，并可以选择一张手牌中自身的牌不消耗法力直接使用；",
                         TraditionalChinese="擁有【蟲洞】並成功閃避時，抽取一個技能，並可以選擇一張手牌中自身的牌不消耗法力值直接使用；",
                         English="When Seulbi have 'Ultra Insinct' and dodging, draw 1 skill, then Lucy can choose a skill in hand and cast it immediatly; ",
                         Japanese="【飛雷神準備】を持ち、回避に成功した場合、スキルを抽出し、手札の中の自分のカードを選択して法力を消費せずに使用することができます。",
                         Korean="【윔홀】을 가지고 있으며 또 성공적으로 회피하였다면 스킬을 1개 뽑습니다 손패의 이슬비 스킬 1장을 선택해 마나 소모 없이 직접 낼 수 있습니다."
                     }
                },
                new PassiveDescItem()
                {
                     Id = 11, Exp = 16, sect = CardType.Teleport,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="若碎片数量达到20，下一次攻击将额外消耗8碎片并且造成攻击力50%的额外伤害；",
                         TraditionalChinese="若碎片數量達到20，下一次攻擊將額外消耗8碎片並且造成攻擊力50%的額外傷害；",
                         English="If the number of the chips has reached 20, the next attack of Seulbi will cost extra 8 chips and cause extra 50% of the attack damage; ",
                         Japanese="ビット数が20に達すると、次の攻撃は8ビットを追加消費し、攻撃力50%の追加ダメージを与えます。",
                         Korean="비트 수가 20미만이면 다음 공략은 추가로 비트 8개를 소모하며 공격력 50%인 추가 피해를 입힙니다."
                     }
                },
                new PassiveDescItem()
                {
                     Id = 11, Exp = 20, sect = CardType.Teleport,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="本次调查期间每一次闪避，都将清空自身的痛苦减益并永久提升1.5%攻击力；(已提升&lvd%)",
                         TraditionalChinese="本次調查期間每一次閃避，都將清空自身的痛苦減益並永久提升1.5%攻擊力；(已提升&lvd%)",
                         English="During this iinvestigation, every dodging occurred, will clear dot debuff and increase 1.5% attack point permanently;(has increased &lvd%)",
                         Japanese="今回の調査期間中に回避するたびに、自分の苦痛を取り除き、攻撃力を1.5%永久に向上させる。(昇格&lvd%)",
                         Korean="이번 조사 기간 회피할 때마다 자신의 고통을 비우고 공격력 1.5% 영구 증가;(벌써 &lvd%포인트 올렸어요)"
                     }
                },
                new PassiveDescItem()
                {
                     Id = 12, Exp = 4, sect = CardType.Gravity,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="【引力·强制打断】握在手中时或存在于固定能力时，若友军受到敌方攻击，可以于本回合内无效化敌方目标的同名攻击技能。若如此做，则这个技能将被放逐；",
                         TraditionalChinese="【引力·強制打斷】握在手中時或存在於固定能力時，若友軍受到敵方攻擊，可以與本回合內無效化敵方目標的同名攻擊技能。若如此做，則這個技能將被放逐；",
                         English="When '[G]Forced Cancel' is in the hand or in the fixed ability, and allies are going to be attacked, 'Forced Cancel' can invalidate the effect of the skill in this turn. If Lucy casting 'Forced Cancel' by this way, this 'Forced Cancel' will be excluded; ",
                         Japanese="【神羅天征】手にした時や固定能力に存在した時、友軍が敵の攻撃を受けると、このターン中に敵の目標の同名攻撃スキルを無効化することができる。そうすれば、このスキルは追放されます。",
                         Korean="【[G]강제 캔슬】을 손에 가지고 있거나 고정 능력에 보유하고 있을 경우, 아군이 대상으로 선정된 경우 이 스킬을 사전에 내어 해당 스킬을 무효화 할 수 있습니다. 이렇게 하면 이 덱은 제외됩니다."
                     }
                },
                new PassiveDescItem()
                {
                     Id = 13, Exp = 8, sect = CardType.Gravity,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="【引力·强制打断】可以解除自身的所有减益；【引力·黑洞压缩】将无视防御；",
                         TraditionalChinese="【引力·強制打斷】可以解除自身的所有減益；【引力·黑洞壓縮】將無視防禦；",
                         English="'[G]Forced Cancel' can clear all of the debuff belong to Sylvi; '[G]Space Elasticity' will cause true damage; ",
                         Japanese="【神羅天征】自身のすべての減益を解除することができます。【萬象天引】防御を無視する、",
                         Korean="【[G]강제 캔슬】 자신의 모든 디버프를 제거할 수 있습니다. 【[G]공간 압축】 방어를 무시합니다."
                     }
                },
                new PassiveDescItem()
                {
                     Id = 14, Exp = 12, sect = CardType.Gravity,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="【引力·戒律之刃】重复释放次数+1，产生碎片数+1；",
                         TraditionalChinese="【引力·戒律之刃】重複釋放次數+1，產生的碎片數+1；",
                         English="'[G]Blades of Discipline' recast time add 1, get extra 1 chip; ",
                         Japanese="【パニッシュメント】繰り返し放出回数＋1、発生したビット数＋1、",
                         Korean="【[G]규율의 칼날】 반복 시전 횟수+1, 생성 비트 수+1"
                     }
                },
                new PassiveDescItem()
                {
                     Id = 15, Exp = 16, sect = CardType.Gravity,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="场上每存在一名敌人，<sprite=2>干扰成功率+5%；【引力·强制打断】可以清除所有友军的减益；",
                         TraditionalChinese="場上每存在一名敵人，<sprite=2>干擾成功率+5%；【引力·強制打斷】可以清除所有友軍的減益；",
                         English="<sprite=2>CC Accuracy add 5 times of the number of the enemy; '[G]Forced Cancel' can clear all of the debuff belong to allies; ",
                         Japanese="フィールド上に敵が1人存在するごとに、<sprite=2>干渉成功率は+5%;【神羅天征】すべての友軍の減益を一掃することができ、",
                         Korean="현장에 적이 1명이 있을 때마다 <sprite=2> 방해 성공률 5%입니다. 【[G]강력 캔슬】모든 아군의 디버프를 제거할 수 있습니다;"
                     }
                },
                new PassiveDescItem()
                {
                     Id = 15, Exp = 20, sect = CardType.Gravity,Desc = new TranslationItem()
                     {
                         Id=0,
                         SimplifiedChinese="【抓取】将降低20%防御力。",
                         TraditionalChinese="【抓取】將降低20%防御力。",
                         English="'Catch you' will decrease 20% defend point.",
                         Japanese="【捕まえた】防御力を20%低下させる。",
                         Korean="【포획】방어력 20% 감소;"
                     }
                },
            };

            PassiveDescriptionService.FillPool(descs);
        }
    }
}
