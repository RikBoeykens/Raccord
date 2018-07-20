using Raccord.API.ViewModels.Cast;

namespace Raccord.API.ViewModels.Users.Invitations.Project
{
    // vm to represent a crew user
    public class AdminFullProjectUserInvitationViewModel : FullProjectUserInvitationViewModel
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