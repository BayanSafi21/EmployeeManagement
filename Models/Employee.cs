using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal Salary { get; set; }
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        public int CountryID { get; set; }
        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
    }
}
