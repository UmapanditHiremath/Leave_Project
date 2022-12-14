using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management_4.Models
{
    public class Leave
    {
        [Required(ErrorMessage = "Enter Leave ID")]
        public int LeaveId { get; set; }
        [Required(ErrorMessage = "Enter no of days")]
        public string NoOfDays { get; set; }
        [Required(ErrorMessage = "Enter Start Dtae")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Enter End Date")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Enter Leave Type")]
        public string LeaveType { get; set; }
        [Required]
        public string Status { get; set; }
        public string Reason { get; set; }

        [DataType(DataType.Date)]
        public string AppliedOn { get; set; }

        public string ManagerComments { get; set; }

        
        public string EmployeeId { get; set; }
    }
}
