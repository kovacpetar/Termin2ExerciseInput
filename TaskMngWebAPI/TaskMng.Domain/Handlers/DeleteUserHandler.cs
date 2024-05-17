using MediatR;
using TaskMng.Domain.Commands;
using TaskMng.Domain.Interfaces;

namespace TaskMng.Domain.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = await _userRepository.GetUser(request.Id);

            if (userEntity is null)
                throw new Exception($"User with Id: {request.Id} was not found in database.");

            await _userRepository.DeleteUser(userEntity);

            return Unit.Value;
        }
    }
}
