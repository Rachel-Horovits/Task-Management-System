using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.src.features.notifications
{
    public class TaskNotifier
    {


        private static Dictionary<string, INotificationObserver> _observers = new Dictionary<string, INotificationObserver>();
        public void Subscribe(INotificationObserver observer)
        {

            string key = $"{observer.Email}";
            if (!_observers.ContainsKey(key))
                _observers[key] = observer;


        }
        public void Unsubscribe(INotificationObserver observer)
        {
            if (observer == null)
            {
                Console.WriteLine("Observer cannot be null.");
                return;
            }

            User user = observer as User;
            if (user == null)
            {
                Console.WriteLine("Observer is not a User.");
                return;
            }

            string key = $"{user.Email}";
            if (_observers.Remove(key))
                Console.WriteLine($"this {user.Email} Unsubscribed");
            else
            {
                Console.WriteLine($"this {user.Email} does not exist");
            }
        }



        public void Notify(string message)
        {
            foreach (var observer in _observers.Values) // מעבר רק על הערכים (INotificationObserver)
            {
                observer.Update(message);
            }
        }


        public void NotifyToSingleObserver(string message, INotificationObserver observer)
        {
            observer.Update(message);
        }

    }
}
