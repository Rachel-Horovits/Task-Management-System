using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.src.features.notifications
{
    class BasicNotifier : NotificationDecorator
    {
        public BasicNotifier() : base(null)
        {

        }
        public override void Send(string message)
        {
            Console.WriteLine($"📢 Basic Notification: {message}");
        }
    }
}
