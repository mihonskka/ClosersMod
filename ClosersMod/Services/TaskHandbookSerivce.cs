using ClosersFramework.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Services
{
    public static class TaskHandbookSerivce
    {
        public static List<TaskHandbookItemEntity> TaskPool { get; set; }=new List<TaskHandbookItemEntity>();
        public static bool AddTask(string TaskName, bool Finished=false)
        {
            //clog.w("任务手册-增加任务");
            if (TaskPool.Any(t=>t.Name==TaskName)) return false;
            TaskPool.Add(new TaskHandbookItemEntity()
            {
                Id = Guid.NewGuid(),
                Finished = Finished,
                Name = TaskName,
            });
            return true;
        }
        public static bool AddTask(TaskHandbookItemEntity item)
        {
            //clog.w("任务手册-增加任务");
            if (TaskPool.Any(t=>t.Name == item.Name))
                return UpdateTask(TaskPool.FirstOrDefault(t => t.Name == item.Name), item.Finished);
            TaskPool.Add(item);
            return true;
        }

        public static bool SyncTask(string TaskName)
        {
            try
            {
                //clog.w("同步任务手册列表");
                var itemFromGame = PlayData.TSavedata.CustomValues.FirstOrDefault(t => t.Name == TaskName);
                if (itemFromGame == null)
                {
                    //clog.w("同步任务手册列表-准备创建新的任务");
                    PlayData.TSavedata.CustomValues.Add(new RecordInSave()
                    {
                        Name = TaskName,
                        Obj=false
                    });
                    UpdateTask(TaskName, false);
                }
                else
                    UpdateTask(TaskName, (bool)itemFromGame.Obj);
                //clog.w("任务手册-完成同步");
                return true;
            }
            catch
            {
                return false;
                
            }
        }

        public static TaskHandbookItemEntity GetItem(string TaskName,bool needSync=true)
        {
            if (needSync)
                SyncTask(TaskName);
            return TaskPool.FirstOrDefault(t => t.Name == TaskName);            
        }
        public static bool CheckTask(string TaskName) => !GetItem(TaskName).Finished;
        public static bool UpdateTask(TaskHandbookItemEntity task, bool Finished)
        {
            try
            {
                task.Finished = Finished;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool UpdateTask(string TaskName, bool Finished)
        {
            //clog.w("更新任务手册列表");
            var mytask = GetItem(TaskName,false);
            //clog.w($"更新任务手册列表，mytask: {mytask}");
            if (mytask == null) return AddTask(TaskName, Finished);
            else return UpdateTask(mytask, Finished);
        }
        public static bool CompleteTask(string TaskName)
        {
            var cv = PlayData.TSavedata.CustomValues.FirstOrDefault(t => t.Name == TaskName);
            if(cv!=null) cv.Obj = true;
            SyncTask(TaskName);
            UpdateTask(TaskName, true);
            return true;
        }

        public static bool ActivateTask(string TaskName)
        {
            var cv = PlayData.TSavedata.CustomValues.FirstOrDefault(t => t.Name == TaskName);
            if (cv != null) cv.Obj = true;
            SyncTask(TaskName);
            UpdateTask(TaskName, false);
            return true;
        }
    }
}
