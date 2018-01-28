using Raccord.Domain.Model.Characters;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Characters
{
    // Interface defining a repository for Characters
    public interface ICharacterRepository : IBaseRepository<Character>
    {
        IEnumerable<Character> GetAllForProject(long projectID);
        Character GetFull(long ID);
        Character GetSummary(long ID);
        int SearchCount(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
        IEnumerable<Character> Search(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
    }
}