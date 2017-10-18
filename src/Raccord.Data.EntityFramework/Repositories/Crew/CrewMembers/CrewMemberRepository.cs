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

        private IQueryable<CrewMember> GetIncludedFull()
        {
            IQueryable<CrewMember> query = _context.Set<CrewMember>();

            return query.Include(t => t.Department);
        }

        private IQueryable<CrewMember> GetIncludedSummary()
        {
            IQueryable<CrewMember> query = _context.Set<CrewMember>();

            return query.Include(t => t.Department);
        }

        private IQueryable<CrewMember> GetIncluded()
        {
            IQueryable<CrewMember> query = _context.Set<CrewMember>();

            return query;
        }
    }
}
