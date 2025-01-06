using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class HRSupervisor : User
    {
        public HRSupervisor(int userId, string name, int departmentId)
            : base(userId, name, departmentId, nameof(HRSupervisor))
        {
        }
    }
}
