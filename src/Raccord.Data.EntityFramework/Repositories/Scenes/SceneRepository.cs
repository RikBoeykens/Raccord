using Raccord.Domain.Model.Scenes;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Scenes
{
    // Repository for scenes
    public class SceneRepository : BaseRepository<Scene>, ISceneRepository
    {
        public SceneRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<Scene> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(s=> s.ProjectID == projectID).OrderBy(s=> s.SortingOrder);
        }

        public Scene GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public Scene GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(l => l.ID == ID);
        }


        public int SearchCount(string searchText, long? projectID)
        {
            var query = GetSearchQuery(searchText, projectID);

            return query.Count();            
        }

        public IEnumerable<Scene> Search(string searchText, long? projectID)
        {
            return GetSearchQuery(searchText, projectID);
        }

        private IQueryable<Scene> GetIncludedFull()
        {
            IQueryable<Scene> query = _context.Set<Scene>();

            return query.Include(s => s.IntExt)
                         .Include(s => s.ScriptLocation)
                         .Include(s => s.DayNight)
                         .Include(s=> s.ImageScenes)
                         .ThenInclude(i=> i.Image)
                         .Include(s=> s.CharacterScenes)
                         .ThenInclude(cs=> cs.Character)
                         .ThenInclude(c=> c.ImageCharacters)
                         .ThenInclude(ic=> ic.Image)
                         .Include(s=> s.BreakdownItemScenes)
                         .ThenInclude(bis=> bis.BreakdownItem)
                         .ThenInclude(bi=> bi.BreakdownType)
                         .Include(s=> s.BreakdownItemScenes)
                         .ThenInclude(bis=> bis.BreakdownItem)
                         .ThenInclude(bi=> bi.ImageBreakdownItems)
                         .ThenInclude(ibi=> ibi.Image)
                         .Include(s=> s.BreakdownItemScenes)
                         .ThenInclude(bis=> bis.BreakdownItem)
                         .ThenInclude(bi=> bi.BreakdownType)
                         .Include(s => s.ScheduleScenes)
                         .ThenInclude(ss=> ss.ScheduleDay)
                         .ThenInclude(sd=> sd.ScheduleScenes);
        }

        private IQueryable<Scene> GetIncludedSummary()
        {
            IQueryable<Scene> query = _context.Set<Scene>();

            return query.Include(s => s.IntExt)
                         .Include(s => s.ScriptLocation)
                         .Include(s => s.DayNight)
                         .Include(s=> s.ImageScenes)
                         .ThenInclude(i=> i.Image);
        }

        private IQueryable<Scene> GetIncluded()
        {
            IQueryable<Scene> query = _context.Set<Scene>();

            return query.Include(s => s.IntExt)
                         .Include(s => s.ScriptLocation)
                         .Include(s => s.DayNight);
        }

        private IQueryable<Scene> GetIncludedSearch()
        {
            IQueryable<Scene> query = _context.Set<Scene>();

            return query.Include(s => s.IntExt)
                         .Include(s => s.ScriptLocation)
                         .Include(s => s.DayNight)
                         .Include(s=> s.Project);
        }

        private IQueryable<Scene> GetSearchQuery(string searchText, long? projectID)
        {
            var query = GetIncludedSearch();

            query = query.Where(l=> l.Summary.ToLower().Contains(searchText.ToLower()));

            if(projectID.HasValue)
                query = query.Where(l=> l.ProjectID==projectID.Value);

            return query;
        }
    }
}
