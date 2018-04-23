using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Model;

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PositionController : Controller
    {
        private readonly Context _context;
        
        public PositionController(Context context) {
            _context = context;
        }

        // GET api/position/getall
        [HttpGet]
        public IEnumerable<Position> GetAll()
        {
            return _context.Positions.ToList();
        }

        // GET api/position/getposition/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pos = _context.Positions.FirstOrDefault(t => t.Id == id);
            if (pos == null) {
                return NotFound();
            }
            return new ObjectResult(pos);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
