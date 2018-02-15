using System.Collections.Generic;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.Crew.CrewMembers;
using Raccord.Application.Core.Services.Projects;
using Raccord.Application.Core.Services.Users;
using Raccord.Application.Core.Services.Users.ProjectRoles;

namespace Raccord.Application.Core.Services.Users.Project
{
    public class FullProjectUserDto
    {
        private UserDto _user;
        private ProjectDto _project;
        private IEnumerable<CrewMemberDto> _crewMembers;
        private IEnumerable<CharacterDto> _characters;
        private ProjectRoleDto _role;
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

        /// <summary>
        /// Crew members linked to the project user
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CharacterDto> Characters
        {
            get
            {
                return _characters ?? (_characters = new List<CharacterDto>());
            }
            set
            {
                _characters = value;
            }
        }

        /// <summary>
        /// Project role of the user
        /// </summary>
        /// <returns></returns>
        public ProjectRoleDto ProjectRole
        {
            get
            {
                return _role ?? (_role = new ProjectRoleDto());
            }
            set
            {
                _role = value;
            }
        }
    }
}