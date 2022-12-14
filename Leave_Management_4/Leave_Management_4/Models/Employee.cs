using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management_4.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Employee Name is required")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Employee Email ID is required")]
        public string EmployeeEmailId { get; set; }
        [Required(ErrorMessage = "Employee Mpbile no is required")]
        public long MobileNo { get; set; }
        
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]

        public string ConPassword { get; set; }
        [Required]
        public DateTime DateJoined { get; set; }
        [Required]
        public string Department { get; set; }
        public int AvailableLeave { get; set; }
        
        //public string ManagerName { get; set; }
    }
}
