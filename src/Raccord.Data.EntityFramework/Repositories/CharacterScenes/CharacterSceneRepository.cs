using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Characters;

namespace Raccord.Data.EntityFramework.Repositories.CharacterScenes
{
    // Repository for character scenes
    public class CharacterSceneRepository : BaseRepository<CharacterScene>, ICharacterSceneRepository
    {
        public CharacterSceneRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<CharacterScene> GetAllForScene(long sceneID)
        {
            var query = GetIncludedCharacter();

            return query.Where(l=> l.SceneID == sceneID);
        }

        private IQueryable<CharacterScene> GetIncludedCharacter()
        {
            IQueryable<CharacterScene> query = _context.Set<CharacterScene>();

            return query.Include(i=> i.Character)
                        .ThenInclude(i=> i.ImageCharacters)
                        .ThenInclude(ic=> ic.Image);
        }
    }
}
