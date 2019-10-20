using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaApi.Models;

namespace PruebaTecnicaApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private DataContext db = new DataContext();
        // GET: api/Users

        [HttpGet()]
        public IActionResult Get()
        {
            var users = db.User.ToList();
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(decimal id)
        {
            using (DataContext db = new DataContext())
            {
                var userQ = db.User.Where(u => u.Id == id);
                List<User> users = userQ.ToList();
                return users[0].ToString();
            }
        }
        

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            using (DataContext db = new DataContext())
            {
                db.User.Add(user);
                try {
                    await db.SaveChangesAsync();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }

                return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User user)
        {
            if(id != user.Id)
            {
                return BadRequest();
            }

            using (DataContext db = new DataContext())
            {
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return NoContent();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (DataContext db = new DataContext())
            {
                var userQ = db.User.Where(u => u.Id == id);
                foreach (var user in userQ)
                {
                    db.User.Remove(user);
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
