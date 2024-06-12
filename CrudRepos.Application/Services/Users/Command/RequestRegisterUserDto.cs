namespace CrudRepos.Application.Services.Users.Command
{
    public class RequestRegisterUserDto
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int NationalCode { get; set; }
    }
}
