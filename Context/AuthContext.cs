using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Context
{
    using Microsoft.EntityFrameworkCore;
    using EmployeeManagement.Models;
    public class AuthContext
     : DbContext
    {
        public AuthContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Country> Country { get; set; }

       

     }
}
