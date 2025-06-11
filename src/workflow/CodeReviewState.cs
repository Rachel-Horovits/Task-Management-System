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
    public class CodeReviewState : TaskState
    {
        public CodeReviewState(TaskItem taskItem) : base(taskItem)
        {
        }

        public override void MoveToNext()
        {
            if (AccessControl.CanQAAndMarkTaskAsDone(taskItem.Assignee))
                taskItem.Status = TaskItemStatus.QA;
            taskItem.WorkflowState = new QAState(taskItem);
            Console.WriteLine("✅ Task moved from Code Review to QA.");
        }

        public override void MoveToPrevious()
        {
            taskItem.Status = TaskItemStatus.InProgress;
            taskItem.WorkflowState = new InProgressState(taskItem);
            Console.WriteLine("🔄 Task moved back to In Progress.");
        }

        public override string GetStatus() => "Code Review";
    }

}

