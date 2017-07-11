using Raccord.Domain.Model.Callsheets.Scenes;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Raccord.Data.EntityFramework.Repositories.Callsheets.Scenes
{
    // Repository for CallsheetScene
    public class CallsheetSceneRepository : BaseRepository<CallsheetScene>, ICallsheetSceneRepository
    {
        public CallsheetSceneRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<CallsheetScene> GetAllForCallsheet(long callsheetID)
        {
            var query = GetIncludedSummary();

            return query.Where(sd=> sd.CallsheetID == callsheetID);
        }

        public IEnumerable<CallsheetScene> GetAllForScene(long sceneID)
        {
            var query = GetIncludedSummary();

            return query.Where(sd=> sd.SceneID == sceneID);
        }

        public CallsheetScene GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(sd => sd.ID == ID);
        }

        public CallsheetScene GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(sd => sd.ID == ID);
        }

        private IQueryable<CallsheetScene> GetIncludedFull()
        {
            IQueryable<CallsheetScene> query = _context.Set<CallsheetScene>();

            return query.Include(ss=> ss.Callsheet)
                        .ThenInclude(sd=> sd.ShootingDay)
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
                        .Include(ss=> ss.Characters)
                        .ThenInclude(cs=> cs.CharacterScene)
                        .ThenInclude(cs=> cs.Character)
                        .ThenInclude(c=> c.ImageCharacters)
                        .ThenInclude(ic=> ic.Image)
                        .Include(ss=> ss.LocationSet)
                        .ThenInclude(ls=> ls.Location);
        }

        private IQueryable<CallsheetScene> GetIncludedSummary()
        {
            IQueryable<CallsheetScene> query = _context.Set<CallsheetScene>();

            return query.Include(ss=> ss.Callsheet)
                        .ThenInclude(sd=> sd.ShootingDay)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.DayNight)
                        .Include(ss=> ss.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(s=> s.Image)
                        .Include(ss=> ss.Characters)
                        .ThenInclude(cs=> cs.CharacterScene)
                        .ThenInclude(cs=> cs.Character)
                        .ThenInclude(c=> c.ImageCharacters)
                        .ThenInclude(ic=> ic.Image);
        }

        private IQueryable<CallsheetScene> GetIncluded()
        {
            IQueryable<CallsheetScene> query = _context.Set<CallsheetScene>();

            return query;
        }
    }
}