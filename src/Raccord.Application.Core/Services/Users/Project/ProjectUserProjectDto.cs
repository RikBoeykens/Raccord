using Raccord.Application.Core.Services.Projects;
using Raccord.Application.Core.Services.Users.ProjectRoles;

namespace Raccord.Application.Core.Services.Users.Project
{
    public class ProjectUserProjectDto
    {
        private ProjectSummaryDto _project;
        private ProjectRoleDto _role;
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