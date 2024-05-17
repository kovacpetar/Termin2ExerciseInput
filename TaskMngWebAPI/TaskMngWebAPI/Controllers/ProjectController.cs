using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskMng.Domain.Commands;
using TaskMng.Domain.Models;
using TaskMng.Domain.Queries;
using TaskMngWebAPI.Models;
namespace TaskMngWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController (IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetAllProjects()
        {
            var query = new GetAllProjectsQuery();
            var project = await _mediator.Send(query);
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> AddProject(AddProjectRequest addProjectRequest)
        {
            var addProjectCommand = new AddProjectCommand
            {
            };

            var project = await _mediator.Send(addProjectCommand);
            return CreatedAtAction(nameof(GetAllProjects), new { id = project.Id }, project);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Project>> UpdateProject([FromRoute] int id, UpdateProjectRequest updateProjectRequest)
        {
            var updateCommand = new UpdateProjectCommand
            {
            };

            var project = await _mediator.Send(updateCommand);

            if (project is null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            var command = new DeleteProjectCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
