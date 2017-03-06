using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Images;

namespace Raccord.Data.EntityFramework.Repositories.ImageLocations
{
    // Repository for image locations
    public class ImageLocationRepository : BaseRepository<ImageLocation>, IImageLocationRepository
    {
        public ImageLocationRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<ImageLocation> GetAllForLocation(long locationID)
        {
            var query = GetIncludedImage();

            return query.Where(l=> l.LocationID == locationID);
        }

        private IQueryable<ImageLocation> GetIncludedImage()
        {
            IQueryable<ImageLocation> query = _context.Set<ImageLocation>();

            return query.Include(i=> i.Image);
        }
    }
}
