using ClosersFramework.KeyWords;
using ClosersFramework.PluginUnits;
using ClosersFramework.Service.CodeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Services
{
    [NoReference]
    public static class PluginUnitService
    {
        public static IClosersPlugin GetPlugin(string PluginName)
        {
            switch (PluginName)
            {
                case PluginKeyWords.TaskHandbook:
                    return new TaskHandbookPlugin();
                default:
                    return null;
            }
        }
    }
}
