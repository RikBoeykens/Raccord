using System.Collections.Generic;
using Raccord.API.ViewModels.Images;
using Raccord.API.ViewModels.Users.Invitations.Project;
using Raccord.API.ViewModels.Users.Projects;

namespace Raccord.API.ViewModels.Projects
{
    // Viewmodel to represent a full project
    public class AdminFullProjectViewModel : FullProjectViewModel
    {
        private IEnumerable<ProjectUserUserViewModel> _users;
        private IEnumerable<ProjectUserInvitationUserInvitationViewModel> _invitations;

        public IEnumerable<ProjectUserUserViewModel> Users
        {
            get
            {
                return _users ?? new List<ProjectUserUserViewModel>();
            }
            set
            {
                _users = value;
            }
        }
        public IEnumerable<ProjectUserInvitationUserInvitationViewModel> Invitations
        {
            get
            {
                return _invitations ?? new List<ProjectUserInvitationUserInvitationViewModel>();
            }
            set
            {
                _invitations = value;
            }
        }
    }
}