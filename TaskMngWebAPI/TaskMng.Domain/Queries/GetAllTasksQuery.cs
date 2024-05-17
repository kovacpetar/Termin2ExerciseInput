using MediatR;
using TaskMng.Domain.Models;

namespace TaskMng.Domain.Queries
{
    public record GetAllTasksQuery : IRequest<List<ToDoTask>>; 
}
