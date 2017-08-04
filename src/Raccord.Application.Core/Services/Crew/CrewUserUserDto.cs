using Raccord.Application.Core.Services.Users;

namespace Raccord.Application.Core.Services.Crew
{
    public class CrewUserUserDto
    {
        private UserDto _user;
        // ID of the crew user
        public long ID { get; set; }

        // Linked user
        public UserDto User
        {
            get
            {
                return _user ?? (_user = new UserDto());
            }
            set
            {
                _user = value;
            }
        }
    }
}