using FluentValidation;
using TaskMngWebAPI.Models;

namespace TaskMngWebAPI.Validators
{
    public class AddUserValidator : AbstractValidator<AddUserRequest>
    {
        
        public AddUserValidator()
        {
        }
    }
}
