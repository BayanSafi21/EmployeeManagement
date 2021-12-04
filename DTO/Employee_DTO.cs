using EmployeeManagement.DTO.Employee_Enum;
using EmployeeManagement.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;

namespace EmployeeManagement.DTO
{
    
    public class Employee_DTO
    {
        [Required(ErrorMessageResourceName = "name_required", ErrorMessageResourceType = typeof(Strings))]
        [MaxLength((int)Numbers.OneHundred, ErrorMessageResourceName = "name_length", ErrorMessageResourceType = typeof(Strings))]
        public string FullName { get; set; }
        [Required(ErrorMessageResourceName = "salary_required", ErrorMessageResourceType = typeof(Strings))]
        [Range((int)Numbers.One, double.MaxValue, ErrorMessageResourceName = "salary_range", ErrorMessageResourceType = typeof(Strings))]
        public decimal Salary { get; set; }
        [Required(ErrorMessageResourceName = "phone_required", ErrorMessageResourceType = typeof(Strings))]
        [StringLength((int)Numbers.Thirteen, MinimumLength = (int)Numbers.Ten, ErrorMessageResourceName = "phone_invalid", ErrorMessageResourceType = typeof(Strings))]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessageResourceName = "department_required", ErrorMessageResourceType = typeof(Strings))]
        public int DepartmentID { get; set; }
        [Required(ErrorMessageResourceName = "country_required", ErrorMessageResourceType = typeof(Strings))]
        public int CountryID { get; set; }
        
        
    }
    public class Updated_Employee_DTO
    {
        [Required(ErrorMessageResourceName = "Id_required", ErrorMessageResourceType = typeof(Strings))]
        [Range((int)Numbers.One, Int32.MaxValue, ErrorMessageResourceName = "Id_range", ErrorMessageResourceType = typeof(Strings))]
        public int ID { get; set; }
        [Required(ErrorMessageResourceName = "name_required", ErrorMessageResourceType = typeof(Strings))]
        [MaxLength((int)Numbers.OneHundred, ErrorMessageResourceName = "name_length", ErrorMessageResourceType = typeof(Strings))]
        public string FullName { get; set; }
        [Required(ErrorMessageResourceName = "salary_required", ErrorMessageResourceType = typeof(Strings))]
        [Range((int)Numbers.One, double.MaxValue, ErrorMessageResourceName = "salary_range", ErrorMessageResourceType = typeof(Strings))]
        public decimal Salary { get; set; }
        [Required(ErrorMessageResourceName = "phone_required", ErrorMessageResourceType = typeof(Strings))]
        [StringLength((int)Numbers.Thirteen, MinimumLength = (int)Numbers.Ten, ErrorMessageResourceName = "phone_invalid", ErrorMessageResourceType = typeof(Strings))]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessageResourceName = "department_required", ErrorMessageResourceType = typeof(Strings))]
        public int DepartmentID { get; set; }
        [Required(ErrorMessageResourceName = "country_required", ErrorMessageResourceType = typeof(Strings))]
        public int CountryID { get; set; }


    }

}
