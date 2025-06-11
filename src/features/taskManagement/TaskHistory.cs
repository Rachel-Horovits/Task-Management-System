using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.src.features.taskManagement
{
    public class TaskHistory
    {
        private static readonly Stack<TaskItemMemento> _history = new Stack<TaskItemMemento>();

        // שמירת מצב נוכחי
        public void SaveState(TaskItemMemento memento)
        {
            _history.Push(memento);
        }

        // שחזור מצב קודם
        public TaskItemMemento Undo()
        {
            if (_history.Count > 0)
            {
                return _history.Pop();
            }
            else
            {
                throw new InvalidOperationException("No previous state to undo.");
            }
        }

        // צפייה בהיסטוריית השינויים
        public IEnumerable<TaskItemMemento> GetHistory()
        {
            return _history.ToList();
        }
    }

}



