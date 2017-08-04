using Raccord.Domain.Model.Images;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Images
{
    // Repository for images
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<Image> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(i=> i.ProjectID == projectID);
        }

        public Image GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(i => i.ID == ID);
        }

        public Image GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(i => i.ID == ID);
        }

        public int SearchCount(string searchText, long? projectID, string userID, bool isAdmin)
        {
            var query = GetSearchQuery(searchText, projectID, userID, isAdmin);

            return query.Count();            
        }

        public IEnumerable<Image> Search(string searchText, long? projectID, string userID, bool isAdmin)
        {
            return GetSearchQuery(searchText, projectID, userID, isAdmin);
        }

        private IQueryable<Image> GetIncludedFull()
        {
            IQueryable<Image> query = _context.Set<Image>();

            return query.Include(i=> i.ImageScenes)
                        .ThenInclude(i=> i.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(i=> i.ImageScenes)
                        .ThenInclude(i=> i.Scene)
                        .ThenInclude(s=> s.DayNight)
                        .Include(i=> i.ImageScenes)
                        .ThenInclude(i=> i.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(i=> i.ImageScriptLocations)
                        .ThenInclude(il=> il.ScriptLocation)
                        .Include(i=> i.ImageCharacters)
                        .ThenInclude(ic=> ic.Character)
                        .Include(i=> i.ImageBreakdownItems)
                        .ThenInclude(ibi=> ibi.BreakdownItem)
                        .ThenInclude(ibi=> ibi.BreakdownType);
        }

        private IQueryable<Image> GetIncludedSummary()
        {
            IQueryable<Image> query = _context.Set<Image>();

            return query;
        }

        private IQueryable<Image> GetIncluded()
        {
            IQueryable<Image> query = _context.Set<Image>();

            return query;
        }

        private IQueryable<Image> GetIncludedSearch()
        {
            IQueryable<Image> query = _context.Set<Image>();

            return query.Include(i=> i.Project)
                        .ThenInclude(p=> p.Crew);
        }

        private IQueryable<Image> GetSearchQuery(string searchText, long? projectID, string userID, bool isAdmin)
        {
            var query = GetIncludedSearch();

            query = query.Where(i=> i.Title.ToLower().Contains(searchText.ToLower()));

            if(projectID.HasValue)
                query = query.Where(i=> i.ProjectID==projectID.Value);

            if(!isAdmin)
                query = query.Where(l=> l.Project.Crew.Any(c=> c.UserID == userID));

            return query;
        }
    }
}
