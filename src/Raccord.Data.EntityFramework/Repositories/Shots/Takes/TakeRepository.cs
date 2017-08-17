using Raccord.Domain.Model.Shots;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Shots.Takes
{
    // Repository for takes
    public class TakeRepository : BaseRepository<Take>, ITakeRepository
    {
        public TakeRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<Take> GetAllForSlate(long slateID)
        {
            var query = GetIncludedSummary();

            return query.Where(s=> s.SlateID == slateID);
        }

        public Take GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public Take GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        private IQueryable<Take> GetIncludedFull()
        {
            IQueryable<Take> query = _context.Set<Take>();

            return query.Include(t => t.Slate)
                        .ThenInclude(s=> s.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(t => t.Slate)
                        .ThenInclude(s=> s.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(t => t.Slate)
                        .ThenInclude(s=> s.Scene)
                        .ThenInclude(s=> s.DayNight)
                        .Include(t => t.Slate)
                        .ThenInclude(s=> s.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(ims=> ims.Image);
        }

        private IQueryable<Take> GetIncludedSummary()
        {
            IQueryable<Take> query = _context.Set<Take>();

            return query.Include(t => t.Slate);
        }

        private IQueryable<Take> GetIncluded()
        {
            IQueryable<Take> query = _context.Set<Take>();

            return query;
        }
    }
}
