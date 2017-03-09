using System.Collections.Generic;
using Raccord.Domain.Model.Characters;

namespace Raccord.Data.EntityFramework.Repositories.CharacterScenes
{
    // Interface defining a repository for character scenes
    public interface ICharacterSceneRepository : IBaseRepository<CharacterScene>
    {
        IEnumerable<CharacterScene> GetAllForScene(long sceneID);
        IEnumerable<CharacterScene> GetAllForCharacter(long characterID);
    }
}