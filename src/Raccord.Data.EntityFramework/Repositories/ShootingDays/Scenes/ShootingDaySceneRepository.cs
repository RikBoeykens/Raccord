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
            var query = GetIncludedScene();

            return query.Where(sd=> sd.ShootingDayID == dayID);
        }

        public IEnumerable<ShootingDayScene> GetAllForDate(DateTime date)
        {
            var query = GetIncludedScene();

            return query.Where(sd=> sd.ShootingDay.Date == date);
        }

        public IEnumerable<ShootingDayScene> GetAllForScene(long sceneID)
        {
            var query = GetIncludedDay();

            return query.Where(sd=> sd.SceneID == sceneID);
        }

        public IEnumerable<ShootingDayScene> GetAllBeforeDate(DateTime date)
        {
            var query = GetIncluded();

            return query.Where(sds=> sds.ShootingDay.Date > date);
        }

        private IQueryable<ShootingDayScene> GetIncludedScene()
        {
            IQueryable<ShootingDayScene> query = _context.Set<ShootingDayScene>();

            return query.Include(sd=> sd.ShootingDay)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.ShootingDayScenes)
                        .ThenInclude(sds=> sds.ShootingDay)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .ThenInclude(sl=> sl.LocationSets)
                        .ThenInclude(ls=> ls.Location)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.DayNight)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(s=> s.Image)
                        .Include(ss=> ss.CallsheetScene)
                        .Include(ss=> ss.LocationSet)
                        .ThenInclude(ls=> ls.Location);
        }

        private IQueryable<ShootingDayScene> GetIncludedDay()
        {
            IQueryable<ShootingDayScene> query = _context.Set<ShootingDayScene>();

            return query.Include(sd=> sd.ShootingDay);
        }

        private IQueryable<ShootingDayScene> GetIncluded()
        {
            IQueryable<ShootingDayScene> query = _context.Set<ShootingDayScene>();

            return query.Include(sds=> sds.ShootingDay);
        }
    }
}
