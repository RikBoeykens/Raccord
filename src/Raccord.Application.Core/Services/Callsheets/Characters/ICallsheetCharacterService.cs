using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Callsheets.Characters
{
    public interface ICallsheetCharacterService
    {
        IEnumerable<CallsheetCharacterCharacterDto> GetCharacters(long callsheetID);
        void SetCharacters(long callsheetID, long projectID);
    }
}