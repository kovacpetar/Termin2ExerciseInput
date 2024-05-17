using Microsoft.EntityFrameworkCore;
using TaskMng.Domain.Interfaces;
using TaskMng.Domain.Models;

namespace TaskMng.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TaskManagerDbContext _dbContext;

        public ProjectRepository(
            TaskManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Project>> GetAllProjects()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> AddProject(Project project)
        {
            _dbContext.Projects.Add(project);

            await _dbContext.SaveChangesAsync();

            return project;
        }

        public async Task<Project> UpdateProject(Project project)
        {
            _dbContext.Update(project);

            await _dbContext.SaveChangesAsync();

            return project;
        }

        public async System.Threading.Tasks.Task DeleteProject(Project project)
        {
            _dbContext.Remove(project);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Project> GetProject(int id)
        {
            return await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
