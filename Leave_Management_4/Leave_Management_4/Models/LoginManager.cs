using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management_4.Models
{
    public class LoginManager
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
