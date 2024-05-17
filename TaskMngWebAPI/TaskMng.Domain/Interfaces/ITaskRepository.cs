using TaskMng.Domain.Models;

namespace TaskMng.Domain.Interfaces
{
    public interface ITaskRepository
    {
        public Task<List<ToDoTask>> GetAllTasks();

        public Task<ToDoTask> AddTask(ToDoTask task);

        public Task<ToDoTask> UpdateTask(ToDoTask task);

        public Task DeleteTask(ToDoTask task);

        public Task<ToDoTask> GetTask(int id);
    }
}
