using eCommerce.Core.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators
{
    public class LoginValidator: AbstractValidator<LoginDto>
    {

        public LoginValidator()
        {
            RuleFor(x=> x.Email).NotEmpty().EmailAddress().WithMessage("Email Required");
            RuleFor(x=> x.Password).NotEmpty().WithMessage("Email Required");
        }

    }
}
