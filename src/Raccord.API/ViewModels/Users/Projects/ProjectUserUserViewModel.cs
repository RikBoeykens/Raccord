using Raccord.API.ViewModels.Users;

namespace Raccord.API.ViewModels.Users.Projects
{
    // vm to represent a crew user
    public class ProjectUserUserViewModel
    {
        private UserSummaryViewModel _user;

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
    }
}