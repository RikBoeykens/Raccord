using Raccord.Domain.Model.Images;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Images
{
    // Interface defining a repository for Images
    public interface IImageRepository : IBaseRepository<Image>
    {
        IEnumerable<Image> GetAllForProject(long projectID);
        Image GetFull(long ID);
        Image GetSummary(long ID);
        int SearchCount(string searchText, long? projectID);
        IEnumerable<Image> Search(string searchText, long? projectID);
    }
}