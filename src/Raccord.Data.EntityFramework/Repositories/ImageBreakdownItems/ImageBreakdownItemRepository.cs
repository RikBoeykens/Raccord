using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Images;

namespace Raccord.Data.EntityFramework.Repositories.ImageBreakdownItems
{
    // Repository for image breakdown items
    public class ImageBreakdownItemRepository : BaseRepository<ImageBreakdownItem>, IImageBreakdownItemRepository
    {
        public ImageBreakdownItemRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<ImageBreakdownItem> GetAllForBreakdownItem(long itemID)
        {
            var query = GetIncludedImage();

            return query.Where(ibi=> ibi.BreakdownItemID == itemID);
        }

        private IQueryable<ImageBreakdownItem> GetIncludedImage()
        {
            IQueryable<ImageBreakdownItem> query = _context.Set<ImageBreakdownItem>();

            return query.Include(i=> i.Image)
                        .Include(i=> i.BreakdownItem)
                            .ThenInclude(i=>i.BreakdownType)
                        .Include(i => i.BreakdownItem)
                            .ThenInclude(i=> i.Breakdown);
        }
    }
}
