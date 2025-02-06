using ClosersFramework.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.PluginUnits
{
    public interface IClosersPlugin
    {
        string Name { get; }
        void Invoke();
        void Init(IPluginConfigs configs);
    }
}
