using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Leave_Management_4.Models;

namespace Leave_Management_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly UmapanditDbContext _context;

        public LeavesController(UmapanditDbContext context)
        {
            _context  = context;

        }

        // GET: api/Leaves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leave>>> GetLeaves()
        {
            return await _context.Leaves.ToListAsync();
        }
        [Route("Leavedetailsbyemployee")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leave>>> GetLeaveDetails(string eid)
        {
            var result = await _context.Leaves.Where(e => e.EmployeeId == eid).ToListAsync();



            if (result == null)
            {
                return NotFound();
            }



            return result;
        }

        // GET: api/Leaves/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Leave>> GetLeave(int id)
        //{
        //    var leave = await _context.Leaves.FindAsync(id);

        //    if (leave == null)
        //    {
        //        return NotFound();
        //    }

        //    return leave;
        //}

        [HttpGet("{LeaveId}")]
        public string SendEmployeeId(string UserEmail)
        {
            Employee employee = _context.Employees.Where(e => e.EmployeeEmailId == UserEmail).FirstOrDefault();

            return employee.EmployeeId.ToString();
        }

        //[Route("GetPendingLeaveapplications")]
        //[HttpPost]
        //public IEnumerable<Leave> GetPendingLeaveapplications(string eid)
        //{
        //    var manager = _context.Employees.Find(int.Parse(eid)).EmployeeName;
        //    var employees = _context2.Employees.AsEnumerable().Where(e => e.ManagerName == manager).ToList();
        //    var pendingleaves = _context3.Leaves.AsEnumerable().Where(l => l.Status == "Pending").ToList();
        //    var result = pendingleaves.Where(l => employees.Any(e => int.Parse(l.EmployeeId) == e.EmployeeId)).ToList();

        //    return result;



        //}


        [Route("Actionbymanager")]
        [HttpPatch]
        public string ActionByManager(int lid, string status, string comment)
        {
            var leave = _context.Leaves.FirstOrDefault(l => l.LeaveId == lid);
            leave.Status = status;
            leave.ManagerComments = comment;
            _context.SaveChanges();
            return "Success";
        }

        // PUT: api/Leaves/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeave(int id, Leave leave)
        {
            if (id != leave.LeaveId)
            {
                return BadRequest();
            }

            _context.Entry(leave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Leaves
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Leave>> PostLeave(Leave leave)
        {
            _context.Leaves.Add(leave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeave", new { id = leave.LeaveId }, leave);
        }

        // DELETE: api/Leaves/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Leave>> DeleteLeave(int id)
        {
            var leave = await _context.Leaves.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            _context.Leaves.Remove(leave);
            await _context.SaveChangesAsync();

            return leave;
        }

        private bool LeaveExists(int id)
        {
            return _context.Leaves.Any(e => e.LeaveId == id);
        }
    }
}
