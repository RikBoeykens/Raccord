using Raccord.Application.Core.Services.Users;

namespace Raccord.Application.Core.Services.Users.Project
{
    public class ProjectUserUserDto
    {
        private UserSummaryDto _user;
        // ID of the crew user
        public long ID { get; set; }

        // Linked user
        public UserSummaryDto User
        {
            get
            {
                return _user ?? (_user = new UserSummaryDto());
            }
            set
            {
                _user = value;
            }
        }
    }
}