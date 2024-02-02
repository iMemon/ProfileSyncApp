using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfileSync.API.Data;
using ProfileSync.API.Models;

namespace ProfileSync.API.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApiDbContext _context;

        public UsersController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet("UserProfile")]
        public async Task<ActionResult<User>> GetUserProfile(string email)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(c => c.Email == email);
                if (user == null) 
                { 
                    return BadRequest(); 
                }
                else 
                {
                    return Ok(user);
                }
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

        [HttpGet("Login")]
        public async Task<ActionResult<User>> Login(string email, string password)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(c => c.Email == email && c.Password == password);
                if (user == null)
                {
                    return BadRequest("Invalid Credentials");
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

        [HttpGet("Signup")]
        public async Task<ActionResult<User>> Signup(string email, string password, string firstName = "",
            string lastName = "", string address = "", string phone = "")
        {
            try
            {
                var user = await (from u in _context.Users
                                  where u.Email == email
                                  select u).SingleOrDefaultAsync();

                if (user != null)
                {
                    return BadRequest($"User already exists with email: {email}");
                }
                else
                {
                    User item = new User()
                    {
                        Email = email,
                        Password = password,
                        FirstName = firstName,
                        LastName = lastName,
                        Address = address,
                        Phone = phone
                    };
                    var result = await _context.Users.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return Ok(result.Entity);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }
    }
}
