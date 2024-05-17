using TaskMng.Domain.Models;

namespace TaskMng.Domain.Interfaces
{
    public interface IProjectRepository
    {
        public Task<List<Project>> GetAllProjects();

        public Task<Project> AddProject(Project project);

        public Task<Project> UpdateProject(Project project);

        public Task DeleteProject(Project project);

        public Task<Project> GetProject(int id);
    }
}
