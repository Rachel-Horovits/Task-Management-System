using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.src.core.entities;
using TaskManagement.src.core.enums;
using TaskManagement.src.core.services;

namespace TaskManagement.src.features.taskManagement
{
    public class TaskBuilder
    {
        private readonly TaskItem _taskItem;
        private bool _isAssigneeSet;
        private bool _isReporterSet;
        private bool _isPrioritySet;
        public TaskBuilder()
        {
            _taskItem = new TaskItem();
        }
        public TaskBuilder WithTitle(string title)

        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            _taskItem.Title = title;
            Console.WriteLine("add Title");
            return this;
        }
        public TaskBuilder WithDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));

            _taskItem.Description = description;
            Console.WriteLine("add Description");
            return this;
        }
        public TaskBuilder WithAssignee(User user)
        {
              if(user == null)    
                  throw new ArgumentNullException(nameof(user));

            _taskItem.Assignee = UserFactory.GetUser(user.Email, user.Name, user.UserRole);
            Console.WriteLine("add Assignee");
            _isAssigneeSet = true;
            return this;
        }
        public TaskBuilder WithReporter(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _taskItem.Reporter = UserFactory.GetUser(user.Email, user.Name, user.UserRole);
            Console.WriteLine("add Reporter");
            _isReporterSet = true;
            return this;


        }
       
        public TaskBuilder WithPriority(Priority priority)
        {
            if (!Enum.IsDefined(typeof(Priority), priority))
                throw new ArgumentException("Invalid priority value.", nameof(Priority));

            _taskItem.Priority = PriorityFactory.GetPriority(priority);
            _isPrioritySet = true;
            Console.WriteLine("add Priority");

             return this;
        }
        public TaskBuilder WithEstimationTime(double estimationTime)
        {
            if (estimationTime < 0)
                throw new ArgumentException("Estimation time cannot be negative.", nameof(estimationTime));

            _taskItem.PrivateEstimationTime = estimationTime;
            Console.WriteLine("add estimationTime");
            return this;
        }
        public TaskBuilder WithLoggedTime(double loggedTime)
        {
            if (loggedTime < 0)
                throw new ArgumentException("Logged time cannot be negative.", nameof(loggedTime));

            _taskItem.MyLoggedTime = loggedTime;
            Console.WriteLine("add MyLoggedTime");
            return this;
        }
        public TaskBuilder WithSubtasks(List<TaskItem> taskItems)
        {
            _taskItem.Subtasks = taskItems ?? throw new ArgumentNullException(nameof(taskItems));
            Console.WriteLine("add Subtasks");
            return this;
        }
        public void WithAddTask(TaskItem task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            _taskItem.Subtasks.Add(task);
        }

        private void ValidateTaskItem()
        {
            if (string.IsNullOrWhiteSpace(_taskItem.Title))
                throw new InvalidOperationException("Title must be set.");

            if (string.IsNullOrWhiteSpace(_taskItem.Description))
                throw new InvalidOperationException("Description must be set.");

            if (!_isAssigneeSet)
                throw new InvalidOperationException("Assignee must be set.");

            if (!_isReporterSet)
                throw new InvalidOperationException("Reporter must be set.");

            if (!_isPrioritySet)
                throw new InvalidOperationException("Priority must be set.");
        }

        public TaskItem Build()
        {
            ValidateTaskItem();
            Console.WriteLine("valid task build");
            return _taskItem;
        }
    }
}


