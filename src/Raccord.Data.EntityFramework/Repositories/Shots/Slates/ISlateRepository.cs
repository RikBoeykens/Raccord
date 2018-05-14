using Raccord.Domain.Model.Shots;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Shots.Slates
{
    // Interface defining a repository for Scenes
    public interface ISlateRepository : IBaseRepository<Slate>
    {
        IEnumerable<Slate> GetAllForProject(long projectID);
        Slate GetFull(long ID);
        Slate GetSummary(long ID);
        int SearchCount(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
        IEnumerable<Slate> Search(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
    }
}