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
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var user = await _mediator.Send(query);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(AddUserRequest adduserRequest)
        {
            var addUserCommand = new AddUserCommand
            {
            };

            var user = await _mediator.Send(addUserCommand);
            return CreatedAtAction(nameof(GetAllUsers), new { id = user.Id }, user);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<User>> UpdateUser([FromRoute]int id, UpdateUserRequest updateUserRequest)
        {
            var updateCommand = new UpdateUserCommand
            {
            };

            var user = await _mediator.Send(updateCommand);
            
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute]int id)
        {
            var command = new DeleteUserCommand { Id = id };
            
            await _mediator.Send(command);
            
            return NoContent();
        }
    }
}
