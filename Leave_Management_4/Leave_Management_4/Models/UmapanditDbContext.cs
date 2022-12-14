using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leave_Management_4.Models;

namespace Leave_Management_4.Models
{
    public class UmapanditDbContext:DbContext
    {
        public UmapanditDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Manager> Managers { get; set; }

        public DbSet<Login> Logins { get; set; }
        public DbSet<LoginManager> LoginManagers { get; set; }
    }
}
