using System.Collections.Generic;
using Raccord.Application.Core.Services.Characters;

namespace Raccord.Application.Core.Services.CharacterScenes
{
    // Interface for character scene functionality
    public interface ICharacterSceneService
    {
        IEnumerable<LinkedCharacterDto> GetCharacters(long ID);

        // Links a character to a scene
        void AddLink(long imageID, long sceneID);

        // Removes link between character and scene
        void RemoveLink(long ID);
    }
}