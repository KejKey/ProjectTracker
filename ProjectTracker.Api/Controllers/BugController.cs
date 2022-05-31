using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Api.Data;
using ProjectTracker.Api.Entities;


namespace ProjectTracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BugController : ControllerBase
    {
        private TrackerDbContext _context;

        public BugController(TrackerDbContext context) => _context = context;

        [HttpPost("AddBug")]
        public IActionResult AddBacklog(Bug model)
        {
            _context.Bugs.Add(model);
            _context.SaveChanges();


            return Ok("Bug added");

        }

        [HttpGet]
        public IEnumerable<Bug> GetAll()
        {
            return _context.Bugs;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model = _context.Bugs.Find(id);
            if (model == null) throw new KeyNotFoundException("Bugs not found!");


            return Ok(model);

        }

        [HttpPut("{id}")]
        public IActionResult SetState(int id, string state)
        {
            var model = _context.Bugs.Find(id);
            if (model == null) throw new KeyNotFoundException("Bug not found!");

            model.State = state;

            _context.Bugs.Update(model);
            _context.SaveChanges();


            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Bugs.FindAsync(id);
            if (model == null) throw new KeyNotFoundException("Bug not found!");

            _context.Bugs.Remove(model);
            _context.SaveChanges();


            return Ok(model);
        }

    }
}


