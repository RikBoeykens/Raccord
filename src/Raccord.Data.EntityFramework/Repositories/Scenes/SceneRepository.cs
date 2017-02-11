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
            var query = GetIncludedScene();

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

        private IQueryable<Scene> GetIncludedScene()
        {
            IQueryable<Scene> query = _context.Set<Scene>();

            return query.Include(s => s.IntExt)
                         .Include(s => s.Location)
                         .Include(s => s.DayNight);
        }

        private IQueryable<Scene> GetIncludedSummary()
        {
            IQueryable<Scene> query = _context.Set<Scene>();

            return query.Include(s => s.IntExt)
                         .Include(s => s.Location)
                         .Include(s => s.DayNight);
        }

        private IQueryable<Scene> GetIncludedSearch()
        {
            IQueryable<Scene> query = _context.Set<Scene>();

            return query.Include(s => s.IntExt)
                         .Include(s => s.Location)
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
