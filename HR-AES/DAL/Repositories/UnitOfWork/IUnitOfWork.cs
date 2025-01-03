using DAL.Repositories.Interfaces;
using System;

namespace DAL.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository Departments { get; }
        IEmployeeRepository Employees { get; }
        IRequestRepository Requests { get; }
        void Save();
    }
}
