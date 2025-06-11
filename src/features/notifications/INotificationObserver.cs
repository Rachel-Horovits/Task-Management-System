using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.src.features.notifications
{
    public interface INotificationObserver
    {
        string Email { get; set; }
        void Update(string message);
    }
}
