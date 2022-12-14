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
    public class LoginsController : ControllerBase
    {
        private readonly UmapanditDbContext _context;

        public LoginsController(UmapanditDbContext context)
        {
            _context = context;
        }

        // GET: api/Logins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login>>> GetLogins()
        {
            return await _context.Logins.ToListAsync();
        }

        // GET: api/Logins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> GetLogin(int id)
        {
            var login = await _context.Logins.FindAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return login;
        }

        // PUT: api/Logins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogin(int id, Login login)
        {
            if (id != login.UserId)
            {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
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

        // POST: api/Logins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Login>> PostLogin(Login login)
        //{
        //    _context.Logins.Add(login);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetLogin", new { id = login.UserId }, login);
        //}
        //[HttpPost]
        //public string PostLogin1(string UserName, string Password)
        //{
        //    Login login = _context.Employees.
        //        Where(log => log.EmployeeName == UserName && log.Password == Password)
        //       .FirstOrDefault();

        //    if (login == null)
        //    {
        //        return "Invalid credentials";
        //    }

        //    return "Login Success";
        //}

        [HttpPost]
        public string PostLogin(Login login)
        {
            if
                  (_context.Employees.Any(log => log.EmployeeName == login.UserName && log.Password == login.Password))
            {
                return "Login Success";
            }
            else
            {
                return "Invalid credentials";
            }
        }
        //public async Task<ActionResult<Leave>> PostLeave(Leave leave)
        //{
        //    _context.Leaves.Add(leave);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetLeave", new { id = leave.LeaveId }, leave);
        //}






        // DELETE: api/Logins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Login>> DeleteLogin(int id)
        {
            var login = await _context.Logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            _context.Logins.Remove(login);
            await _context.SaveChangesAsync();

            return login;
        }

        private bool LoginExists(int id)
        {
            return _context.Logins.Any(e => e.UserId == id);
        }
    }
}
