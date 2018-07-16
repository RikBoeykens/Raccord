using Raccord.Domain.Model.SceneProperties;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.SceneProperties
{
    // Repository for Int/Ext
    public class SceneIntroRepository : BaseRepository<SceneIntro, long>, ISceneIntroRepository
    {
        public SceneIntroRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<SceneIntro> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(i=> i.ProjectID == projectID);
        }

        public SceneIntro GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(i => i.ID == ID);
        }

        public SceneIntro GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(i => i.ID == ID);
        }

        public int SearchCount(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            var query = GetSearchQuery(searchText, projectID, userID, isAdmin, excludeIds);

            return query.Count();
        }

        public IEnumerable<SceneIntro> Search(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            return GetSearchQuery(searchText, projectID, userID, isAdmin, excludeIds);
        }

        private IQueryable<SceneIntro> GetIncludedFull()
        {
            IQueryable<SceneIntro> query = _context.Set<SceneIntro>();

            return query.Include(i=> i.Scenes)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(i=> i.Scenes)
                        .ThenInclude(s=> s.TimeOfDay);
        }

        private IQueryable<SceneIntro> GetIncludedSummary()
        {
            IQueryable<SceneIntro> query = _context.Set<SceneIntro>();

            return query.Include(i=> i.Scenes);
        }

        private IQueryable<SceneIntro> GetIncluded()
        {
            IQueryable<SceneIntro> query = _context.Set<SceneIntro>();

            return query;
        }

        private IQueryable<SceneIntro> GetIncludedSearch()
        {
            IQueryable<SceneIntro> query = _context.Set<SceneIntro>();

            return query.Include(i=> i.Project)
                        .ThenInclude(p=> p.ProjectUsers);
        }

        private IQueryable<SceneIntro> GetSearchQuery(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            IQueryable<SceneIntro> query = GetIncludedSearch();

            query = query.Where(l=> l.Name.ToLower().Contains(searchText.ToLower()));

            if(projectID.HasValue)
                query = query.Where(l=> l.ProjectID==projectID.Value);

            if(!isAdmin)
                query = query.Where(i=> i.Project.ProjectUsers.Any(c=> c.UserID == userID));

            if(excludeIds.Any())
            {
                query = query.Where(c=> !excludeIds.Any(id=> id == c.ID));
            }

            return query;
        }
    }
}
