namespace CrudRepos.Application.Services.Users.Command
{
    public class RequestEditUserDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int NationalCode { get; set; }
        public int Age { get; set; }
    }
}
