using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Callsheets.Characters;

namespace Raccord.Data.EntityFramework.Repositories.Callsheets.Characters
{
    // Repository for breakdown type definitions
    public class CallsheetCharacterRepository : BaseRepository<CallsheetCharacter>, ICallsheetCharacterRepository
    {
        public CallsheetCharacterRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<CallsheetCharacter> GetAllForCallsheet(long ID)
        {
            var query = GetIncludedSummary();

            return query.Where(l=> l.CallsheetID == ID);
        }
        
        private IQueryable<CallsheetCharacter> GetIncludedSummary()
        {
            IQueryable<CallsheetCharacter> query = _context.Set<CallsheetCharacter>();

            return query.Include(cc=> cc.CharacterCalls)
                        .ThenInclude(cc=> cc.CallType)
                        .Include(cc=> cc.Character)
                        .ThenInclude(c=> c.ImageCharacters)
                        .ThenInclude(ic=> ic.Image);
        }
    }
}
