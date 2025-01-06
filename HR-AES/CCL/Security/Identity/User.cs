using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public abstract class User
    {
        public User(int userId, string name, int departmentId, string userType)
        {
            UserId = userId;
            Name = name;
            DepartmentId = departmentId;
            UserType = userType;
        }

        public int UserId { get; }
        public string Name { get; }
        public int DepartmentId { get; }
        protected string UserType { get; }
    }
}
