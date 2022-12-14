using Leave_Management_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management_4.Repository
{
    interface ILeaveApplication
    {
        Task<List<Leave>> LeaveDet();
        Task<int> AddLeaves(Leave leaves);
        Task<int> UpdateLeaves(int id, Leave leaves);
        Task<int> DeleteLeaves(int id);
    }
}
