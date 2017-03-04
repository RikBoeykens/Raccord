using Raccord.Domain.Model.Images;

namespace Raccord.Data.EntityFramework.Repositories.Images
{
    // Repository for images
    public class ImageSceneRepository : BaseRepository<ImageScene>, IImageSceneRepository
    {
        public ImageSceneRepository(RaccordDBContext context) : base(context) 
        {
        }
    }
}
