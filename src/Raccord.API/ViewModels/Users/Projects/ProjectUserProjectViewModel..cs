using Raccord.API.ViewModels.Projects;

namespace Raccord.API.ViewModels.Users.Projects
{
    // vm to represent a crew user
    public class ProjectUserProjectViewModel
    {
        private ProjectViewModel _project;

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
    }
}