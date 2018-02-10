using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Breakdowns;

namespace Raccord.Data.EntityFramework.Repositories.Breakdowns
{
    // Repository for breakdown
    public class BreakdownRepository : BaseRepository<Breakdown>, IBreakdownRepository
    {
        public BreakdownRepository(RaccordDBContext context) : base(context) 
        {
        }


        public IEnumerable<Breakdown> GetAllForParent(long projectID, string userID)
        {
            var query = GetIncludedSummary();

            return query.Where(b=> 
                b.ProjectID == projectID && 
                (
                    b.IsPublished ||
                    b.UserID == userID
                ));
        }

        public Breakdown GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public Breakdown GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public bool ProjectUserHasSelected(long projectID, string userID)
        {
            var query = GetIncludedProjectUser();

            return query.Any(b=> b.SelectedByUsers.Any(sbu => sbu.ProjectID == projectID && sbu.UserID == userID));
        }

        public Breakdown GetProjectUserSelected(long projectID, string userID)
        {
            var query = GetIncludedProjectUser();

            return query.FirstOrDefault(b=> b.SelectedByUsers.Any(sbu => sbu.ProjectID == projectID && sbu.UserID == userID));
        }

        public bool ProjectHasDefault(long projectID)
        {
            var query = GetIncludedDefaultProject();

            return query.Any(b=> b.IsDefaultProjectBreakdown && b.ProjectID==projectID);
        }

        public Breakdown GetDefaultProject(long projectID)
        {
            var query = GetIncludedDefaultProject();

            return query.FirstOrDefault(b=> b.IsDefaultProjectBreakdown && b.ProjectID==projectID);
        }

        private IQueryable<Breakdown> GetIncludedFull()
        {
            IQueryable<Breakdown> query = _context.Set<Breakdown>();

            return query.Include(b => b.Types);
        }

        private IQueryable<Breakdown> GetIncludedSummary()
        {
            IQueryable<Breakdown> query = _context.Set<Breakdown>();

            return query.Include(bt=> bt.Types)
                        .Include(b => b.User);
        }

        private IQueryable<Breakdown> GetIncludedProjectUser()
        {
            IQueryable<Breakdown> query = _context.Set<Breakdown>();

            return query.Include(b => b.Types)
                        .Include(b => b.SelectedByUsers);
        }

        private IQueryable<Breakdown> GetIncludedDefaultProject()
        {
            IQueryable<Breakdown> query = _context.Set<Breakdown>();

            return query.Include(b => b.Types);
        }

        private IQueryable<Breakdown> GetIncluded()
        {
            IQueryable<Breakdown> query = _context.Set<Breakdown>();

            return query;
        }
    }
}
