using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Images;

namespace Raccord.Data.EntityFramework.Repositories.ImageScriptLocations
{
    // Repository for image locations
    public class ImageScriptLocationRepository : BaseRepository<ImageScriptLocation>, IImageScriptLocationRepository
    {
        public ImageScriptLocationRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<ImageScriptLocation> GetAllForScriptLocation(long scriptLocationID)
        {
            var query = GetIncludedImage();

            return query.Where(l=> l.ScriptLocationID == scriptLocationID);
        }

        private IQueryable<ImageScriptLocation> GetIncludedImage()
        {
            IQueryable<ImageScriptLocation> query = _context.Set<ImageScriptLocation>();

            return query.Include(i=> i.Image);
        }
    }
}
