using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Users;

namespace Raccord.Data.EntityFramework.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        protected RaccordDBContext _context;

        public UserRepository(RaccordDBContext context)
        {
            _context = context;
        }

        public ApplicationUser Get(string ID)
        {
            var query = GetIncluded();

            return query.FirstOrDefault(u => u.Id == ID);
        }

        public ApplicationUser GetSummary(string ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(u => u.Id == ID);
        }

        public ApplicationUser GetFull(string ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(u => u.Id == ID);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            var query = GetIncludedSummary();

            return query;
        }

        private IQueryable<ApplicationUser> GetIncluded()
        {
            IQueryable<ApplicationUser> query = _context.Set<ApplicationUser>();

            return query;
        }

        private IQueryable<ApplicationUser> GetIncludedFull()
        {
            IQueryable<ApplicationUser> query = _context.Set<ApplicationUser>();

            return query;
        }

        private IQueryable<ApplicationUser> GetIncludedSummary()
        {
            IQueryable<ApplicationUser> query = _context.Set<ApplicationUser>();

            return query;
        }
    }
}