using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Callsheets.Scenes;

namespace Raccord.Data.EntityFramework.Repositories.Callsheets.Scenes
{
    // Repository for character scenes
    public class CallsheetSceneCharacterRepository : BaseRepository<CallsheetSceneCharacter>, ICallsheetSceneCharacterRepository
    {
        public CallsheetSceneCharacterRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<CallsheetSceneCharacter> GetAllForCallsheetScene(long callsheetSceneID)
        {
            var query = GetIncludedCharacter();

            return query.Where(sc=> sc.CallsheetSceneID == callsheetSceneID);
        }

        public IEnumerable<CallsheetSceneCharacter> GetAllForCharacter(long characterID)
        {
            var query = GetIncludedScheduleScene();

            return query.Where(sc=> sc.CharacterScene.CharacterID == characterID);
        }

        private IQueryable<CallsheetSceneCharacter> GetIncludedCharacter()
        {
            IQueryable<CallsheetSceneCharacter> query = _context.Set<CallsheetSceneCharacter>();

            return query.Include(sc=> sc.CharacterScene)
                        .ThenInclude(cs=> cs.Character)
                        .ThenInclude(c=> c.ImageCharacters)
                        .ThenInclude(ic=> ic.Image);
        }

        private IQueryable<CallsheetSceneCharacter> GetIncludedScheduleScene()
        {
            IQueryable<CallsheetSceneCharacter> query = _context.Set<CallsheetSceneCharacter>();

            return query.Include(sc=> sc.CallsheetScene)
                        .ThenInclude(ss=> ss.Callsheet)
                        .ThenInclude(sd=> sd.ShootingDay)
                        .Include(sc=> sc.CallsheetScene)
                        .ThenInclude(cs=> cs.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(sc=> sc.CallsheetScene)
                        .ThenInclude(cs=> cs.Scene)
                        .ThenInclude(s=> s.DayNight)
                        .Include(sc=> sc.CallsheetScene)
                        .ThenInclude(cs=> cs.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(sc=> sc.CallsheetScene)
                        .ThenInclude(cs=> cs.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(i=> i.Image);
        }
    }
}
