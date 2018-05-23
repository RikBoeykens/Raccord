using Raccord.Domain.Model.Images;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Images
{
    // Interface defining a repository for Images
    public interface IImageRepository : IBaseRepository<Image, long>
    {
        IEnumerable<Image> GetAllForProject(long projectID);
        Image GetFull(long ID);
        Image GetSummary(long ID);
        int SearchCount(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
        IEnumerable<Image> Search(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds);
    }
}