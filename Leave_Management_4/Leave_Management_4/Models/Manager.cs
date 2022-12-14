using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management_4.Models
{
    public  class Manager
    {
        [Required(ErrorMessage = "Enter Your ID")]
        public int ManagerId { get; set; }
        [Required(ErrorMessage = "Enter Name ")]
        public string ManagerName { get; set; }
        [Required(ErrorMessage = "Enter Email ID")]
        public string ManagerEmailId { get; set; }
        [Required(ErrorMessage = "Enter Mobile number")]
        public int MobileNo { get; set; }
    }
}
