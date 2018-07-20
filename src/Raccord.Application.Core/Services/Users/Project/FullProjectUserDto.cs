using System.Collections.Generic;
using Raccord.Application.Core.Services.Cast;
using Raccord.Application.Core.Services.Crew.CrewMembers;
using Raccord.Application.Core.Services.Crew.CrewUnits;
using Raccord.Application.Core.Services.Projects;
using Raccord.Application.Core.Services.Users;
using Raccord.Application.Core.Services.Users.ProjectRoles;

namespace Raccord.Application.Core.Services.Users.Project
{
    public class FullProjectUserDto
    {
        private UserDto _user;
        private ProjectDto _project;
        protected CastMemberDto _castMember;
        private ProjectRoleDto _role;
        private IEnumerable<ProjectLinkCrewUnitDto> _crewUnits;
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
        /// Cast Member linked to the project user
        /// </summary>
        /// <returns></returns>
        public CastMemberDto CastMember
        {
            get
            {
                return _castMember ?? (_castMember = new CastMemberDto());
            }
            set
            {
                _castMember = value;
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

        /// <summary>
        /// Crew Units of the user
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectLinkCrewUnitDto> CrewUnits
        {
            get
            {
                return _crewUnits ?? new List<ProjectLinkCrewUnitDto>();
            }
            set
            {
                _crewUnits = value;
            }
        }
    }
}