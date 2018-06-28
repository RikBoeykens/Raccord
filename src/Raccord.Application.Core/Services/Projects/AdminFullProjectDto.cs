using System.Collections.Generic;
using Raccord.Application.Core.Services.Images;
using Raccord.Application.Core.Services.Users.Invitations.Project;
using Raccord.Application.Core.Services.Users.Project;

namespace Raccord.Application.Core.Services.Projects
{
    // Dto to represent a full project
    public class AdminFullProjectDto : FullProjectDto
    {
        private IEnumerable<ProjectUserUserDto> _users;
        private IEnumerable<ProjectUserInvitationUserInvitationDto> _invitations;

        public IEnumerable<ProjectUserUserDto> Users
        {
            get
            {
                return _users ?? new List<ProjectUserUserDto>();
            }
            set
            {
                _users = value;
            }
        }
        public IEnumerable<ProjectUserInvitationUserInvitationDto> Invitations
        {
            get
            {
                return _invitations ?? new List<ProjectUserInvitationUserInvitationDto>();
            }
            set
            {
                _invitations = value;
            }
        }
    }
}