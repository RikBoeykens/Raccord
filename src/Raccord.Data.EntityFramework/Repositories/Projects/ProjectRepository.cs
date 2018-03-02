using Raccord.Domain.Model.Projects;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Projects
{
    // Repository for projects
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(RaccordDBContext context) : base(context) 
        {
        }

        public override IEnumerable<Project> GetAll()
        {
            var query = GetIncludedSummary();

            return query;
        }

        public IEnumerable<Project> GetAllForUser(string userID)
        {
            var query = GetIncludedSummary();

            return query.Where(p=> p.ProjectUsers.Any(c=> c.UserID == userID));
        }

        public Project GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public Project GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public int SearchCount(string searchText, string userID, bool isAdmin, long[] excludeIds)
        {
            var query = GetSearchQuery(searchText, userID, isAdmin, excludeIds);

            return query.Count();        
        }

        public IEnumerable<Project> Search(string searchText, string userID, bool isAdmin, long[] excludeIds)
        {
            return GetSearchQuery(searchText, userID, isAdmin, excludeIds);
        }

        private IQueryable<Project> GetIncludedFull()
        {
            IQueryable<Project> query = _context.Set<Project>();

            return query.Include(l=> l.Images)
                        .Include(p=> p.Comments)
                        .ThenInclude(c=> c.User);
        }

        private IQueryable<Project> GetIncludedSummary()
        {
            IQueryable<Project> query = _context.Set<Project>();

            return query.Include(l=> l.Images)
                        .Include(p=> p.ProjectUsers)
                        .ThenInclude(p=> p.User);
        }

        private IQueryable<Project> GetIncluded()
        {
            IQueryable<Project> query = _context.Set<Project>();

            return query;
        }
        private IQueryable<Project> GetIncludedSearch()
        {
            IQueryable<Project> query = _context.Set<Project>();

            return query.Include(p=> p.ProjectUsers)
                        .ThenInclude(p=> p.User);
        }

        private IQueryable<Project> GetSearchQuery(string searchText, string userId, bool isAdminSearch, long[] excludeIds)
        {
            var query = GetIncludedSearch();

            query = query.Where(p=> p.Title.ToLower().Contains(searchText.ToLower()));

            if(!isAdminSearch)
                query = query.Where(p=> p.ProjectUsers.Any(c=> c.UserID==userId));

            if(excludeIds.Any())
            {
                query = query.Where(c=> !excludeIds.Any(id=> id == c.ID));
            }

            return query;
        }
    }
}
