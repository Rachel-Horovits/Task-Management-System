using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.src.features.notifications
{
    class SmsNotifier : NotificationDecorator
    {
        private string _sms;
        public SmsNotifier(NotificationDecorator baseNotification, string sms) : base(baseNotification)
        {
            _sms = sms;
        }
        public void Send(string message)
        {

            Console.WriteLine($"📧 Email sent: {message}");
            base.Send(message);

        }
    }
}
