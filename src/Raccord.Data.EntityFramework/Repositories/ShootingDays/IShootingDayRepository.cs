using Raccord.Domain.Model.ShootingDays;
using System.Collections.Generic;
using System;

namespace Raccord.Data.EntityFramework.Repositories.ShootingDays
{
    // Interface defining a repository for Int/Ext
    public interface IShootingDayRepository : IBaseRepository<ShootingDay>
    {
        IEnumerable<ShootingDay> GetAllForProject(long projectID);
        IEnumerable<ShootingDay> GetAllBeforeDate(long projectID, DateTime date);
        ShootingDay GetFull(long ID);
        ShootingDay GetSummary(long ID);
        int SearchCount(string searchText, long? projectID);
        IEnumerable<ShootingDay> Search(string searchText, long? projectID);
    }
}