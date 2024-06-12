using CrudRepos.Application.Vaidators;
using CrudRepos.Common.Common;
using CrudRepos.Domain.Entities.Users;
using CrudRepos.Persistance.Context;
using FluentValidation;

namespace CrudRepos.Application.Services.Users.Command
{
    public partial class AddNewUserService : IRegisterUserService
    {
        private readonly DatabaseContext _db;

        private readonly IValidator<RequestRegisterUserDto> _validator;

        public AddNewUserService(DatabaseContext db, IValidator<RequestRegisterUserDto> validator)
        {
            _db = db;
            _validator = validator;
        }

        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            var validator = new RequestRegisterUserDtoValidator();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                var firstError = validationResult.Errors.First();
                return new ResultDto<ResultRegisterUserDto>
                {
                    Data = new ResultRegisterUserDto { UserId = 0 },
                    IsSuccess = false,
                    Message = firstError.ErrorMessage
                };
            }

            User user = new User()
            {
                Id = request.UserId,
                Age = request.Age,
                NationalCode = request.NationalCode,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                InsertTime = DateTime.Now,
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            return new ResultDto<ResultRegisterUserDto>
            {
                Data = new ResultRegisterUserDto { UserId = user.Id },
                IsSuccess = true,
                Message = "کاربر با موفقیت ثبت شد"
            };
        }

    }
}
