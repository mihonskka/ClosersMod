using ClosersFramework.KeyWords;
using ClosersFramework.Models;
using ClosersFramework.Models.Interface;
using ClosersFramework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.PluginUnits
{
    public class TaskHandbookPlugin : IClosersPlugin
    {
        public string Name { get; set; } = PluginKeyWords.TaskHandbook;

        public TaskHandbookPlugin()
        {
        }
        public void Init(IPluginConfigs config)
        {
            clog.w("任务手册模式尝试初始化");

            if (config is TaskHandBookConfig)
            {
                clog.w("任务手册模式初始化");
                var taskConfig = config as TaskHandBookConfig;
                foreach (var configItem in taskConfig.PageList)
                {
                    this.InvokeAction.Add((configItem.TaskName, configItem.InvokeAction));
                    EventDispatcher.AddAction(configItem.EventId, _ =>
                    {
                        clog.w("任务手册-任务完成");
                        TaskHandbookSerivce.CompleteTask(configItem.TaskName);
                        EventDispatcher.RemoveAction(configItem.EventId);
                    });
                    EventDispatcher.AddAction(configItem.EventId+"Activate", _ =>
                    {
                        clog.w("任务手册-任务激活");
                        TaskHandbookSerivce.ActivateTask(configItem.TaskName);
                        EventDispatcher.RemoveAction(configItem.EventId+ "Activate");
                    });
                }
            }
            clog.iw("任务手册模式初始化完毕");
        }
        public void Invoke(string TaskName)
        {
            clog.w("任务手册模式调用动作");
            if (TaskHandbookSerivce.CheckTask(TaskName))
            {
                clog.w("任务手册-任务未完成，正式开始调用");
                var iact = InvokeAction.FirstOrDefault(t => t.Item1 == TaskName);
                if(iact.Item2!=null) iact.Item2.Invoke();
            }             
        }
        public void Invoke()
        {
            clog.w("任务手册模式调用动作");
            foreach (var item in InvokeAction)
            {
                if (TaskHandbookSerivce.CheckTask(item.Item1))
                {
                    clog.w("任务手册-任务未完成，正式开始调用");
                    item.Item2.Invoke();
                }
            }
            
        }
        public List<(string,Action)> InvokeAction { get; set; }=new List<(string, Action)>() { };
        public List<string> TaskName { get; set; }
    }
}
