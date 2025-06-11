using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.src.core.enums;

namespace TaskManagement.src.core.services
{
    public class PriorityFactory
    {
        private static Dictionary<string, Priority> _priorityFactory = new Dictionary<string, Priority>();
        public static Priority GetPriority(Priority priority)
        {
            string priorityString = priority.ToString();
            if (!_priorityFactory.ContainsKey(priorityString))
                _priorityFactory[priorityString] = priority;
            return _priorityFactory[priorityString];
        }
    }
}
