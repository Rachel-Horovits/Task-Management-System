using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.src.features.notifications
{
    abstract class NotificationDecorator
    {
        private NotificationDecorator baseNotification = null;

        public NotificationDecorator(NotificationDecorator baseDecorator)
        {
            baseNotification = baseDecorator;
        }

        public virtual void Send(string message)
        {
            baseNotification.Send(message);
        }
    }
}
