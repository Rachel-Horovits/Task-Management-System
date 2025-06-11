using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.src.core.entities;
using TaskManagement.src.core.enums;

namespace TaskManagement.src.core.services
{
    public class UserFactory
    {
        private static Dictionary<string, User> _users = new Dictionary<string, User>();
        public static User GetUser(string email, string name, Role role)
        {
            string key = $"{email}{role}";
            if (!_users.ContainsKey(key))
                _users[key] = new User { Email = email, Name = name, UserRole = role };
            return _users[key];
        }
    }
}
