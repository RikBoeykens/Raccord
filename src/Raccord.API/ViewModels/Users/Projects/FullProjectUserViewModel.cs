using System.Collections.Generic;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Crew.CrewMembers;
using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Users;
using Raccord.API.ViewModels.Users.ProjectRoles;
using Raccord.API.ViewModels.Cast;
using Raccord.API.ViewModels.Crew.CrewUnits;

namespace Raccord.API.ViewModels.Users.Projects
{
    // vm to represent a crew user
    public class FullProjectUserViewModel
    {
        private ProjectViewModel _project;
        private UserViewModel _user;
        protected CastMemberViewModel _castMember;
        private ProjectRoleViewModel _projectRole;
        private IEnumerable<ProjectUserCrewUnitViewModel> _crewUnits;

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

        // Linked user
        public UserViewModel User
        {
            get
            {
                return _user ?? (_user = new UserViewModel());
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
        public CastMemberViewModel CastMember
        {
            get
            {
                return _castMember ?? (_castMember = new CastMemberViewModel());
            }
            set
            {
                _castMember = value;
            }
        }

        // Linked user
        public ProjectRoleViewModel ProjectRole
        {
            get
            {
                return _projectRole ?? (_projectRole = new ProjectRoleViewModel());
            }
            set
            {
                _projectRole = value;
            }
        }
        public IEnumerable<ProjectUserCrewUnitViewModel> CrewUnits
        {
            get
            {
                return _crewUnits ?? new List<ProjectUserCrewUnitViewModel>();
            }
            set
            {
                _crewUnits = value;
            }
        }
    }
}