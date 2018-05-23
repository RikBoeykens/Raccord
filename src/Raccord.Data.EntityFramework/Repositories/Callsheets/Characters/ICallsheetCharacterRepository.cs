using System.Collections.Generic;
using Raccord.Domain.Model.Callsheets.Characters;

namespace Raccord.Data.EntityFramework.Repositories.Callsheets.Characters
{
    // Interface defining a repository for Call type definitions
    public interface ICallsheetCharacterRepository : IBaseRepository<CallsheetCharacter, long>
    {
        IEnumerable<CallsheetCharacter> GetAllForCallsheet(long ID);
    }
}