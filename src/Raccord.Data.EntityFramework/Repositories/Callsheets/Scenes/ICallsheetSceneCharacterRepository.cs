using System.Collections.Generic;
using Raccord.Domain.Model.Callsheets.Scenes;

namespace Raccord.Data.EntityFramework.Repositories.Callsheets.Scenes
{
    // Interface defining a repository for schedule characters
    public interface ICallsheetSceneCharacterRepository : IBaseRepository<CallsheetSceneCharacter, long>
    {
        IEnumerable<CallsheetSceneCharacter> GetAllForCallsheetScene(long callsheetSceneID);
        IEnumerable<CallsheetSceneCharacter> GetAllForCharacter(long characterID);
        IEnumerable<CallsheetSceneCharacter> GetAllForCallsheet(long callsheetID);
    }
}