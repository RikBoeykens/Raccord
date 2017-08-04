using Raccord.Domain.Model.Scenes;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Scenes
{
    // Interface defining a repository for Scenes
    public interface ISceneRepository : IBaseRepository<Scene>
    {
        IEnumerable<Scene> GetAllForProject(long projectID);
        Scene GetFull(long ID);
        Scene GetSummary(long ID);
        int SearchCount(string searchText, long? projectID, string userID, bool isAdmin);
        IEnumerable<Scene> Search(string searchText, long? projectID, string userID, bool isAdmin);
    }
}