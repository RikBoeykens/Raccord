using System.Linq;
using Raccord.Application.Core.Services.Users.Invitations.Project.Cast;
using Raccord.Data.EntityFramework.Repositories.Cast;
using Raccord.Data.EntityFramework.Repositories.Characters;
using Raccord.Data.EntityFramework.Repositories.Users.Invitations.Projects;

namespace Raccord.Application.Services.Users.Invitations.Project.Cast
{
    // Service for project user invitation cast functionality
    public class ProjectUserInvitationCastService : IProjectUserInvitationCastService
    {
      private readonly ICastMemberRepository _castMemberRepository;
      private readonly IProjectUserInvitationRepository _projectUserInvitationRepository;

      public ProjectUserInvitationCastService(
        ICastMemberRepository castMemberRepository,
        IProjectUserInvitationRepository projectUserInvitationRepository
      ){
        _castMemberRepository = castMemberRepository;
        _projectUserInvitationRepository = projectUserInvitationRepository;
      }

      public void Link(long projectUserInvitationID, long castMemberID)
      {
        var castMember = _castMemberRepository.GetSingle(castMemberID);
        castMember.ProjectUserInvitationID = projectUserInvitationID;

        _castMemberRepository.Edit(castMember);
        _castMemberRepository.Commit();

        var projectUserInvitation = _projectUserInvitationRepository.GetSingle(projectUserInvitationID);
        projectUserInvitation.CastMemberID = castMemberID;

        _projectUserInvitationRepository.Edit(projectUserInvitation);
        _projectUserInvitationRepository.Commit();
      }

      public void RemoveLink(long projectUserInvitationID, long castMemberID)
      {
        var castMember = _castMemberRepository.FindBy(cm=> cm.ID == castMemberID && cm.ProjectUserInvitationID == projectUserInvitationID).FirstOrDefault();
        if(castMember!= null)
        {
          castMember.ProjectUserInvitationID = null;

          _castMemberRepository.Edit(castMember);
          _castMemberRepository.Commit();
        }
        var projectUserInvitation = _projectUserInvitationRepository.FindBy(cm=> cm.ID == projectUserInvitationID && cm.CastMemberID == castMemberID).FirstOrDefault();
        if(projectUserInvitation!= null)
        {
          projectUserInvitation.CastMemberID = null;

          _projectUserInvitationRepository.Edit(projectUserInvitation);
          _projectUserInvitationRepository.Commit();
        }
      }
    }
}