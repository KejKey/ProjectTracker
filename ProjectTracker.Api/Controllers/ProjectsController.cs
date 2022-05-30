using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Api.Data;
using ProjectTracker.Api.Entities;


namespace ProjectTracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController: ControllerBase
    {
        private ProjectTrackerDbContext _context;

        public ProjectsController(ProjectTrackerDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddProject")]
        public IActionResult AddProject(Project model)
        {
            _context.Projects.Add(model);
            _context.SaveChanges();

            return Ok("Project added");

        }

    }
}
