using Leave_Management_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management_4.Repository
{
    interface IManager
    {
        Task<List<Manager>> GetManager();
        Task<int> AddManager(Manager managers);
        Task<int> UpdateManager(int id, Manager managers);
        Task<int> DeleteManager(int id);
    }
}
