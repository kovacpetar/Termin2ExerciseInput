using MediatR;
using TaskMng.Domain.Commands;
using TaskMng.Domain.Interfaces;
using TaskMng.Domain.Models;

namespace TaskMng.Domain.Handlers
{
    public class AddTaskHandler : IRequestHandler<AddTaskCommand, ToDoTask>
    {
        private readonly ITaskRepository _taskRepository;

        public AddTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<ToDoTask> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new ToDoTask
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                Status = request.Status,
                UserId = request.UserId,
                ProjectId = request.ProjectId
            };

            return await _taskRepository.AddTask(task);
        }
    }
}
