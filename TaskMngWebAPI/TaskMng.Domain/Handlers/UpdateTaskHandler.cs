using MediatR;
using Microsoft.VisualBasic;
using TaskMng.Domain.Commands;
using TaskMng.Domain.Interfaces;
using TaskMng.Domain.Models;

namespace TaskMng.Domain.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, ToDoTask>
    {
        private readonly ITaskRepository _taskRepository;

        public UpdateTaskHandler(
            ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<ToDoTask> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskEntity = await _taskRepository.GetTask(request.Id);

            if (taskEntity is null)
                throw new Exception($"Task with Id: {request.Id} was not found in database.");

            taskEntity.Title = request.Title;
            taskEntity.Description = request.Description;
            taskEntity.DueDate = request.DueDate;
            taskEntity.Status = request.Status;
            taskEntity.UserId = request.UserId;
            taskEntity.ProjectId = request.ProjectId;

            return await _taskRepository.UpdateTask(taskEntity);
        }
    }
}
