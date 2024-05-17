using MediatR;
using TaskMng.Domain.Commands;
using TaskMng.Domain.Interfaces;

namespace TaskMng.Domain.Handlers
{
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public DeleteProjectHandler(
            IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var projectEntity = await _projectRepository.GetProject(request.Id);

            if (projectEntity is null)
                throw new Exception($"Project with Id: {request.Id} was not found in database.");

            await _projectRepository.DeleteProject(projectEntity);

            return Unit.Value;
        }
    }
}
