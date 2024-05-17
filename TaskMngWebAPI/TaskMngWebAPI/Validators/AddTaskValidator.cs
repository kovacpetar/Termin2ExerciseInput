using FluentValidation;
using TaskMng.Domain.Models;
using TaskMngWebAPI.Models;

namespace TaskMngWebAPI.Validators
{
    public class AddTaskValidator : AbstractValidator<AddTaskRequest>
    {
        public AddTaskValidator()
        {
        }
    }
}
