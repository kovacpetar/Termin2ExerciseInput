using MediatR;
using TaskMng.Domain.Commands;
using TaskMng.Domain.Interfaces;

namespace TaskMng.Domain.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, Unit>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskHandler(
            ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var taskEntity = await _taskRepository.GetTask(request.Id);

            if (taskEntity is null)
                throw new Exception($"Task with Id: {request.Id} was not found in database.");

            await _taskRepository.DeleteTask(taskEntity);

            return Unit.Value;
        }
    }
}
