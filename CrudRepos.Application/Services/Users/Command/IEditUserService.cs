using CrudRepos.Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudRepos.Application.Services.Users.Command
{
    public interface IEditUserService
    {
        ResultDto Execute(RequestEditUserDto request);

    }
}
