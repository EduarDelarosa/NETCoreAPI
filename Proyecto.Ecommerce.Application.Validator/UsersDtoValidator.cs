using FluentValidation;
using Proyecto.Ecommerce.Application.DTO;

namespace Proyecto.Ecommerce.Application.Validator
{
    public class UsersDtoValidator : AbstractValidator<UsersDTO>
    {
        public UsersDtoValidator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }
}