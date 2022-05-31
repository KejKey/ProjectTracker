using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Api.Data;
using ProjectTracker.Api.Entities;


namespace ProjectTracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController: ControllerBase
    {
        private TrackerDbContext _context;

        public ProjectsController(TrackerDbContext context) => _context = context;

        [HttpPost("AddProject")]
        public IActionResult AddProject(Project model)
        {
            _context.Projects.Add(model);
            _context.SaveChanges();


            return Ok("Project added");

        }

        [HttpGet]
        public IEnumerable<Project> GetAll()
        {
            return _context.Projects.Where(model => model.isDeleted == false);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model = _context.Projects.Find(id);
            if (model == null || model.isDeleted == true) throw new KeyNotFoundException("Project not found!");

            
            return Ok(model);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Projects.FindAsync(id);
            if (model == null) throw new KeyNotFoundException("Project not found!");

            model.isDeleted = true;
            _context.Projects.Update(model);
            _context.SaveChanges();


            return Ok(model);
        }

    }
}
