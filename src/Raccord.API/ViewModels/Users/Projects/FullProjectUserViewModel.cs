using System.Collections.Generic;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Crew.CrewMembers;
using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Users;
using Raccord.API.ViewModels.Users.ProjectRoles;
using Raccord.API.ViewModels.Cast;

namespace Raccord.API.ViewModels.Users.Projects
{
    // vm to represent a crew user
    public class FullProjectUserViewModel
    {
        private ProjectViewModel _project;
        private UserViewModel _user;
        private IEnumerable<CrewMemberViewModel> _crewMembers;
        private CastMemberViewModel _castMember;
        private ProjectRoleViewModel _projectRole;

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
        public IEnumerable<CrewMemberViewModel> CrewMembers
        {
            get
            {
                return _crewMembers ?? (_crewMembers = new List<CrewMemberViewModel>());
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
    }
}