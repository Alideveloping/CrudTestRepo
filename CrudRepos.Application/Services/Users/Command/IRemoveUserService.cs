using CrudRepos.Common.Common;
using CrudRepos.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudRepos.Application.Services.Users.Command
{
    public interface IRemoveUserService
    {
        ResultDto Execute(long UserId);
    }
    public class RemoveUserService : IRemoveUserService
    {
        private readonly DatabaseContext _db;
        public RemoveUserService(DatabaseContext db)
        {
            _db = db;
        }

        public ResultDto Execute(long UserId)
        {
            var user = _db.Users.Find(UserId);
            if (user == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد",
                };
            }

            user.RemoveTime = DateTime.Now;
            user.IsRemoved = true;
            _db.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت حذف شد"
            };

        }
    }
}
