using Raccord.Domain.Model.Scheduling;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleDays
{
    // Repository for ScheduleDay
    public class ScheduleDayRepository : BaseRepository<ScheduleDay>, IScheduleDayRepository
    {
        public ScheduleDayRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<ScheduleDay> GetAllForProject(long projectID)
        {
            var query = GetIncludedFull();

            return query.Where(sd=> sd.ProjectID == projectID);
        }

        public ScheduleDay GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(sd => sd.ID == ID);
        }

        public ScheduleDay GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(sd => sd.ID == ID);
        }

        private IQueryable<ScheduleDay> GetIncludedFull()
        {
            IQueryable<ScheduleDay> query = _context.Set<ScheduleDay>();

            return query.Include(sd=> sd.ScheduleScenes)
                        .ThenInclude(ss=> ss.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(sd=> sd.ScheduleScenes)
                        .ThenInclude(ss=> ss.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(sd=> sd.ScheduleScenes)
                        .ThenInclude(ss=> ss.Scene)
                        .ThenInclude(s=> s.DayNight)
                        .Include(sd=> sd.ScheduleScenes)
                        .ThenInclude(ss=> ss.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(i=> i.Image)
                        .Include(ss=> ss.ScheduleScenes)
                        .ThenInclude(ss=> ss.Characters)
                        .ThenInclude(cs=> cs.CharacterScene)
                        .ThenInclude(cs=> cs.Character)
                        .ThenInclude(c=> c.ImageCharacters)
                        .ThenInclude(ic=> ic.Image)
                        .Include(sd=> sd.Notes);
        }

        private IQueryable<ScheduleDay> GetIncludedSummary()
        {
            IQueryable<ScheduleDay> query = _context.Set<ScheduleDay>();

            return query.Include(sd=> sd.ScheduleScenes);
        }

        private IQueryable<ScheduleDay> GetIncluded()
        {
            IQueryable<ScheduleDay> query = _context.Set<ScheduleDay>();

            return query;
        }
    }
}
