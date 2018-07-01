using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Users.ProjectRoles;

namespace Raccord.API.ViewModels.Users.Projects
{
    // vm to represent a crew user
    public class ProjectUserProjectViewModel
    {
        private ProjectSummaryViewModel _project;
        private ProjectRoleViewModel _role;

        // ID of the crew user
        public long ID { get; set; }

        // Linked project
        public ProjectSummaryViewModel Project
        {
            get
            {
                return _project ?? (_project = new ProjectSummaryViewModel());
            }
            set
            {
                _project = value;
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