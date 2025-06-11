using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.src.core.enums;

namespace TaskManagement.src.core.services
{
    public class TaskStatusFactory
    {
        private static readonly Dictionary<string, TaskItemStatus> _taskStatus = new Dictionary<string, TaskItemStatus>();
        public static TaskItemStatus GetTaskItemStatus(TaskItemStatus status)
        {
            string statusString = status.ToString();
            if (!_taskStatus.ContainsKey(statusString))
                _taskStatus[statusString] = status;

            return _taskStatus[statusString];
        }

    }
}
