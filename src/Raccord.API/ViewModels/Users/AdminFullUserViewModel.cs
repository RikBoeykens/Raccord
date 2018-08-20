using System.Collections.Generic;
using Raccord.API.ViewModels.Users.Projects;

namespace Raccord.API.ViewModels.Users
{
    // Viewmodel to represent a user
    public class AdminFullUserViewModel : FullUserViewModel
    {
        private IEnumerable<ProjectUserProjectViewModel> _projects;

        public IEnumerable<ProjectUserProjectViewModel> Projects
        {
            get
            {
                return _projects ?? new List<ProjectUserProjectViewModel>();
            }
            set
            {
                _projects = value;
            }
        }
    }
}