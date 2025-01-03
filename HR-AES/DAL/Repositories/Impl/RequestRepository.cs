using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Impl
{
    public class RequestRepository : BaseRepository<Request>, IRequestRepository
    {
        public RequestRepository(DbContext context) : base(context) { }

        public IEnumerable<Request> GetRequestsByStatus(RequestStatus status)
        {
            return _set.Where(r => r.Status == status).ToList();
        }

        public IEnumerable<Request> GetRequestsByEmployee(int employeeId)
        {
            return _set.Where(r => r.EmployeeId == employeeId).ToList();
        }
    }
}
