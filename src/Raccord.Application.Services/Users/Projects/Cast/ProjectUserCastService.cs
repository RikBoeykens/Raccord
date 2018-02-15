using System.Linq;
using Raccord.Application.Core.Services.Users.Project.Cast;
using Raccord.Data.EntityFramework.Repositories.Characters;
using Raccord.Data.EntityFramework.Repositories.Users.Projects;

namespace Raccord.Application.Services.Users.Project.Cast
{
    // Service for project user cast functionality
    public class ProjectUserCastService : IProjectUserCastService
    {
      private readonly ICharacterRepository _characterRepository;

      public ProjectUserCastService(
        ICharacterRepository crewMemberRepository
      ){
        _characterRepository = crewMemberRepository;
      }

      public void Link(long projectUserID, long characterID)
      {
        var character = _characterRepository.GetSingle(characterID);
        character.ProjectUserID = projectUserID;

        _characterRepository.Edit(character);
        _characterRepository.Commit();
      }

      public void RemoveLink(long projectUserID, long characterID)
      {
        var crewMember = _characterRepository.FindBy(cm=> cm.ID == characterID && cm.ProjectUserID == projectUserID).FirstOrDefault();
        if(crewMember!= null)
        {
          crewMember.ProjectUserID = null;

          _characterRepository.Edit(crewMember);
          _characterRepository.Commit();
        }
      }
    }
}