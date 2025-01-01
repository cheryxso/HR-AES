using DAL.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Repositories.Interfaces
{
    public interface IEmployeeRepository 
        : IRepository<Employee>
    {
    }
}
