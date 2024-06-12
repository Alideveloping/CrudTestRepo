using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CrudRepos.Application.Services.Users.Query
{
    public interface IGetUsersService
    {
        ResultGetUsersDto Execute();
    }
}
