using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Model;

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly Context _context;
        
        public UserController(Context context) {
            _context = context;
        }

        // GET api/user/getall
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        // GET api/user/getuser/5
        [HttpGet("{id}", Name ="GetUser")]
        public IActionResult GetById(string id)
        {
            var users = _context.Users.FirstOrDefault(t => t.Id == id);
            if (users == null) {
                return NotFound();
            }
            return new ObjectResult(users);
        }

        //Put api/user/updateuser/5
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] User user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest();
            }

            var tempUser = _context.Users.FirstOrDefault(t => t.Id == id);
            if (tempUser == null)
            {
                return NotFound();
            }

            tempUser.Id = user.Id;
            tempUser.Name = user.Name;
            tempUser.Email = user.Email;
            tempUser.LastPosition = user.LastPosition;
            tempUser.LastPositionTime = user.LastPositionTime;
            tempUser.Ghostmode = user.Ghostmode;
            tempUser.AppToken = user.AppToken;

            _context.Users.Update(tempUser);
            _context.SaveChanges();
            return new NoContentResult();
        }



        //Post api/user/createuser
        [HttpPost]
        public IActionResult Create ([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if(user.LastPositionTime > DateTime.Now)
            {
                user.LastPositionTime = DateTime.Now;
            }
            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }
    }
}
