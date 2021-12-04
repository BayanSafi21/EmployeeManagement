using EmployeeManagement.Context;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository
    {
        private readonly AuthContext _ctx;
        public EmployeeRepository(AuthContext authContext)
        {
            _ctx = authContext;
        }
        public List<Models.Employee> getAll(){
                return _ctx.Employees.Include("Department").Include("Country").ToList();
             }
        public List<Models.Employee> getEmp(int id)
        {
            return _ctx.Employees.Include("Department").Include("Country").Where(e => e.ID == id).ToList();
        }
        public List<Models.Employee> AddEmp(Employee emp)
        {
            if (CheckDepartment(emp.DepartmentID) && CheckCountry(emp.CountryID))
            {
                _ctx.Employees.Add(emp);
                _ctx.SaveChanges();
                return _ctx.Employees.Include("Department").Include("Country").Where(e=>e.ID==emp.ID).ToList();
            }
            else {
                return null;
                    }
        }
        public List<Models.Employee> UpdateEmp(Employee emp)
        {
            var updatedEmp = _ctx.Employees.First(e => e.ID == emp.ID);
            if (updatedEmp != null)
            {
                if (CheckDepartment(emp.DepartmentID) && CheckCountry(emp.CountryID))
                {
                    _ctx.Employees.Update(emp);
                    _ctx.SaveChanges();
                    return _ctx.Employees.Include("Department").Include("Country").Where(e => e.ID == emp.ID).ToList();
                }
                else
                {
                    return null;
                }
            }
            else {
                return null;
            }

        }
        public bool DeleteEmp(int id)
        {
            var emp= _ctx.Employees.First(e => e.ID == id);
            if (emp != null)
            {
                _ctx.Employees.Remove(emp);
                _ctx.SaveChanges();
                return true;
            }
            else {
                return false;
            }

          
        }
        public bool CheckDepartment(int id)
        {
            return _ctx.Department.Any(x => x.ID == id);
        }
        public bool CheckCountry(int id)
        {
            return _ctx.Country.Any(x => x.ID == id);
        }
    }
}
