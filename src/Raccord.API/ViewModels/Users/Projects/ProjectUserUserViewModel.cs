using Raccord.API.ViewModels.Users;
using Raccord.API.ViewModels.Users.ProjectRoles;

namespace Raccord.API.ViewModels.Users.Projects
{
    // vm to represent a crew user
    public class ProjectUserUserViewModel
    {
        private UserSummaryViewModel _user;
        private ProjectRoleViewModel _role;

        // ID of the crew user
        public long ID { get; set; }

        // Linked user
        public UserSummaryViewModel User
        {
            get
            {
                return _user ?? (_user = new UserSummaryViewModel());
            }
            set
            {
                _user = value;
            }
        }
        public ProjectRoleViewModel ProjectRole
        {
            get
            {
                return _role ?? new ProjectRoleViewModel();
            }
            set
            {
                _role = value;
            }
        }
    }
}