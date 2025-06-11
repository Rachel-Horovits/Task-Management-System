using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.src.features.notifications
{
    class EmailNotifier : NotificationDecorator
    {
        private string _emailAddress;
        public EmailNotifier(NotificationDecorator baseNotification, string emailAddress) : base(baseNotification)
        {
            _emailAddress = emailAddress;
        }
        public void Send(string message)
        {

            Console.WriteLine($"📧 Email sent: {message}");
            base.Send(message);

        }
    }
}
