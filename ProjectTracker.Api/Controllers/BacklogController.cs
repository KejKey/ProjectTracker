
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Api.Data;
using ProjectTracker.Api.Entities;


namespace ProjectTracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BacklogController : ControllerBase
    {
        private TrackerDbContext _context;

        public BacklogController(TrackerDbContext context) => _context = context;

        [HttpPost("AddBacklog")]
        public IActionResult AddBacklog(Backlog model)
        {
            _context.BacklogItems.Add(model);
            _context.SaveChanges();


            return Ok("BacklogItem added");

        }

        [HttpGet]
        public IEnumerable<Backlog> GetAll()
        {
            return _context.BacklogItems;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model = _context.BacklogItems.Find(id);
            if (model == null) throw new KeyNotFoundException("BacklogItem not found!");


            return Ok(model);

        }

        [HttpPut("{id}")]
        public IActionResult SetState(int id, string state)
        {
            var model = _context.BacklogItems.Find(id);
            if (model == null) throw new KeyNotFoundException("BacklogItem not found!");

            model.State = state;

            _context.BacklogItems.Update(model);
            _context.SaveChanges();


            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.BacklogItems.FindAsync(id);
            if (model == null) throw new KeyNotFoundException("BacklogItem not found!");

            _context.BacklogItems.Remove(model);
            _context.SaveChanges();


            return Ok(model);
        }

    }
}

