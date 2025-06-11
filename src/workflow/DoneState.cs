using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.src.core.entities;
using TaskManagement.src.core.enums;
using TaskManagement.src.features.userManagement;
using TaskManagement.src.workflow;

namespace TaskManagement.src.workflow
{


    public class DoneState : TaskState
    {
        public DoneState(TaskItem taskItem) : base(taskItem)
        {
        }

        public override void MoveToNext()
        {
            Console.WriteLine("✅ Task is already completed. No further state changes.");
        }

        public override void MoveToPrevious()
        {
            if (AccessControl.CanQAAndMarkTaskAsDone(taskItem.Assignee))
                taskItem.Status = TaskItemStatus.QA;
            taskItem.WorkflowState = new QAState(taskItem);
            Console.WriteLine("🔄 Task moved back to QA for further testing.");
        }

        public override string GetStatus() => "Done";
    }

}

