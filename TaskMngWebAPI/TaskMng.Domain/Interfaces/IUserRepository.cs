using TaskMng.Domain.Models;

namespace TaskMng.Domain.Interfaces;

public interface IUserRepository
{
    public Task<List<User>> GetAllUsers();

    public Task<User> AddUser(User user);

    public Task<User> UpdateUser(User user);

    public Task DeleteUser(User user);

    public Task<User> GetUser(int id);
}