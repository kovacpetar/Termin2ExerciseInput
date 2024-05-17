using Microsoft.EntityFrameworkCore;
using TaskMng.Domain.Interfaces;
using TaskMng.Domain.Models;

namespace TaskMng.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagerDbContext _dbContext;

        public UserRepository(
            TaskManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> AddUser(User user)
        {
            _dbContext.Users.Add(user);

            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _dbContext.Update(user);

            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async System.Threading.Tasks.Task DeleteUser(User user)
        {
            _dbContext.Remove(user);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}