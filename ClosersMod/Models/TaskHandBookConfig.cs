using ClosersFramework.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Models
{
    public class TaskHandBookConfig: IPluginConfigs
    {
        public List<TaskHandBookPage> PageList { get; set; }
    }
    public class TaskHandBookPage
    {
        public string TaskName { get; set; }
        public string EventId { get; set; }
        public Action InvokeAction { get; set; }
    }
}
