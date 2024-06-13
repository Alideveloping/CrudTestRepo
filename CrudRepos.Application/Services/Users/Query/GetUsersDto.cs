namespace CrudRepos.Application.Services.Users.Query
{
    public class GetUsersDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int NationalCode { get; set; }
    }
}
