using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Crew.Departments;

namespace Raccord.Data.EntityFramework.Repositories.Crew.Departments
{
    // Repository for breakdown types
    public class CrewDepartmentRepository : BaseRepository<CrewDepartment, long>, ICrewDepartmentRepository
    {
        public CrewDepartmentRepository(RaccordDBContext context) : base(context) 
        {
        }


        public IEnumerable<CrewDepartment> GetAllForUnit(long crewUnitID)
        {
            var query = GetIncludedSummary();

            return query.Where(l=> l.CrewUnitID == crewUnitID);
        }

        public CrewDepartment GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public CrewDepartment GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        private IQueryable<CrewDepartment> GetIncludedFull()
        {
            IQueryable<CrewDepartment> query = _context.Set<CrewDepartment>();

            return query.Include(cd=> cd.Crew)
                            .ThenInclude(c => c.CrewUnitMember)
                                .ThenInclude(c=> c.ProjectUser)
                                    .ThenInclude(pu=> pu.User)
                        .Include(cd=> cd.Crew)
                            .ThenInclude(c => c.CrewUnitInvitationMember)
                                .ThenInclude(c=> c.ProjectUserInvitation)
                                    .ThenInclude(pu=> pu.UserInvitation);
        }

        private IQueryable<CrewDepartment> GetIncludedSummary()
        {
            IQueryable<CrewDepartment> query = _context.Set<CrewDepartment>();

            return query.Include(cd=> cd.Crew)
                            .ThenInclude(c => c.CrewUnitMember)
                                .ThenInclude(c=> c.ProjectUser)
                                    .ThenInclude(pu=> pu.User)
                        .Include(cd=> cd.Crew)
                            .ThenInclude(c => c.CrewUnitInvitationMember)
                                .ThenInclude(c=> c.ProjectUserInvitation)
                                    .ThenInclude(pu=> pu.UserInvitation);
        }

        private IQueryable<CrewDepartment> GetIncluded()
        {
            IQueryable<CrewDepartment> query = _context.Set<CrewDepartment>();

            return query;
        }
    }
}
