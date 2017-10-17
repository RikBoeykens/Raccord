using Raccord.Domain.Model.SceneProperties;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.SceneProperties
{
    // Repository for Int/Ext
    public class IntExtRepository : BaseRepository<IntExt>, IIntExtRepository
    {
        public IntExtRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<IntExt> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(i=> i.ProjectID == projectID);
        }

        public IntExt GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(i => i.ID == ID);
        }

        public IntExt GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(i => i.ID == ID);
        }

        public int SearchCount(string searchText, long? projectID, string userID, bool isAdmin)
        {
            var query = GetSearchQuery(searchText, projectID, userID, isAdmin);

            return query.Count();
        }

        public IEnumerable<IntExt> Search(string searchText, long? projectID, string userID, bool isAdmin)
        {
            return GetSearchQuery(searchText, projectID, userID, isAdmin);
        }

        private IQueryable<IntExt> GetIncludedFull()
        {
            IQueryable<IntExt> query = _context.Set<IntExt>();

            return query.Include(i=> i.Scenes)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(i=> i.Scenes)
                        .ThenInclude(s=> s.DayNight);
        }

        private IQueryable<IntExt> GetIncludedSummary()
        {
            IQueryable<IntExt> query = _context.Set<IntExt>();

            return query.Include(i=> i.Scenes);
        }

        private IQueryable<IntExt> GetIncluded()
        {
            IQueryable<IntExt> query = _context.Set<IntExt>();

            return query;
        }

        private IQueryable<IntExt> GetIncludedSearch()
        {
            IQueryable<IntExt> query = _context.Set<IntExt>();

            return query.Include(i=> i.Project)
                        .ThenInclude(p=> p.ProjectUsers);
        }

        private IQueryable<IntExt> GetSearchQuery(string searchText, long? projectID, string userID, bool isAdmin)
        {
            IQueryable<IntExt> query = GetIncludedSearch();

            query = query.Where(l=> l.Name.ToLower().Contains(searchText.ToLower()));

            if(projectID.HasValue)
                query = query.Where(l=> l.ProjectID==projectID.Value);

            if(!isAdmin)
                query = query.Where(i=> i.Project.ProjectUsers.Any(c=> c.UserID == userID));

            return query;
        }
    }
}
