using EmployeeManagement.DTO.Employee_Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
        public class Response
        {
            public bool isError { get; set; }
            public StatusMessage StatusMessage { get; set; }
        }
        public class StatusMessage
        {
            public ResponseCodes Code { get; set; }
            public string message { get; set; }
            public List<Employee> Data { get; set; }

        }
}
