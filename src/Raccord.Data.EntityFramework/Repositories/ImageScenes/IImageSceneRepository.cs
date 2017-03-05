using System.Collections.Generic;
using Raccord.Domain.Model.Images;

namespace Raccord.Data.EntityFramework.Repositories.ImageScenes
{
    // Interface defining a repository for Images
    public interface IImageSceneRepository : IBaseRepository<ImageScene>
    {
        IEnumerable<ImageScene> GetAllForScene(long sceneID);
    }
}