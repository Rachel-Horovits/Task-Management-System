using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.src.core.entities;

namespace TaskManagement.src.workflow
{
    public abstract class TaskState
    {
        protected TaskItem taskItem;
        public TaskState(TaskItem taskItem)
        {
            this.taskItem = taskItem;
        }
        public abstract void MoveToNext();
        public abstract void MoveToPrevious();
        public abstract string GetStatus();
    }

}
