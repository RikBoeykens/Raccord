using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Callsheets.Characters;

namespace Raccord.Data.EntityFramework.Repositories.Callsheets.Characters
{
    // Repository for call types
    public class CharacterCallRepository : BaseRepository<CharacterCall, long>, ICharacterCallRepository
    {
        public CharacterCallRepository(RaccordDBContext context) : base(context) 
        {
        }
    }
}
