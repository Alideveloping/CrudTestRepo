using CrudRepos.Persistance.Context;
namespace CrudRepos.Application.Services.Users.Query
{
    public class GetUsersService : IGetUsersService
    {
        private readonly DatabaseContext _db;
        public GetUsersService(DatabaseContext db)
        {
            _db = db;
        }
        public ResultGetUsersDto Execute()
        {
            var users = _db.Users.ToList();
            var userlist = users.Select(p => new GetUsersDto()
            {
                Id = p.Id,
                Email = p.Email,
                FirstName = p.FirstName,
                LastName = p.LastName,
                NationalCode = p.NationalCode,
                Age = p.Age,
            }).ToList();

            return new ResultGetUsersDto
            {
                Users = userlist,
            };
        }
    }
}
