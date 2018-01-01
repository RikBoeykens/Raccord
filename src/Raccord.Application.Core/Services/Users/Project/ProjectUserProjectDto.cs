using Raccord.Application.Core.Services.Projects;

namespace Raccord.Application.Core.Services.Users.Project
{
    public class ProjectUserProjectDto
    {
        private ProjectSummaryDto _project;
        // ID of the crew user
        public long ID { get; set; }

        // Linked user
        public ProjectSummaryDto Project
        {
            get
            {
                return _project ?? (_project = new ProjectSummaryDto());
            }
            set
            {
                _project = value;
            }
        }
    }
}