using System.Collections.Generic;
using Raccord.Domain.Model.Images;

namespace Raccord.Data.EntityFramework.Repositories.ImageCharacters
{
    // Interface defining a repository for Image Characters
    public interface IImageCharacterRepository : IBaseRepository<ImageCharacter>
    {
        IEnumerable<ImageCharacter> GetAllForCharacter(long characterID);
    }
}