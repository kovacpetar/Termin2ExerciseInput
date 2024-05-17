using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMng.Domain.Interfaces;
using TaskMng.Domain.Models;

namespace TaskMng.Infrastructure.Repositories
{
    public class ToDoTaskRepository : ITaskRepository
    {
        private readonly TaskManagerDbContext _dbContext;

        public ToDoTaskRepository(
            TaskManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ToDoTask>> GetAllTasks()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<ToDoTask> AddTask(ToDoTask task)
        {
            _dbContext.Tasks.Add(task);

            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<ToDoTask> UpdateTask(ToDoTask task)
        {
            _dbContext.Update(task);

            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async System.Threading.Tasks.Task DeleteTask(ToDoTask task)
        {
            _dbContext.Remove(task);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ToDoTask> GetTask(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
