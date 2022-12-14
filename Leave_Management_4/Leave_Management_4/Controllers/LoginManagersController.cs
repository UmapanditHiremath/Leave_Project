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
    public class LoginManagersController : ControllerBase
    {
        private readonly UmapanditDbContext _context;

        public LoginManagersController(UmapanditDbContext context)
        {
            _context = context;
        }

        // GET: api/LoginManagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginManager>>> GetLoginManagers()
        {
            return await _context.LoginManagers.ToListAsync();
        }

        // GET: api/LoginManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginManager>> GetLoginManager(int id)
        {
            var loginManager = await _context.LoginManagers.FindAsync(id);

            if (loginManager == null)
            {
                return NotFound();
            }

            return loginManager;
        }

        // PUT: api/LoginManagers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginManager(int id, LoginManager loginManager)
        {
            if (id != loginManager.ID)
            {
                return BadRequest();
            }

            _context.Entry(loginManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginManagerExists(id))
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

        // POST: api/LoginManagers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public string PostLogin(LoginManager login1)
        {
            if (login1 is null)
            {
                throw new ArgumentNullException(nameof(login1));
            }



            LoginManager login = _context.LoginManagers.
                 Where(log => log.UserName == login1.UserName && log.Password == login1.Password)
                .FirstOrDefault();




            if (login == null)
            {
                return "Invalid credentials";
            }



            return "Login Success";
        }


        // DELETE: api/LoginManagers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoginManager>> DeleteLoginManager(int id)
        {
            var loginManager = await _context.LoginManagers.FindAsync(id);
            if (loginManager == null)
            {
                return NotFound();
            }

            _context.LoginManagers.Remove(loginManager);
            await _context.SaveChangesAsync();

            return loginManager;
        }

        private bool LoginManagerExists(int id)
        {
            return _context.LoginManagers.Any(e => e.ID == id);
        }
    }
}
