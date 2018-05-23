using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Images;

namespace Raccord.Data.EntityFramework.Repositories.ImageCharacters
{
    // Repository for image characters
    public class ImageCharacterRepository : BaseRepository<ImageCharacter, long>, IImageCharacterRepository
    {
        public ImageCharacterRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<ImageCharacter> GetAllForCharacter(long characterID)
        {
            var query = GetIncludedImage();

            return query.Where(l=> l.CharacterID == characterID);
        }

        private IQueryable<ImageCharacter> GetIncludedImage()
        {
            IQueryable<ImageCharacter> query = _context.Set<ImageCharacter>();

            return query.Include(i=> i.Image);
        }
    }
}
