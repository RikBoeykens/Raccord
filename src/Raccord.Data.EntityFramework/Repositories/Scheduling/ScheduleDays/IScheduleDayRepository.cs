using Raccord.Domain.Model.Scheduling;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleDays
{
    // Interface defining a repository for Int/Ext
    public interface IScheduleDayRepository : IBaseRepository<ScheduleDay, long>
    {
        IEnumerable<ScheduleDay> GetAllForCrewUnit(long crewUnitID);
        IEnumerable<ScheduleDay> GetAllForCharacters(long[] characterIds);
        IEnumerable<ScheduleDay> GetAllWithScenesForCrewUnit(long crewUnitID);
        ScheduleDay GetFull(long ID);
        ScheduleDay GetSummary(long ID);
    }
}