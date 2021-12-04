using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DTO.Employee_Enum
{
    public enum Numbers
    {
        One = 1,OneHundred = 100,Fifteen = 50,Thirteen = 13,Ten = 10
    }
    public enum ResponseCodes
    {
       Success=200,
        Failed=500,
        FailedAdd=400
    }
}