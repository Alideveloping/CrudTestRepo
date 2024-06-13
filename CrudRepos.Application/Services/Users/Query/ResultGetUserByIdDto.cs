using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudRepos.Application.Services.Users.Query
{
    public class ResultGetUserByIdDto
    {
        public UserDto User { get; set; }

    }
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int NationalCode { get; set; }
        public string Email { get; set; }
    }
}
