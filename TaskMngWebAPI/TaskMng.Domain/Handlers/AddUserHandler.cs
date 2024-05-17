using MediatR;
using TaskMng.Domain.Commands;
using TaskMng.Domain.Interfaces;
using TaskMng.Domain.Models;
namespace TaskMng.Domain.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public AddUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserName = request.UserName,
                Password = request.Password
            };

            return await _userRepository.AddUser(user);
        }
    }
}
