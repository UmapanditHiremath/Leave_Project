using Leave_Management_4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management_4.Repository
{
    public class ManagerRepo : IManager
    {
        private readonly UmapanditDbContext umapanditDbContext;

        public ManagerRepo(UmapanditDbContext umapanditDbContext)
        {
            this.umapanditDbContext = umapanditDbContext;
        }
        public async Task<int> AddManager(Manager managers)
        {
            var man = new Manager()
            {
                ManagerId = managers.ManagerId,
                ManagerName = managers.ManagerName,
                ManagerEmailId = managers.ManagerEmailId,
                MobileNo = managers.MobileNo,

            };
            umapanditDbContext.Managers.Add(man);
            await umapanditDbContext.SaveChangesAsync();
            return man.ManagerId;
        }

        public async Task<int> DeleteManager(int id)
        {
            var ar = umapanditDbContext.Managers.Where(x => x.ManagerId == id).FirstOrDefault();
            if (ar != null)
            {
                umapanditDbContext.Managers.Remove(ar);
            }

            await umapanditDbContext.SaveChangesAsync();
            return ar.ManagerId;
        }

        public async Task<List<Manager>> GetManager()
        {
            List<Manager> manlst = new List<Manager>();
            var ar = await umapanditDbContext.Managers.ToListAsync();
            foreach (Manager m in ar)
            {
                manlst.Add(new Manager
                {
                    ManagerId = m.ManagerId,
                    ManagerName = m.ManagerName,
                    ManagerEmailId = m.ManagerEmailId,
                    MobileNo = m.MobileNo
                });
            }
            return manlst;
        }

        public async Task<int> UpdateManager(int id, Manager managers)
        {
            var ar = umapanditDbContext.Managers.Where(x => x.ManagerId == id).FirstOrDefault();
            if (ar != null)
            {
                ar.ManagerEmailId = managers.ManagerEmailId;
                ar.MobileNo = managers.MobileNo;
            }

            await umapanditDbContext.SaveChangesAsync();
            return ar.ManagerId;
        }
    }
}
