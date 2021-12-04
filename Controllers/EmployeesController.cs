using EmployeeManagement.Context;
using EmployeeManagement.DTO.Employee_Enum;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly EmployeeRepository _repository;
        public EmployeesController(AuthContext authContext)
        {
            _repository = new EmployeeRepository(authContext);
        }
        [HttpGet]
        [Route("GetAllEmployees")]
        public Response GetAllEmployees()
        {
            var response = new Response();
            try {
                List<Models.Employee> EmployeesList = _repository.getAll(); ;
                response.isError = false;
                var StatusMessage = new StatusMessage()
                {
                    Code = ResponseCodes.Success,
                    message = Strings.success,
                    Data = EmployeesList
                };
                response.StatusMessage = StatusMessage;
                return response;
            }
            catch (Exception ex) {
                response.isError = true;
                var StatusMessage = new StatusMessage()
                {
                    Code = ResponseCodes.Failed,
                    message = Strings.failed_getData,
                    Data =null
                };
                response.StatusMessage = StatusMessage;
                return response;
            }
            
        }
        [HttpPost]
        [Route("AddEmployee")]
        public Response AddEmployee(DTO.Employee_DTO newEmployee)
        {
            var response = new Response();
            try
            {
                Employee employee = new Employee();
                employee.FullName = newEmployee.FullName;
                employee.PhoneNumber = newEmployee.PhoneNumber;
                employee.Salary = newEmployee.Salary;
                employee.CountryID = newEmployee.CountryID;
                employee.DepartmentID = newEmployee.DepartmentID;
                var result = _repository.AddEmp(employee);
                    if (result != null)
                    {
                        response.isError = false;
                        var StatusMessage = new StatusMessage()
                        {
                            Code = ResponseCodes.Success,
                            message = Strings.success,
                            Data = result
                        };
                        response.StatusMessage = StatusMessage;
                        return response;
                    }
                    else{
                        response.isError = true;
                        var StatusMessage = new StatusMessage()
                        {
                            Code = ResponseCodes.FailedAdd,
                            message = Strings.failed_addData,
                            Data = null
                        };
                        response.StatusMessage = StatusMessage;
                        return response;
                    }               
            }
            catch (Exception ex)
            {
                response.isError = true;
                var StatusMessage = new StatusMessage()
                {
                    Code = ResponseCodes.Failed,
                    message = Strings.failed_addData,
                    Data = null
                };
                response.StatusMessage = StatusMessage;
                return response;
            }
        }
        [HttpGet]
        [Route("GetEmployee")]
        public Response GetEmployee(int ID)
        {
            var response = new Response();
            try
            {
                List<Models.Employee> EmployeesList = _repository.getEmp(ID); ;
                response.isError = false;
                var StatusMessage = new StatusMessage()
                {
                    Code = ResponseCodes.Success,
                    message = Strings.success,
                    Data = EmployeesList
                };
                response.StatusMessage = StatusMessage;
                return response;
            }
            catch (Exception ex)
            {
                response.isError = true;
                var StatusMessage = new StatusMessage()
                {
                    Code = ResponseCodes.Failed,
                    message = Strings.failed_getData,
                    Data = null
                };
                response.StatusMessage = StatusMessage;
                return response;
            }

        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public Response UpdateEmployee(DTO.Updated_Employee_DTO updatedEmployee)
        {
            var response = new Response();
            try
            {
                Employee employee = new Employee();
                employee.ID = updatedEmployee.ID;
                employee.FullName = updatedEmployee.FullName;
                employee.PhoneNumber = updatedEmployee.PhoneNumber;
                employee.Salary = updatedEmployee.Salary;
                employee.CountryID = updatedEmployee.CountryID;
                employee.DepartmentID = updatedEmployee.DepartmentID;
                var result = _repository.UpdateEmp(employee);
                if (result != null)
                {
                    response.isError = false;
                    var StatusMessage = new StatusMessage()
                    {
                        Code = ResponseCodes.Success,
                        message = Strings.success,
                        Data = result
                    };
                    response.StatusMessage = StatusMessage;
                    return response;
                }
                else
                {
                    response.isError = true;
                    var StatusMessage = new StatusMessage()
                    {
                        Code = ResponseCodes.FailedAdd,
                        message = Strings.failed_updateData,
                        Data = null
                    };
                    response.StatusMessage = StatusMessage;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.isError = true;
                var StatusMessage = new StatusMessage()
                {
                    Code = ResponseCodes.Failed,
                    message = Strings.failed_updateData,
                    Data = null
                };
                response.StatusMessage = StatusMessage;
                return response;
            }
        }
        [HttpDelete]
        [Route("DeleteEmployee")]
        public Response DeleteEmployee(int ID)
        {
            var response = new Response();
            try
            {
                bool result = _repository.DeleteEmp(ID);
                if (result)
                {
                    response.isError = false;
                    var StatusMessage = new StatusMessage()
                    {
                        Code = ResponseCodes.Success,
                        message = Strings.success,
                        Data = null
                    };
                    response.StatusMessage = StatusMessage;
                    return response;
                }
                else {
                    response.isError = true;
                    var StatusMessage = new StatusMessage()
                    {
                        Code = ResponseCodes.Failed,
                        message = Strings.failed_deleteData,
                        Data = null
                    };
                    response.StatusMessage = StatusMessage;
                    return response;
                } 
            }
            catch (Exception ex)
            {
                response.isError = true;
                var StatusMessage = new StatusMessage()
                {
                    Code = ResponseCodes.Failed,
                    message = Strings.failed_deleteData,
                    Data = null
                };
                response.StatusMessage = StatusMessage;
                return response;
            }

        }
    }
}
