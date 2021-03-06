using Raccord.Domain.Model.ShootingDays.Scenes;
using System.Collections.Generic;
using System;

namespace Raccord.Data.EntityFramework.Repositories.ShootingDays.Scenes
{
    // Interface defining a repository for Int/Ext
    public interface IShootingDaySceneRepository : IBaseRepository<ShootingDayScene, long>
    {
        IEnumerable<ShootingDayScene> GetAllForShootingDay(long dayID);
        IEnumerable<ShootingDayScene> GetAllForDate(DateTime date);
        IEnumerable<ShootingDayScene> GetAllForScene(long sceneID);
        IEnumerable<ShootingDayScene> GetAllBeforeDate(DateTime date);
    }
}