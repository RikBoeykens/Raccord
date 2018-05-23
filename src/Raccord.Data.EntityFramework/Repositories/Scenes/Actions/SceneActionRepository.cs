using Raccord.Domain.Model.Scenes.Actions;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Scenes.Actions
{
    // Repository for scene actions
    public class SceneActionRepository : BaseRepository<SceneAction, long>, ISceneActionRepository
    {
        public SceneActionRepository(RaccordDBContext context) : base(context) 
        {
        }
    }
}
