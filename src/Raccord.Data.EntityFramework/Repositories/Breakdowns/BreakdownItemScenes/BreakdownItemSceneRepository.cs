using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Breakdowns.BreakdownItems;

namespace Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownItemScenes
{
    // Repository for breakdown item scenes
    public class BreakdownItemSceneRepository : BaseRepository<BreakdownItemScene>, IBreakdownItemSceneRepository
    {
        public BreakdownItemSceneRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<BreakdownItemScene> GetAllForScene(long sceneID, long breakdownID)
        {
            var query = GetIncludedBreakdownItem();

            return query.Where(bis=> bis.SceneID == sceneID && bis.BreakdownItem.BreakdownID == breakdownID);
        }

        public IEnumerable<BreakdownItemScene> GetAllForBreakdownItem(long itemID)
        {
            var query = GetIncludedScene();

            return query.Where(bis=> bis.BreakdownItemID == itemID);
        }

        private IQueryable<BreakdownItemScene> GetIncludedBreakdownItem()
        {
            IQueryable<BreakdownItemScene> query = _context.Set<BreakdownItemScene>();

            return query.Include(bis=> bis.BreakdownItem)
                        .ThenInclude(bi=> bi.BreakdownType)
                        .Include(bis=> bis.BreakdownItem)
                        .ThenInclude(bi=> bi.ImageBreakdownItems)
                        .ThenInclude(ibi=> ibi.Image);
        }

        private IQueryable<BreakdownItemScene> GetIncludedScene()
        {
            IQueryable<BreakdownItemScene> query = _context.Set<BreakdownItemScene>();

            return query.Include(bis=> bis.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(bis=> bis.Scene)
                        .ThenInclude(s=> s.DayNight)
                        .Include(bis=> bis.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(bis=> bis.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(i=> i.Image);
        }
    }
}
