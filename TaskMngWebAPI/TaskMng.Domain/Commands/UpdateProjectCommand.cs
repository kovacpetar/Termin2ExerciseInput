using MediatR;
using TaskMng.Domain.Models;

namespace TaskMng.Domain.Commands
{
    public record UpdateProjectCommand : IRequest<Project>
    {
    }
}
