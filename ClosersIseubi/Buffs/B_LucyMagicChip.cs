using ClosersIseubi.Buffs.BLL;
using ClosersIseubi.Buffs.IBLL;
using ClosersIseubi.Isouryoku;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.KeyWords;
using ClosersFramework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosersFramework.Templates;

namespace ClosersIseubi.Buffs
{
    public class B_LucyMagicChip : ClosersBaseBuff, IP_BuffUpdate, IP_BuffAdd, IP_BuffRemove,IP_PlayerTurn_1
    {
        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff) => checkbuff(addedbuff);
        public void BuffRemove(BattleChar buffMaster, Buff buff) => checkbuff(buff);
        public void BuffUpdate(Buff MyBuff) => checkbuff(MyBuff);
        public override void SelfdestroyPlus() => checkbuff(permit: true);

        //AntiShakeInterceptor Interceptor = new AntiShakeInterceptor();
        ILucyMagicChipBLL LucyMagicChipBLL = new LucyMagicChipBLL();

        void checkbuff(Buff buff = null, bool permit = false)
        {
            /*if(ThrottleService.SearchRegistration(ThrottleKeyWords.LucyMagicChipChecking)?.isTimeout ?? true)
                LucyMagicChipBLL.checkbuff(this, buff, permit);*/
            if(ThrottleService.CheckAvailable(ThrottleKeyWords.LucyMagicChipChecking))
                LucyMagicChipBLL.checkbuff(this, buff, permit);
        }

        public override string ClosersDesc(string desc)
        {
            return desc.Replace("&a", ((int)(1*this.StackNum)).ToString()).Replace("&b", ((int)(1 * this.StackNum)).ToString()).Replace("&c", ((int)(1 * this.StackNum)).ToString());
        }
        public override void Init()
        {
            base.Init();
            clog.iw("生成露西的魔法碎片");
            if (BattleSystem.instance != null)
            {
                clog.iw("露西的魔法碎片-增加碎片协助");
                BattleSystem.instance.AllyTeam.AliveChars.ForEach(t => t.BuffAdd(IseubiKeyWords.blmcfa, this.BChar));
                clog.iw("露西的魔法碎片-碎片协助增加完成");
            }
        }

        public void Turn1()
        {
            new Pluralism().LV4Effect();

            if (this.StackNum >= 5)
            {
                clog.iw("露西魔法碎片-回合开始抽牌");
                for (int i = 0; i < 5; i++)
                    SelfStackDestroy();
                BattleSystem.instance.AllyTeam.Draw(1);
            }
        }
    }

    public class B_LucyMagicChipForAlly : Buff
    {
        public override void Init()
        {
            clog.iw("碎片协助-开始初始化");
            base.Init();
            clog.iw("碎片协助-初始化完毕，准备初始化检测函数");
            initCheck();
            clog.iw("碎片协助-检测函数初始化完毕");
        }

        //AntiShakeInterceptor Interceptor = new AntiShakeInterceptor();
        ILucyMagicChipForAllyBLL LucyMagicChipForAllyBLL = new LucyMagicChipForAllyBLL();

        public void initCheck()
        {
            clog.iw("碎片协助-正在初始化检测函数，准备增加事件");
            EventDispatcher.AddAction(IseubiEventKeys.CheckLucyMagicChip, _ => check());
            clog.iw("碎片协助-事件增加完毕，进行第一次检测");
            check();
            clog.iw("碎片协助-第一次检测完毕，准备注册防抖列表");
            ThrottleService.AddRegistrationMilliSeconds(ThrottleKeyWords.LucyMagicChipChecking, 300);
        }

        public void check()
        {
            if(ThrottleService.CheckAvailable(ThrottleKeyWords.LucyMagicChipChecking))
            {
                LucyMagicChipForAllyBLL.check(this);
                ThrottleService.AddRegistrationMilliSeconds(ThrottleKeyWords.LucyMagicChipChecking, 300);
            }
        }
    }
}
