using Leave_Management_4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management_4.Repository
{
    public class LeaveApplicationRepo : ILeaveApplication
    {
        private readonly UmapanditDbContext umapanditDbContext;

        public LeaveApplicationRepo(UmapanditDbContext umapanditDbContext)
        {
            this.umapanditDbContext = umapanditDbContext;
        }
        public async Task<int> AddLeaves(Leave leaves)
        {
            var le = new Leave()
            {
                LeaveId = leaves.LeaveId,
                NoOfDays = leaves.NoOfDays,
                StartDate = leaves.StartDate,
                EndDate = leaves.EndDate,
                LeaveType = leaves.LeaveType,
                Status = leaves.Status,
                Reason = leaves.Reason,
                ManagerComments = leaves.ManagerComments
            };
            umapanditDbContext.Leaves.Add(le);
            await umapanditDbContext.SaveChangesAsync();
            return le.LeaveId;
        }

        public async Task<int> DeleteLeaves(int id)
        {
            var ar = umapanditDbContext.Leaves.Where(x => x.LeaveId == id).FirstOrDefault();
            if (ar != null)
            {
                umapanditDbContext.Leaves.Remove(ar);
            }

            await umapanditDbContext.SaveChangesAsync();
            return ar.LeaveId;
        }

        public async Task<List<Leave>> LeaveDet()
        {
            List<Leave> leavelst = new List<Leave>();
            var ar = await umapanditDbContext.Leaves.ToListAsync();
            foreach (Leave le in ar)
            {
                leavelst.Add(new Leave
                {
                    LeaveId = le.LeaveId,
                    NoOfDays = le.NoOfDays,
                    StartDate = le.StartDate,
                    EndDate = le.EndDate,
                    LeaveType = le.LeaveType,
                    Status = le.Status,
                    Reason = le.Reason,
                    ManagerComments = le.ManagerComments
                });
            }

            return leavelst;

        }

        public async Task<int> UpdateLeaves(int id, Leave leaves)
        {
            var ar = umapanditDbContext.Leaves.Where(x => x.LeaveId == id).FirstOrDefault();
            if (ar != null)
            {

                ar.Status = leaves.Status;
                ar.LeaveType = leaves.LeaveType;
                ar.StartDate = ar.StartDate;
                ar.EndDate = ar.EndDate;

            }

            await umapanditDbContext.SaveChangesAsync();
            return ar.LeaveId;
        }
    }
    
}
