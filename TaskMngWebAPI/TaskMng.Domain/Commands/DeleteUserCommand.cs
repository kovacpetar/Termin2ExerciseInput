using MediatR;

namespace TaskMng.Domain.Commands
{
    public record DeleteUserCommand : IRequest<Unit>
    {
    }
}
