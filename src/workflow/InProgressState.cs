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

    public class InProgressState : TaskState
    {
        public InProgressState(TaskItem taskItem) : base(taskItem) { }

        public override void MoveToNext()
        {
            if (AccessControl.CanReviewAndApproveCode(taskItem.Assignee))
                taskItem.Status = TaskItemStatus.CodeReview;
            taskItem.WorkflowState = new CodeReviewState(taskItem);
            Console.WriteLine("✅ Task moved from In Progress to Code Review.");
        }

        public override void MoveToPrevious()
        {
            taskItem.Status = TaskItemStatus.ToDo;
            taskItem.WorkflowState = new ToDoState(taskItem);
            Console.WriteLine("🔄 Task moved back to To Do.");
        }

        public override string GetStatus() => "In Progress";
    }

}
