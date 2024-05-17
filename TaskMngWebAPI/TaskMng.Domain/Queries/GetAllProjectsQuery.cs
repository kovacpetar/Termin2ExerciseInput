using MediatR;
using TaskMng.Domain.Models;

namespace TaskMng.Domain.Queries
{
    public record GetAllProjectsQuery : IRequest<List<Project>>; 
    
}
