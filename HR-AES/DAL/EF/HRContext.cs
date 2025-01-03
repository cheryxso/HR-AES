using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using System.Reflection.Emit;

namespace DAL.EF
{
    public class HRContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Request> Requests { get; set; }

        public HRContext(DbContextOptions<HRContext> options) : base(options)
        {
        }
    }
}
