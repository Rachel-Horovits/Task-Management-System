using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.src.core.entities;
using TaskManagement.src.core.enums;

namespace TaskManagement.src.features.taskManagement
{
    public class TaskItemMemento
    {
        public DateTime CreationDate { get; }
        public string Title { get; }
        public string Description { get; }
        public User Assignee { get; }
        public User Reporter { get; }
        public TaskItemStatus Status { get; }
        public Priority Priority { get; }
        public double? EstimationTime { get; }
        public double? LoggedTime { get; }
        public List<TaskItem> Subtasks { get; }

        public TaskItemMemento(DateTime creationDate, string title, string description, User assignee, User reporter,
                               TaskItemStatus status, Priority priority, double? estimationTime,
                               double? loggedTime, List<TaskItem> subtasks)
        {
            CreationDate = creationDate;
            Title = title;
            Description = description;
            Assignee = assignee;
            Reporter = reporter;
            Status = status;
            Priority = priority;
            EstimationTime = estimationTime;
            LoggedTime = loggedTime;
            Subtasks = subtasks != null ? new List<TaskItem>(subtasks) : new List<TaskItem>();
        }
    }
}
