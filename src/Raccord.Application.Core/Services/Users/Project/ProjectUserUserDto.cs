using Raccord.Application.Core.Services.Users;
using Raccord.Application.Core.Services.Users.ProjectRoles;

namespace Raccord.Application.Core.Services.Users.Project
{
    public class ProjectUserUserDto
    {
        private UserSummaryDto _user;
        private ProjectRoleDto _role;
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
        public ProjectRoleDto ProjectRole
        {
            get
            {
                return _role ?? new ProjectRoleDto();
            }
            set
            {
                _role = value;
            }
        }
    }
}