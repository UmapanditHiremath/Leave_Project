using AutoMapper;
using Leave_Management_4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management_4.Repository
{
    public class EmployeeRepo : IEmployee
    {
        private readonly UmapanditDbContext umapanditDbContext;
        private readonly IMapper mapper;

        public EmployeeRepo(UmapanditDbContext umapanditDbContext, IMapper mapper)
        {
            this.umapanditDbContext = umapanditDbContext;
            this.mapper = mapper;
        }

        public async Task<int> AddEmployees(Employee employees)
        {
            var emp = new Employee()
            {
                EmployeeId = employees.EmployeeId,
                EmployeeName = employees.EmployeeName,
                EmployeeEmailId = employees.EmployeeEmailId,
                MobileNo = employees.MobileNo,
                DateJoined = employees.DateJoined,
                Department = employees.Department,
                AvailableLeave=employees.AvailableLeave

            };
            umapanditDbContext.Employees.Add(emp);
            await umapanditDbContext.SaveChangesAsync();
            return emp.EmployeeId;
        }

        public async Task<int> DeleteEmployees(int id)
        {
            var ar = umapanditDbContext.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            if (ar != null)
            {
                umapanditDbContext.Employees.Remove(ar);
            }

            await umapanditDbContext.SaveChangesAsync();
            return ar.EmployeeId;
        }

        public async Task<List<Employee>> GetEmployee()
        {
            List<Employee> emplst = new List<Employee>();
            var ar = await umapanditDbContext.Employees.ToListAsync();
            foreach (Employee em in ar)
            {
                emplst.Add(new Employee
                {
                    EmployeeId = em.EmployeeId,
                    EmployeeName = em.EmployeeName,
                    EmployeeEmailId = em.EmployeeEmailId,
                    MobileNo = em.MobileNo,
                    DateJoined = em.DateJoined,
                    Department = em.Department,
                    AvailableLeave=em.AvailableLeave

                });
            }
            return emplst;
        }

        public async Task<int> UpdateEmployees(int id, Employee employees)
        {
            var ar = umapanditDbContext.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            if (ar != null)
            {
                ar.EmployeeEmailId = employees.EmployeeEmailId;
                ar.MobileNo = employees.MobileNo;
            }

            await umapanditDbContext.SaveChangesAsync();
            return ar.EmployeeId;
        }
    }
}
