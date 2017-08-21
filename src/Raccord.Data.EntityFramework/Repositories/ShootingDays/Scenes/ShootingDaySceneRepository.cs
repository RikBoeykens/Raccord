using Raccord.Domain.Model.ShootingDays.Scenes;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Raccord.Data.EntityFramework.Repositories.ShootingDays.Scenes
{
    // Repository for ShootingDayScene
    public class ShootingDaySceneRepository : BaseRepository<ShootingDayScene>, IShootingDaySceneRepository
    {
        public ShootingDaySceneRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<ShootingDayScene> GetAllForShootingDay(long dayID)
        {
            var query = GetIncludedSummary();

            return query.Where(sd=> sd.ShootingDayID == dayID);
        }

        public IEnumerable<ShootingDayScene> GetAllForDate(DateTime date)
        {
            var query = GetIncludedSummary();

            return query.Where(sd=> sd.ShootingDay.Date == date);
        }

        public IEnumerable<ShootingDayScene> GetAllForScene(long sceneID)
        {
            var query = GetIncludedSummary();

            return query.Where(sd=> sd.SceneID == sceneID);
        }

        public ShootingDayScene GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(sd => sd.ID == ID);
        }

        public ShootingDayScene GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(sd => sd.ID == ID);
        }

        private IQueryable<ShootingDayScene> GetIncludedFull()
        {
            IQueryable<ShootingDayScene> query = _context.Set<ShootingDayScene>();

            return query.Include(sd=> sd.ShootingDay)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.DayNight)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(s=> s.Image)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.ScheduleScenes)
                        .Include(ss=> ss.LocationSet)
                        .ThenInclude(ls=> ls.Location);
        }

        private IQueryable<ShootingDayScene> GetIncludedSummary()
        {
            IQueryable<ShootingDayScene> query = _context.Set<ShootingDayScene>();

            return query.Include(sd=> sd.ShootingDay)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.DayNight)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(s=> s.Image);
        }

        private IQueryable<ShootingDayScene> GetIncluded()
        {
            IQueryable<ShootingDayScene> query = _context.Set<ShootingDayScene>();

            return query;
        }
    }
}
