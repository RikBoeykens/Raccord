using System.Linq;
using Raccord.Application.Core.Services.Users.Project.Cast;
using Raccord.Data.EntityFramework.Repositories.Cast;
using Raccord.Data.EntityFramework.Repositories.Characters;
using Raccord.Data.EntityFramework.Repositories.Users.Projects;

namespace Raccord.Application.Services.Users.Project.Cast
{
    // Service for project user cast functionality
    public class ProjectUserCastService : IProjectUserCastService
    {
      private readonly ICastMemberRepository _castMemberRepository;
      private readonly IProjectUserRepository _projectUserRepository;

      public ProjectUserCastService(
        ICastMemberRepository castMemberRepository,
        IProjectUserRepository projectUserRepository
      ){
        _castMemberRepository = castMemberRepository;
        _projectUserRepository = projectUserRepository;
      }

      public void Link(long projectUserID, long castMemberID)
      {
        var castMember = _castMemberRepository.GetSingle(castMemberID);
        castMember.ProjectUserID = projectUserID;

        _castMemberRepository.Edit(castMember);
        _castMemberRepository.Commit();

        var projectUser = _projectUserRepository.GetSingle(projectUserID);
        projectUser.CastMemberID = castMemberID;

        _projectUserRepository.Edit(projectUser);
        _projectUserRepository.Commit();
      }

      public void RemoveLink(long projectUserID, long castMemberID)
      {
        var castMember = _castMemberRepository.FindBy(cm=> cm.ID == castMemberID && cm.ProjectUserID == projectUserID).FirstOrDefault();
        if(castMember!= null)
        {
          castMember.ProjectUserID = null;

          _castMemberRepository.Edit(castMember);
          _castMemberRepository.Commit();
        }
        var projectUser = _projectUserRepository.FindBy(cm=> cm.ID == projectUserID && cm.CastMemberID == castMemberID).FirstOrDefault();
        if(projectUser!= null)
        {
          projectUser.CastMemberID = null;

          _projectUserRepository.Edit(projectUser);
          _projectUserRepository.Commit();
        }
      }
    }
}