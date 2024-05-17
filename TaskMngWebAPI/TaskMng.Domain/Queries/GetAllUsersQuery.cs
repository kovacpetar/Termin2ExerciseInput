using TaskMng.Domain.Models;
using MediatR;

namespace TaskMng.Domain.Queries
{
    public record GetAllUsersQuery : IRequest<List<User>>;
}
