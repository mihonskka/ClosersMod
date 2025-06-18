using ClosersIseubi.Models;
using ClosersIseubi.Service;
using ClosersFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Services.Enum;

namespace ClosersIseubi.Isouryoku.BLL
{
    public abstract class IsouryokuBLL
    {
        public List<AuthorityConfigItem> ConfigList { get; set; }
        public bool CheckAuthority(int needExp, params CardType[] sect)
        {
            var input = false;
            //clog.w($"正在检测权限，目前状态为Exp:{(int)ExpService.getExp()?.Obj}, sect:{(CardType)ExpService.getSect()?.Obj}, 目标权限为Exp:{needExp}, sect:{sect[0]}");
            if ((int)ExpService.getExp()?.Obj >= needExp || GlobalSetting.CompletePassive)
                if (sect.Contains((CardType)ExpService.getSect()?.Obj) || ((CardType)ExpService.getSect()?.Obj == CardType.Closers))
                    input = true;

            return input;
        }
        public bool CheckAuthority(string Name)
        {
            //clog.w($"CA-正在准备检测权限，即将检测的权限名为{Name}");
            if (BattleSystem.instance == null) return false;
            //clog.w("CA-战斗检测通过");
            var input = false;
            var item = ConfigList.FirstOrDefault(t => t.Name == Name);
            if (item == null) return false;
            //clog.w("CA-权限表检测通过，即将开始正式检测");
            input = CheckAuthority(item.needExp, item.sect);
            return input;
        }
        public abstract bool LV1Desc();
        public abstract bool LV2Desc();
        public abstract bool LV3Desc();
        public abstract bool LV4Desc();
        public abstract bool LV5Desc();
    }
}
