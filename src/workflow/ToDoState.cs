using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.src.core.entities;
using TaskManagement.src.core.enums;
using TaskManagement.src.workflow;

namespace TaskManagement.src.workflow
{

    public class ToDoState : TaskState
    {
        public ToDoState(TaskItem taskItem) : base(taskItem)
        {
        }

        public override void MoveToNext()
        {
            taskItem.Status = TaskItemStatus.InProgress;
            taskItem.WorkflowState = new InProgressState(taskItem);
            Console.WriteLine("✅ Task moved from To Do to In Progress.");
        }

        public override void MoveToPrevious()
        {
            Console.WriteLine("❌ Cannot move back from To Do state.");
        }

        public override string GetStatus() => "To Do";
    }

}
