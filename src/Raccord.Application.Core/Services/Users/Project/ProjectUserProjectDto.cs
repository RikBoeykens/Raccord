using Raccord.Application.Core.Services.Projects;

namespace Raccord.Application.Core.Services.Users.Project
{
    public class ProjectUserProjectDto
    {
        private ProjectDto _project;
        // ID of the crew user
        public long ID { get; set; }

        // Linked user
        public ProjectDto Project
        {
            get
            {
                return _project ?? (_project = new ProjectDto());
            }
            set
            {
                _project = value;
            }
        }
    }
}