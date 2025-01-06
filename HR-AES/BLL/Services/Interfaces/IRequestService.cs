using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IRequestService
    {
        IEnumerable<RequestDTO> GetRequests(int employeeId);
        RequestDTO GetRequestById(int id);
    }
}
