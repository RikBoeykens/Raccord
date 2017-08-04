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

            return query.Where(p=> p.Crew.Any(c=> c.UserID == userID));
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

        public int SearchCount(string searchText, string userID, bool isAdmin)
        {
            var query = GetSearchQuery(searchText, userID, isAdmin);

            return query.Count();        
        }

        public IEnumerable<Project> Search(string searchText, string userID, bool isAdmin)
        {
            return GetSearchQuery(searchText, userID, isAdmin);
        }

        private IQueryable<Project> GetIncludedFull()
        {
            IQueryable<Project> query = _context.Set<Project>();

            return query.Include(l=> l.Images);
        }

        private IQueryable<Project> GetIncludedSummary()
        {
            IQueryable<Project> query = _context.Set<Project>();

            return query.Include(l=> l.Images)
                        .Include(p=> p.Crew)
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

            return query.Include(p=> p.Crew)
                        .ThenInclude(p=> p.User);
        }

        private IQueryable<Project> GetSearchQuery(string searchText, string userId, bool isAdminSearch)
        {
            var query = GetIncludedSearch();

            query = query.Where(p=> p.Title.ToLower().Contains(searchText.ToLower()));

            if(!isAdminSearch)
                query = query.Where(p=> p.Crew.Any(c=> c.UserID==userId));

            return query;
        }
    }
}
