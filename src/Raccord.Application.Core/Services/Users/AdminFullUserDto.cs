using System.Collections.Generic;
using Raccord.Application.Core.Services.Users.Project;

namespace Raccord.Application.Core.Services.Users
{
    // Dto to represent a full user
    public class AdminFullUserDto : FullUserDto
    {
        private IEnumerable<ProjectUserProjectDto> _projects;

        public IEnumerable<ProjectUserProjectDto> Projects
        {
            get
            {
                return _projects ?? new List<ProjectUserProjectDto>();
            }
            set
            {
                _projects = value;
            }
        }
    }
}