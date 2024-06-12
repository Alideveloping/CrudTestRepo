using CrudRepos.Common.Common;
using CrudRepos.Domain.Entities.Users;
using CrudRepos.Persistance.Context;
using FluentValidation;

namespace CrudRepos.Application.Services.Users.Command
{
    public partial class EditUserService : IEditUserService
    {
        private readonly DatabaseContext _db;
        private readonly IValidator<RequestRegisterUserDto> _validator;
        public EditUserService(DatabaseContext db, IValidator<RequestRegisterUserDto> validator)
        {
            _db = db;
            _validator = validator;
        }

        public ResultDto Execute(RequestEditUserDto request)
        {
            var validationResult = _validator.Validate(new RequestRegisterUserDto
            {
                UserId = request.UserId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Age = request.Age,
                NationalCode = request.NationalCode
            });

            if (!validationResult.IsValid)
            {
                var firstError = validationResult.Errors.First();
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = firstError.ErrorMessage
                };
            }

            var user = _db.Users.Find(request.UserId);
            if (user == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Age = request.Age;
            user.NationalCode = request.NationalCode;
            user.UpdateTime = DateTime.Now;
            _db.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت ویرایش شد"
            };
        }
    }
}
