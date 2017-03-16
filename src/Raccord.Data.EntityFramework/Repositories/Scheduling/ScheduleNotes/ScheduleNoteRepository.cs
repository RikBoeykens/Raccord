using Raccord.Domain.Model.Scheduling;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleDayNotes
{
    // Repository for ScheduleDayNote
    public class ScheduleDayNoteRepository : BaseRepository<ScheduleDayNote>, IScheduleDayNoteRepository
    {
        public ScheduleDayNoteRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<ScheduleDayNote> GetAllForScheduleDay(long dayID)
        {
            var query = GetIncludedSummary();

            return query.Where(sd=> sd.ScheduleDayID == dayID);
        }

        public ScheduleDayNote GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(sd => sd.ID == ID);
        }

        public ScheduleDayNote GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(sd => sd.ID == ID);
        }

        private IQueryable<ScheduleDayNote> GetIncludedFull()
        {
            IQueryable<ScheduleDayNote> query = _context.Set<ScheduleDayNote>();

            return query.Include(sd=> sd.ScheduleDay);
        }

        private IQueryable<ScheduleDayNote> GetIncludedSummary()
        {
            IQueryable<ScheduleDayNote> query = _context.Set<ScheduleDayNote>();

            return query.Include(sd=> sd.ScheduleDay);
        }

        private IQueryable<ScheduleDayNote> GetIncluded()
        {
            IQueryable<ScheduleDayNote> query = _context.Set<ScheduleDayNote>();

            return query;
        }
    }
}
