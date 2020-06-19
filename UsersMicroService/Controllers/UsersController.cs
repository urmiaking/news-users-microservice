using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersMicroService.Data;
using UsersMicroService.Models;

namespace UsersMicroService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersMicroServiceContext _context;

        public UsersController(UsersMicroServiceContext context)
        {
            _context = context;
        }

        // GET: api/Users/GetUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/GetUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // GET: api/Users/GetUsersByEmail/{email}
        [HttpGet("{email}")]
        public async Task<ActionResult<User>> GetUsersByEmail(string email)
        {
            var users = await _context.Users.FirstOrDefaultAsync(a => a.Email.Equals(email));

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // GET: api/Users/GetUsersByActivationCode/{activationCode}
        [HttpGet("{activationCode}")]
        public async Task<ActionResult<User>> GetUsersByActivationCode(string activationCode)
        {
            var users = await _context.Users.FirstOrDefaultAsync(a => a.ActivationCode.Equals(activationCode));

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }
        
        // GET: api/Users/GetUsersByActivationCode/{activationCode}
        [HttpGet("{resetPasswordCode}")]
        public async Task<ActionResult<User>> GetUsersByResetPasswordCode(string resetPasswordCode)
        {
            var users = await _context.Users.FirstOrDefaultAsync(a => a.ResetPasswordCode.Equals(resetPasswordCode));

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, User users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUsers(User users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.Id }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return users;
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
