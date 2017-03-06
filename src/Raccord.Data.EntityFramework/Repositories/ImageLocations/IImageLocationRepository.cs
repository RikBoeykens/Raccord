using System.Collections.Generic;
using Raccord.Domain.Model.Images;

namespace Raccord.Data.EntityFramework.Repositories.ImageLocations
{
    // Interface defining a repository for Image Locations
    public interface IImageLocationRepository : IBaseRepository<ImageLocation>
    {
        IEnumerable<ImageLocation> GetAllForLocation(long locationID);
    }
}