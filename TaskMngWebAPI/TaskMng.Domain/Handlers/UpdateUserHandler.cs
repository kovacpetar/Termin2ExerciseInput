using MediatR;
using TaskMng.Domain.Commands;
using TaskMng.Domain.Interfaces;
using TaskMng.Domain.Models;

namespace TaskMng.Domain.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = await _userRepository.GetUser(request.Id);

            if (userEntity is null)
                throw new Exception($"User with Id: {request.Id} was not found in database.");

            userEntity.UserName = request.UserName;
            userEntity.Password = request.Password;

            return await _userRepository.UpdateUser(userEntity);
        }
    }
}
