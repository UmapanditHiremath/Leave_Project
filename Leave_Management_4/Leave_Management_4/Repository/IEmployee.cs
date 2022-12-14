using Leave_Management_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management_4.Repository
{
    interface IEmployee
    {
        Task<List<Employee>> GetEmployee();
        Task<int> AddEmployees(Employee employees);
        Task<int> UpdateEmployees(int id, Employee employees);
        Task<int> DeleteEmployees(int id);
    }
}
