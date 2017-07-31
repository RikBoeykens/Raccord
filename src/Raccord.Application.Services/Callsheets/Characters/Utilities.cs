using System.Linq;
using Raccord.Application.Core.Services.Callsheets.Characters;
using Raccord.Application.Services.Callsheets.CharacterCalls;
using Raccord.Application.Services.Characters;
using Raccord.Domain.Model.Callsheets.Characters;

namespace Raccord.Application.Services.Callsheets.Characters
{
    public static class Utilities
    {
        public static CallsheetCharacterCharacterDto TranslateCharacter(this CallsheetCharacter callsheetCharacter)
        {
            return new CallsheetCharacterCharacterDto
            {
                ID = callsheetCharacter.ID,
                Character = callsheetCharacter.Character.TranslateSummary(),
                Calls = callsheetCharacter.CharacterCalls.OrderBy(cc=> cc.CallType.SortingOrder).Select(c=> c.TranslateCallType())
            };
        }
    }
}