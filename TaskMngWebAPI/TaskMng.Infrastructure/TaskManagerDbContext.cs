using TaskMng.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TaskMng.Infrastructure
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}