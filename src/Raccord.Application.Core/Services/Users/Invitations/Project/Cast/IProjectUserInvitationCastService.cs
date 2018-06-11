namespace Raccord.Application.Core.Services.Users.Invitations.Project.Cast
{
    // Interface for project user invitation cast functionality
    public interface IProjectUserInvitationCastService
    {
      void Link(long projectUserInvitationID, long castMemberId);
      void RemoveLink(long projectUserInvitationID, long castMemberId);
    }
}