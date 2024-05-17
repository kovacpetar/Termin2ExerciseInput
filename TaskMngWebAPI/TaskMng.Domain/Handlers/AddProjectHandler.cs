using MediatR;
using TaskMng.Domain.Commands;
using TaskMng.Domain.Interfaces;
using TaskMng.Domain.Models;

namespace TaskMng.Domain.Handlers
{
    public class AddProjectHandler : IRequestHandler<AddProjectCommand, Project>
    {
        private readonly IProjectRepository _projectRepository;

        public AddProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                Name = request.Name,
                Description = request.Description,
                ProjectOwnerId = request.ProjectOwnerId
            };

            return await _projectRepository.AddProject(project);
        }
    }
}
