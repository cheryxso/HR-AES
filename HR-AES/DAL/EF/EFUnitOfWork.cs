using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.Impl;
using DAL.Repositories.UnitOfWork;
using System;

namespace DAL.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRContext _context;

        private IDepartmentRepository _departmentRepository;
        private IEmployeeRepository _employeeRepository;
        private IRequestRepository _requestRepository;

        public UnitOfWork(HRContext context)
        {
            _context = context;
        }

        public IDepartmentRepository Departments
        {
            get
            {
                if (_departmentRepository == null)
                {
                    _departmentRepository = new DepartmentRepository(_context);
                }
                return _departmentRepository;
            }
        }

        public IEmployeeRepository Employees
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_context);
                }
                return _employeeRepository;
            }
        }

        public IRequestRepository Requests
        {
            get
            {
                if (_requestRepository == null)
                {
                    _requestRepository = new RequestRepository(_context);
                }
                return _requestRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
