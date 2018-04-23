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
            var user = _context.Users.FirstOrDefault(t => t.Id == id);
            if (user == null) {
                return NotFound();
            }
            return new ObjectResult(user);
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

        //Put api/user/updateuser/5
        [HttpPut("{id}")]
        public IActionResult UpdatePosition(string id, [FromBody] User user)
        {

            var tempUser = _context.Users.FirstOrDefault(t => t.Id == id);
            if (tempUser == null)
            {
                return NotFound();
            }
            tempUser.LastPosition = user.LastPosition;
            tempUser.LastPositionTime = user.LastPositionTime;

            _context.Users.Update(tempUser);
            _context.SaveChanges();
            return new NoContentResult();
        }

        //Get api/user/track/id
        [HttpGet("{id}")]
        public IActionResult Track(string id) {
            var user = _context.Users.FirstOrDefault(t => t.Id == id);
            if (user == null) {
                return NotFound();
            }
            //Call faceApi with id
            //user.LastPosition = ; //get with faceapi
            //user.LastPositionTime = DateTime.Now;

            //_context.Users.Update(user);
            //_context.SaveChanges();

            User tempUser = new User("tempId", "tempName", "tempEmail@mail.com", 1, DateTime.Now, false, "tempToken");
            return new ObjectResult(tempUser);
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
