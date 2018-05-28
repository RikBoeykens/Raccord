using System.Collections.Generic;
using Raccord.Domain.Model.Images;

namespace Raccord.Data.EntityFramework.Repositories.ImageScriptLocations
{
    // Interface defining a repository for Image Locations
    public interface IImageScriptLocationRepository : IBaseRepository<ImageScriptLocation, long>
    {
        IEnumerable<ImageScriptLocation> GetAllForScriptLocation(long scriptLocationID);
    }
}