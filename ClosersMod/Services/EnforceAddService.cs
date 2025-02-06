using ClosersFramework.Models;
using ClosersFramework.Service.CodeManager;
using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Service
{
    //[NoReference]
    public static class EnforceAddService
    {
        public static Skill AddEnforce(Skill superior, Skill junior)
        {
            foreach (var es in superior.AllExtendeds)
            {
                if (EnforceFilter(es.Name, junior)) continue;
                junior.ExtendedAdd(es);
            }
            return junior;
        }


		public static bool EnforceFilter(string thisEnforceName, Skill thisSkill) => (string.IsNullOrWhiteSpace(thisEnforceName) || thisSkill == null || thisEnforceName == thisSkill.MySkill.Name || excludeEnforces.Any(t => t.SkillKey == thisSkill.MySkill.KeyID && t.ExcludeList.Contains(thisEnforceName)));

        public static List<EnforceFilterItem> excludeEnforces = new List<EnforceFilterItem>();
    }
}
