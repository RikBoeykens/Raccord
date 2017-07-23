using System.Linq;
using Raccord.API.ViewModels.Callsheets.CharacterCalls;
using Raccord.API.ViewModels.Characters;
using Raccord.Application.Core.Services.Callsheets.Characters;

namespace Raccord.API.ViewModels.Callsheets.Characters
{
    public static class Utilities
    {
        public static CallsheetCharacterCharacterViewModel Translate(this CallsheetCharacterCharacterDto dto)
        {
            return new CallsheetCharacterCharacterViewModel
            {
                ID = dto.ID,
                Character = dto.Character.Translate(),
                Calls = dto.Calls.Select(c=> c.Translate()),
            };
        }
    }
}