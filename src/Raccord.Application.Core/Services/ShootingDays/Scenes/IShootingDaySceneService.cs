using System.Collections.Generic;

namespace Raccord.Application.Core.Services.ShootingDays.Scenes
{
    // Interface for shooting day scene functionality
    public interface IShootingDaySceneService
    {
        IEnumerable<ShootingDaySceneDayDto> GetDays(long sceneID);

        IEnumerable<ShootingDaySceneSceneDto> GetScenes(long dayID);

        long Add(ShootingDaySceneDto dto);

        long Update(ShootingDaySceneDto dto);

        void Delete(long ID);
    }
}