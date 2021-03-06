using System.Collections.Generic;
using System.Threading.Tasks;
using Raccord.Application.Core.Common.Sorting;

namespace Raccord.Application.Core.Services.Scheduling.ScheduleScenes
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
        Task SortAsync(SortOrderDto order);
    }
}