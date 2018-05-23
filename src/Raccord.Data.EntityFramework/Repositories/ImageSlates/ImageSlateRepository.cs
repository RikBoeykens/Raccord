using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Images;

namespace Raccord.Data.EntityFramework.Repositories.ImageSlates
{
    // Repository for images
    public class ImageSlateRepository : BaseRepository<ImageSlate, long>, IImageSlateRepository
    {
        public ImageSlateRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<ImageSlate> GetAllForSlate(long slateID)
        {
            var query = GetIncludedImage();

            return query.Where(l=> l.SlateID == slateID);
        }

        private IQueryable<ImageSlate> GetIncludedImage()
        {
            IQueryable<ImageSlate> query = _context.Set<ImageSlate>();

            return query.Include(i=> i.Image);
        }
    }
}
