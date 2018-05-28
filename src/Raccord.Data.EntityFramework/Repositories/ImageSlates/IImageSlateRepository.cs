using System.Collections.Generic;
using Raccord.Domain.Model.Images;

namespace Raccord.Data.EntityFramework.Repositories.ImageSlates
{
    // Interface defining a repository for Images
    public interface IImageSlateRepository : IBaseRepository<ImageSlate, long>
    {
        IEnumerable<ImageSlate> GetAllForSlate(long slateID);
    }
}