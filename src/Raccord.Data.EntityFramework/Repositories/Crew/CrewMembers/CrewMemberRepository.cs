using Raccord.Domain.Model.Crew.CrewMembers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Crew.CrewMembers
{
    // Repository for crew members
    public class CrewMemberRepository : BaseRepository<CrewMember>, ICrewMemberRepository
    {
        public CrewMemberRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<CrewMember> GetAllForDepartment(long departmentID)
        {
            var query = GetIncludedSummary();

            return query.Where(s=> s.DepartmentID == departmentID);
        }

        public CrewMember GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public CrewMember GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public int SearchCount(string searchText, long? projectID, string userID, bool isAdmin)
        {
            var query = GetSearchQuery(searchText, projectID, userID, isAdmin);

            return query.Count();            
        }

        public IEnumerable<CrewMember> Search(string searchText, long? projectID, string userID, bool isAdmin)
        {
            return GetSearchQuery(searchText, projectID, userID, isAdmin);
        }

        private IQueryable<CrewMember> GetIncludedFull()
        {
            IQueryable<CrewMember> query = _context.Set<CrewMember>();

            return query.Include(t => t.Department)
                        .Include(cm=> cm.ProjectUser)
                        .ThenInclude(pu=> pu.User);
        }

        private IQueryable<CrewMember> GetIncludedSummary()
        {
            IQueryable<CrewMember> query = _context.Set<CrewMember>();

            return query.Include(t => t.Department)
                        .Include(cm=> cm.ProjectUser)
                        .ThenInclude(pu=> pu.User);
        }

        private IQueryable<CrewMember> GetIncluded()
        {
            IQueryable<CrewMember> query = _context.Set<CrewMember>();

            return query;
        }

        private IQueryable<CrewMember> GetIncludedSearch()
        {
            IQueryable<CrewMember> query = _context.Set<CrewMember>();

            return query.Include(cm=> cm.Department)
                         .ThenInclude(s=> s.Project)
                         .ThenInclude(p=> p.ProjectUsers)
                        .Include(cm=> cm.ProjectUser)
                        .ThenInclude(pu=> pu.User);
        }

        private IQueryable<CrewMember> GetSearchQuery(string searchText, long? projectID, string userID, bool isAdmin)
        {
            var query = GetIncludedSearch();

            query = query.Where(s=> s.FirstName.ToLower().Contains(searchText.ToLower()) 
                                    ||
                                    s.LastName.ToLower().Contains(searchText.ToLower())
                                    ||
                                    s.Department.Name.ToLower().Contains(searchText.ToLower())
            );

            if(projectID.HasValue)
                query = query.Where(s=> s.Department.ProjectID==projectID.Value);

            if(!isAdmin)
                query = query.Where(s=> s.Department.Project.ProjectUsers.Any(c=> c.UserID == userID));

            return query;
        }
    }
}
