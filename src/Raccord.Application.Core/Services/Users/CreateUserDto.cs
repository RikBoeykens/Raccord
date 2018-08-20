namespace Raccord.Application.Core.Services.Users
{
    // Dto to represent a full user
    public class CreateUserDto : UserDto
    {
        public string Password { get; set; }
        public bool IsDummyUser { get; set; }
    }
}