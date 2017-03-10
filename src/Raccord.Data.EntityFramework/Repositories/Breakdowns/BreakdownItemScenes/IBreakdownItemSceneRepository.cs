using System.Collections.Generic;
using Raccord.Domain.Model.Breakdowns.BreakdownItems;

namespace Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownItemScenes
{
    // Interface defining a repository for character scenes
    public interface IBreakdownItemSceneRepository : IBaseRepository<BreakdownItemScene>
    {
        IEnumerable<BreakdownItemScene> GetAllForScene(long sceneID);
        IEnumerable<BreakdownItemScene> GetAllForBreakdownItem(long itemID);
    }
}