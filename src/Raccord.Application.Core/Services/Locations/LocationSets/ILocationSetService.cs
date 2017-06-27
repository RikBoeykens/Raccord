using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Locations.LocationSets
{
    // Interface for location functionality
    public interface IScheduleSceneService
    {
        IEnumerable<ScheduleSceneDayDto> GetDays(long sceneID);

        IEnumerable<ScheduleSceneSceneDto> GetScenes(long dayID);

        FullScheduleSceneDto Get(long ID);

        long Add(ScheduleSceneDto dto);

        long Update(ScheduleSceneDto dto);

        void Delete(long ID);
    }
}