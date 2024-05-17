using MediatR;
using TaskMng.Domain.Commands;
using TaskMng.Domain.Interfaces;
using TaskMng.Domain.Models;

namespace TaskMng.Domain.Handlers
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, Project>
    {
        private readonly IProjectRepository _projectRepository;

        public UpdateProjectHandler(
            IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var projectEntity = await _projectRepository.GetProject(request.Id);

            if (projectEntity is null)
                throw new Exception($"Project with Id: {request.Id} was not found in database.");

            projectEntity.Name = request.Name;
            projectEntity.Description = request.Description;

            return await _projectRepository.UpdateProject(projectEntity);
        }
    }
}
