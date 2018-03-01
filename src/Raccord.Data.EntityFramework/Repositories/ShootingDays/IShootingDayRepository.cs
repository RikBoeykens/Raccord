using Raccord.Domain.Model.ShootingDays;
using System.Collections.Generic;
using System;

namespace Raccord.Data.EntityFramework.Repositories.ShootingDays
{
    // Interface defining a repository for Int/Ext
    public interface IShootingDayRepository : IBaseRepository<ShootingDay>
    {
        IEnumerable<ShootingDay> GetAllForCrewUnit(long crewUnitID);
        IEnumerable<ShootingDay> GetAllForProject(long projectID);
        IEnumerable<ShootingDay> GetAllBeforeDate(long crewUnitID, DateTime date);
        ShootingDay GetFull(long ID);
        ShootingDay GetSummary(long ID);
        int SearchCount(string searchText, long? projectID);
        IEnumerable<ShootingDay> Search(string searchText, long? projectID);
        IEnumerable<ShootingDay> GetAllForScene(long sceneID);
    }
}