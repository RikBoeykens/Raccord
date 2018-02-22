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
            var query = GetIncludedCallsheetScene();

            return query.Where(sc=> sc.CharacterScene.CharacterID == characterID);
        }

        public IEnumerable<CallsheetSceneCharacter> GetAllForCallsheet(long callsheetID)
        {
            var query = GetIncludedCallsheetCharacter();

            return query.Where(sc=> sc.CallsheetScene.CallsheetID == callsheetID);
        }

        private IQueryable<CallsheetSceneCharacter> GetIncludedCharacter()
        {
            IQueryable<CallsheetSceneCharacter> query = _context.Set<CallsheetSceneCharacter>();

            return query.Include(sc=> sc.CharacterScene)
                        .ThenInclude(cs=> cs.Character)
                        .ThenInclude(c=> c.ImageCharacters)
                        .ThenInclude(ic=> ic.Image)
                        .Include(cs=> cs.CharacterScene)
                        .ThenInclude(cc=> cc.Character)
                        .ThenInclude(cc => cc.CastMember)
                        .ThenInclude(cm => cm.ProjectUser)
                        .ThenInclude(cm => cm.User);
        }

        private IQueryable<CallsheetSceneCharacter> GetIncludedCallsheetScene()
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

        private IQueryable<CallsheetSceneCharacter> GetIncludedCallsheetCharacter()
        {
            IQueryable<CallsheetSceneCharacter> query = _context.Set<CallsheetSceneCharacter>();

            return query.Include(sc=> sc.CallsheetScene)
                        .ThenInclude(ss=> ss.Callsheet)
                        .Include(sc=> sc.CharacterScene)
                        .ThenInclude(cs=> cs.Character)
                        .ThenInclude(c=> c.ImageCharacters)
                        .ThenInclude(ic=> ic.Image)
                        .Include(cs=> cs.CharacterScene)
                        .ThenInclude(cc=> cc.Character)
                        .ThenInclude(cc => cc.CastMember)
                        .ThenInclude(cm => cm.ProjectUser)
                        .ThenInclude(cm => cm.User);
        }
    }
}
