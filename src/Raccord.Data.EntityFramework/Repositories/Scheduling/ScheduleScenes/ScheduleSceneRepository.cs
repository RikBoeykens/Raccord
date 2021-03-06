using Raccord.Domain.Model.Scheduling;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleScenes
{
    // Repository for ScheduleScene
    public class ScheduleSceneRepository : BaseRepository<ScheduleScene, long>, IScheduleSceneRepository
    {
        public ScheduleSceneRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<ScheduleScene> GetAllForScheduleDay(long dayID)
        {
            var query = GetIncludedSummary();

            return query.Where(sd=> sd.ScheduleDayID == dayID);
        }

        public IEnumerable<ScheduleScene> GetAllForScheduleDaySort(long dayID)
        {
            var query = GetIncludedSort();

            return query.Where(sd=> sd.ScheduleDayID == dayID);
        }

        public IEnumerable<ScheduleScene> GetAllForScheduleDate(DateTime date)
        {
            var query = GetIncludedSummary();

            return query.Where(sd=> sd.ScheduleDay.Date == date);
        }

        public IEnumerable<ScheduleScene> GetAllForScene(long sceneID)
        {
            var query = GetIncludedSummary();

            return query.Where(sd=> sd.SceneID == sceneID);
        }

        public ScheduleScene GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(sd => sd.ID == ID);
        }

        public ScheduleScene GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(sd => sd.ID == ID);
        }

        private IQueryable<ScheduleScene> GetIncludedFull()
        {
            IQueryable<ScheduleScene> query = _context.Set<ScheduleScene>();

            return query.Include(ss=> ss.ScheduleDay)
                        .ThenInclude(sd=> sd.ShootingDay)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.SceneIntro)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.TimeOfDay)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(s=> s.Image)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.ScheduleScenes)
                        .Include(ss=> ss.Characters)
                        .ThenInclude(cs=> cs.CharacterScene)
                        .ThenInclude(cs=> cs.Character)
                        .ThenInclude(c=> c.ImageCharacters)
                        .ThenInclude(ic=> ic.Image)
                        .Include(ss=> ss.LocationSet)
                        .ThenInclude(ls=> ls.Location);
        }

        private IQueryable<ScheduleScene> GetIncludedSummary()
        {
            IQueryable<ScheduleScene> query = _context.Set<ScheduleScene>();

            return query.Include(ss=> ss.ScheduleDay)
                        .ThenInclude(sd=> sd.ShootingDay)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.SceneIntro)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.TimeOfDay)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(s=> s.Image)
                        .Include(ss=> ss.Characters)
                        .ThenInclude(cs=> cs.CharacterScene)
                        .ThenInclude(cs=> cs.Character)
                        .ThenInclude(c=> c.ImageCharacters)
                        .ThenInclude(ic=> ic.Image);
        }

        private IQueryable<ScheduleScene> GetIncluded()
        {
            IQueryable<ScheduleScene> query = _context.Set<ScheduleScene>();

            return query;
        }

        private IQueryable<ScheduleScene> GetIncludedSort()
        {
            IQueryable<ScheduleScene> query = _context.Set<ScheduleScene>();

            return query;
        }
    }
}
