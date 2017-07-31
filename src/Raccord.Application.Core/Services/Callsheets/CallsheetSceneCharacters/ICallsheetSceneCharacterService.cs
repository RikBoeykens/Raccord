using System.Collections.Generic;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.Callsheets.CallsheetScenes;

namespace Raccord.Application.Core.Services.Callsheets.CallsheetSceneCharacters
{
    // Interface for callsheet scene character functionality
    public interface ICallsheetSceneCharacterService
    {
        IEnumerable<LinkedCharacterDto> GetCharacters(long ID);
        IEnumerable<LinkedCallsheetSceneDto> GetCallsheetScenes(long ID);

        // Links a character to a callsheet scene
        long AddLink(long callsheetSceneID, long characterSceneID);

        // Removes link between character and scene
        void RemoveLink(long ID);
    }
}