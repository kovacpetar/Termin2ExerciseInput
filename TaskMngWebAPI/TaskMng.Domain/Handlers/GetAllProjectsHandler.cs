using MediatR;
using TaskMng.Domain.Interfaces;
using TaskMng.Domain.Models;
using TaskMng.Domain.Queries;

namespace TaskMng.Domain.Handlers
{
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, List<Project>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsHandler(
            IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<Project>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            return await _projectRepository.GetAllProjects();
        }
    }
}
