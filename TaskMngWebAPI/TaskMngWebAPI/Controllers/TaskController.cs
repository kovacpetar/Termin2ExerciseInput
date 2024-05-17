using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskMng.Domain.Commands;
using TaskMng.Domain.Models;
using TaskMng.Domain.Queries;
using TaskMngWebAPI.Models;

namespace TaskMngWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoTask>>> GetAllTasks()
        {
            var query = new GetAllTasksQuery();
            var task = await _mediator.Send(query);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoTask>> AddTask(AddTaskRequest addTaskRequest)
        {
            var addTaskCommand = new AddTaskCommand
            {
            };

            var task = await _mediator.Send(addTaskCommand);
            return CreatedAtAction(nameof(GetAllTasks), new { id = task.Id }, task);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ToDoTask>> UpdateTask([FromRoute] int id, UpdateTaskRequest updateTaskRequest)
        {
            var updateCommand = new UpdateTaskCommand
            {
            };

            var task = await _mediator.Send(updateCommand);

            if (task is null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            var command = new DeleteTaskCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
