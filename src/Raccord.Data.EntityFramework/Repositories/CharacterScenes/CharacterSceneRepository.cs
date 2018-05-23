using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Characters;

namespace Raccord.Data.EntityFramework.Repositories.CharacterScenes
{
    // Repository for character scenes
    public class CharacterSceneRepository : BaseRepository<CharacterScene, long>, ICharacterSceneRepository
    {
        public CharacterSceneRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<CharacterScene> GetAllForScene(long sceneID)
        {
            var query = GetIncludedCharacter();

            return query.Where(l=> l.SceneID == sceneID);
        }

        public IEnumerable<CharacterScene> GetAllForCharacter(long characterID)
        {
            var query = GetIncludedScene();

            return query.Where(l=> l.CharacterID == characterID);
        }

        private IQueryable<CharacterScene> GetIncludedCharacter()
        {
            IQueryable<CharacterScene> query = _context.Set<CharacterScene>();

            return query.Include(cs=> cs.Character)
                        .ThenInclude(c=> c.ImageCharacters)
                        .ThenInclude(ic=> ic.Image);
        }

        private IQueryable<CharacterScene> GetIncludedScene()
        {
            IQueryable<CharacterScene> query = _context.Set<CharacterScene>();

            return query.Include(cs=> cs.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(cs=> cs.Scene)
                        .ThenInclude(s=> s.DayNight)
                        .Include(cs=> cs.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(cs=> cs.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(i=> i.Image);
        }
    }
}
