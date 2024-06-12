using CrudRepos.Application.Services.Users.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrudRepos.Application.Vaidators
{
    public class RequestRegisterUserDtoValidator : AbstractValidator<RequestRegisterUserDto>
    {
        public RequestRegisterUserDtoValidator()
        {
            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("لطفا نام را وارد کنید")
                .MinimumLength(3).WithMessage("نام نمی تواند کمتر از 3 کاراکتر باشد")
                .Matches(@"^[^0-9]*$").WithMessage("نام نمی تواند شامل اعداد باشد");

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("لطفا نام خانوادگی را وارد کنید")
                .MinimumLength(3).WithMessage("نام خانوادگی نمی تواند کمتر از 3 کاراکتر باشد")
                .Matches(@"^[^0-9]*$").WithMessage("نام خانوادگی نمی تواند شامل اعداد باشد");

            RuleFor(user => user.Age)
                .InclusiveBetween(12, 48).WithMessage("سن باید بین 12 و 48 باشد");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("لطفا ایمیل را وارد کنید")
                .Matches(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$", RegexOptions.IgnoreCase)
                .WithMessage("ایمیل خود را به درستی وارد نمایید");
        }
    }
}
