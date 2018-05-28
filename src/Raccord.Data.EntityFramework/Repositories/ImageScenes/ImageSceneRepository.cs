using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Images;

namespace Raccord.Data.EntityFramework.Repositories.ImageScenes
{
    // Repository for images
    public class ImageSceneRepository : BaseRepository<ImageScene, long>, IImageSceneRepository
    {
        public ImageSceneRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<ImageScene> GetAllForScene(long sceneID)
        {
            var query = GetIncludedImage();

            return query.Where(l=> l.SceneID == sceneID);
        }

        private IQueryable<ImageScene> GetIncludedImage()
        {
            IQueryable<ImageScene> query = _context.Set<ImageScene>();

            return query.Include(i=> i.Image);
        }
    }
}
