using ClosersFramework.Models;
using I2.Loc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Services.Enum;

namespace ClosersFramework.Services
{
    public static class PassiveDescriptionService
    {
        public static List<PassiveDescItem> PassiveDescPool { get; set; }=new List<PassiveDescItem>();
        public static string MyLanguage => LocalizationManager.CurrentLanguage;

        public static void FillPool(List<PassiveDescItem> input)
        {
            PassiveDescPool.AddRange(input);
            PassiveDescPool = PassiveDescPool.Distinct().ToList();
        }

        public static void Init()
        {
        }

        public static string GetMyPassiveDescExtendeds(int exp,CardType cardType)
        {
            if (NoExp) clog.w("被动描述，解除限制");
            if (NoExp) exp = 114514;
            if (cardType == CardType.Closers)
            {
                var ext = PassiveDescPool.Where(t => t.Exp <= exp).OrderBy(t => t.Exp).Select(t => t.Desc.TransToLocalization);
                return "\n"+string.Join("\n", ext);
            }

            var filted = PassiveDescPool.Where(t => t.sect == cardType && t.Exp <= exp).OrderBy(t => t.Exp).Select(t => t.Desc.TransToLocalization);
            return "\n"+string.Join("\n", filted);
        }
        public static bool NoExp { get; set; }
    }
}
