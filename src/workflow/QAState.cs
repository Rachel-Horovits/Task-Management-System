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


    public class QAState : TaskState
    {
        public QAState(TaskItem taskItem) : base(taskItem) { }

        public override void MoveToNext()
        {
            if (AccessControl.CanQAAndMarkTaskAsDone(taskItem.Assignee))
                taskItem.Status = TaskItemStatus.Done;
            taskItem.WorkflowState = new DoneState(taskItem);
            Console.WriteLine("✅ Task passed QA and is now Done.");
        }

        public override void MoveToPrevious()
        {
            if (AccessControl.CanReviewAndApproveCode(taskItem.Assignee))
                taskItem.Status = TaskItemStatus.CodeReview;
            taskItem.WorkflowState = new CodeReviewState(taskItem);
            Console.WriteLine("🔄 Task returned to Code Review due to issues.");
        }

        public override string GetStatus() => "QA";
    }



}