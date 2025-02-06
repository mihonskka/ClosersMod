using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Models
{
    public class TaskHandbookItemEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Finished { get; set; }
    }
}
