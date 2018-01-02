using System.Collections.Generic;
using Raccord.Application.Core.Services.Crew.CrewMembers;
using Raccord.Application.Core.Services.Projects;
using Raccord.Application.Core.Services.Users;

namespace Raccord.Application.Core.Services.Users.Project
{
    public class FullProjectUserDto
    {
        private UserDto _user;
        private ProjectDto _project;
        private IEnumerable<CrewMemberDto> _crewMembers;
        // ID of the project user
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

        /// <summary>
        /// Crew members linked to the project user
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CrewMemberDto> CrewMembers
        {
            get
            {
                return _crewMembers ?? (_crewMembers = new List<CrewMemberDto>());
            }
            set
            {
                _crewMembers = value;
            }
        }
    }
}