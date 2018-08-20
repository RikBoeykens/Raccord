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
    public class AdminFullProjectUserViewModel : FullProjectUserViewModel
    {
        private new AdminFullCastMemberViewModel _castMember;

        public new AdminFullCastMemberViewModel CastMember
        {
        get
        {
            return _castMember ?? new AdminFullCastMemberViewModel();
        }
        set
        {
            _castMember = value;
        }
        }
    }
}