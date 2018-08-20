using Raccord.Domain.Model.SceneProperties;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.SceneProperties
{
    // Interface defining a repository for Int/Ext
    public interface ISceneIntroRepository : IBaseRepository<SceneIntro, long>
    {
        IEnumerable<SceneIntro> GetAllForProject(long projectID);
        SceneIntro GetFull(long ID);
        SceneIntro GetSummary(long ID);
        int SearchCount(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
        IEnumerable<SceneIntro> Search(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
    }
}