using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Users;

namespace Raccord.API.ViewModels.Users.Projects
{
    // vm to represent a crew user
    public class FullProjectUserViewModel
    {
        private ProjectViewModel _project;
        private UserViewModel _user;

        // ID of the crew user
        public long ID { get; set; }

        // Linked project
        public ProjectViewModel Project
        {
            get
            {
                return _project ?? (_project = new ProjectViewModel());
            }
            set
            {
                _project = value;
            }
        }

        // Linked user
        public UserViewModel User
        {
            get
            {
                return _user ?? (_user = new UserViewModel());
            }
            set
            {
                _user = value;
            }
        }
    }
}