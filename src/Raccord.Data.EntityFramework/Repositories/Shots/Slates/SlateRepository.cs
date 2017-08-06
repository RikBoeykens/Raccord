using Raccord.Domain.Model.Shots;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Shots.Slates
{
    // Repository for slates
    public class SlateRepository : BaseRepository<Slate>, ISlateRepository
    {
        public SlateRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<Slate> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(s=> s.ProjectID == projectID);
        }

        public Slate GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public Slate GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(l => l.ID == ID);
        }


        public int SearchCount(string searchText, long? projectID, string userID, bool isAdmin)
        {
            var query = GetSearchQuery(searchText, projectID, userID, isAdmin);

            return query.Count();            
        }

        public IEnumerable<Slate> Search(string searchText, long? projectID, string userID, bool isAdmin)
        {
            return GetSearchQuery(searchText, projectID, userID, isAdmin);
        }

        private IQueryable<Slate> GetIncludedFull()
        {
            IQueryable<Slate> query = _context.Set<Slate>();

            return query.Include(s => s.Takes)
                        .Include(s=> s.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(s=> s.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(s=> s.Scene)
                        .ThenInclude(s=> s.DayNight)
                        .Include(s=> s.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(ims=> ims.Image)
                        .Include(s=> s.ShootingDay);
        }

        private IQueryable<Slate> GetIncludedSummary()
        {
            IQueryable<Slate> query = _context.Set<Slate>();

            return query.Include(s => s.Takes);
        }

        private IQueryable<Slate> GetIncluded()
        {
            IQueryable<Slate> query = _context.Set<Slate>();

            return query;
        }

        private IQueryable<Slate> GetIncludedSearch()
        {
            IQueryable<Slate> query = _context.Set<Slate>();

            return query.Include(s=> s.Project)
                         .ThenInclude(p=> p.Crew);
        }

        private IQueryable<Slate> GetSearchQuery(string searchText, long? projectID, string userID, bool isAdmin)
        {
            var query = GetIncludedSearch();

            query = query.Where(s=> s.Number.ToLower().Contains(searchText.ToLower()));

            if(projectID.HasValue)
                query = query.Where(s=> s.ProjectID==projectID.Value);

            if(!isAdmin)
                query = query.Where(s=> s.Project.Crew.Any(c=> c.UserID == userID));

            return query;
        }
    }
}
