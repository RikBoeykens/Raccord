using Raccord.Domain.Model.Scenes;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Scenes
{
    // Interface defining a repository for Scenes
    public interface ISceneRepository : IBaseRepository<Scene, long>
    {
        IEnumerable<Scene> GetAllForProject(long projectID);
        Scene GetFull(long ID);
        Scene GetSummary(long ID);
        int SearchCount(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
        IEnumerable<Scene> Search(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);

        IEnumerable<Scene> GetScriptForProject(long projectID);
        IEnumerable<Scene> GetScriptForCallsheet(long projectID);
        IEnumerable<Scene> GetScriptForCharacters(long[] characterIDs);
        Scene GetScript(long ID);
        IEnumerable<Scene> Filter(
            long projectID, 
            IEnumerable<long> sceneIntroIDs, 
            IEnumerable<long> scriptLocationIDs, 
            IEnumerable<long> timeOfDayIDs,
            IEnumerable<long> locationSetIDs,
            IEnumerable<long> locationIDs,
            IEnumerable<long> characterIDs,
            IEnumerable<long> castMemberIDs,
            IEnumerable<long> breakdownItemIDs,
            IEnumerable<long> scheduleDayIDs,
            IEnumerable<long> scheduleSceneShootingDayIDs,
            IEnumerable<long> callsheetIDs,
            IEnumerable<long> callsheetSceneShootingDayIDs,
            IEnumerable<long> shootingDayIDs,
            string searchText,
            int? minPageLength,
            int? maxPageLength
        );
    }
}