using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.src.core.entities;
using TaskManagement.src.core.enums;

namespace TaskManagement.src.features.userManagement
{
    public static class AccessControl
    {
        public static bool CanReviewAndApproveCode(User user)
        {
            return user.UserRole == Role.Manager;
        }

        public static bool CanQAAndMarkTaskAsDone(User user)
        {
            return user.UserRole == Role.QA;
        }

    }
}
