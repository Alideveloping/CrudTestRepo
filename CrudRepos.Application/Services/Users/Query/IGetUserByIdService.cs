using CrudRepos.Common.Common;
using CrudRepos.Domain.Entities.Users;
using CrudRepos.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudRepos.Application.Services.Users.Query
{
    public interface IGetUserByIdService
    {
        ResultGetUserByIdDto Execute(int Id);
    }
    public class GetUserByIdService : IGetUserByIdService
    {
        private readonly DatabaseContext _db;
        public GetUserByIdService(DatabaseContext db)
        {
            _db = db;
        }
        public ResultGetUserByIdDto Execute(int Id)
        {
            var user = _db.Users.Find(Id);
            if (user == null)
            {
                return null; 
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                NationalCode = user.NationalCode,
                Email = user.Email
            };

            return new ResultGetUserByIdDto
            {
                User = userDto
            };
        }
    }
}
