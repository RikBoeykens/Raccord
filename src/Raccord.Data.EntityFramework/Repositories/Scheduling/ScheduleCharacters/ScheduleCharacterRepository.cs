using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Scheduling;

namespace Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleCharacters
{
    // Repository for character scenes
    public class ScheduleCharacterRepository : BaseRepository<ScheduleCharacter>, IScheduleCharacterRepository
    {
        public ScheduleCharacterRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<ScheduleCharacter> GetAllForScheduleScene(long scheduleSceneID)
        {
            var query = GetIncludedCharacter();

            return query.Where(sc=> sc.ScheduleSceneID == scheduleSceneID);
        }

        public IEnumerable<ScheduleCharacter> GetAllForCharacter(long characterID)
        {
            var query = GetIncludedScheduleScene();

            return query.Where(sc=> sc.CharacterScene.CharacterID == characterID);
        }

        private IQueryable<ScheduleCharacter> GetIncludedCharacter()
        {
            IQueryable<ScheduleCharacter> query = _context.Set<ScheduleCharacter>();

            return query.Include(sc=> sc.CharacterScene)
                        .ThenInclude(cs=> cs.Character)
                        .ThenInclude(c=> c.ImageCharacters)
                        .ThenInclude(ic=> ic.Image);
        }

        private IQueryable<ScheduleCharacter> GetIncludedScheduleScene()
        {
            IQueryable<ScheduleCharacter> query = _context.Set<ScheduleCharacter>();

            return query.Include(sc=> sc.ScheduleScene)
                        .ThenInclude(ss=> ss.ScheduleDay)
                        .ThenInclude(sd=> sd.ShootingDay)
                        .Include(sc=> sc.ScheduleScene)
                        .ThenInclude(cs=> cs.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(sc=> sc.ScheduleScene)
                        .ThenInclude(cs=> cs.Scene)
                        .ThenInclude(s=> s.DayNight)
                        .Include(sc=> sc.ScheduleScene)
                        .ThenInclude(cs=> cs.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(sc=> sc.ScheduleScene)
                        .ThenInclude(cs=> cs.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(i=> i.Image);
        }
    }
}
