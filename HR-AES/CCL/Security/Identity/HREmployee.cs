using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class HREmployee : User
    {
        public HREmployee(int userId, string name, int departmentId)
            : base(userId, name, departmentId, nameof(HREmployee))
        {
        }
    }
}
