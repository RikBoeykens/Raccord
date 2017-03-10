using System.Collections.Generic;
using Raccord.Domain.Model.Images;

namespace Raccord.Data.EntityFramework.Repositories.ImageBreakdownItems
{
    // Interface defining a repository for Image Locations
    public interface IImageBreakdownItemRepository : IBaseRepository<ImageBreakdownItem>
    {
        IEnumerable<ImageBreakdownItem> GetAllForBreakdownItem(long breakdownItemID);
    }
}