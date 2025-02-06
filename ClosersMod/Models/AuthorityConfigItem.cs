using ClosersFramework.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Service.Enum;

namespace ClosersFramework.Models
{
    public class AuthorityConfigItem: IPluginConfigs
    {
        public string Name { get; set; }
        public int needExp { get; set; }
        public CardType sect { get; set; }
    }
}
