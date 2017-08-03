using Raccord.Application.Core.Services.Projects;
using Raccord.Application.Core.Services.Users;

namespace Raccord.Application.Core.Services.Crew
{
    public class FullCrewUserDto
    {
        private UserDto _user;
        private ProjectDto _project;
        // ID of the crew user
        public long ID { get; set; }

        // Linked project
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

        // Linked user
        public UserDto User
        {
            get
            {
                return _user ?? (_user = new UserDto());
            }
            set
            {
                _user = value;
            }
        }
    }
}