using System.Collections.Generic;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.Scheduling.ScheduleScenes;

namespace Raccord.Application.Core.Services.Scheduling.ScheduleCharacters
{
    // Interface for character schedule functionality
    public interface IScheduleCharacterService
    {
        IEnumerable<LinkedCharacterDto> GetCharacters(long ID);
        IEnumerable<LinkedScheduleSceneDto> GetScheduleScenes(long ID);

        // Links a character to a schedule scene
        void AddLink(long scheduleSceneID, long characterSceneID);

        // Removes link between character and scene
        void RemoveLink(long ID);
    }
}