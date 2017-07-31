using Raccord.Domain.Model.Scheduling;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleDays
{
    // Interface defining a repository for Int/Ext
    public interface IScheduleDayRepository : IBaseRepository<ScheduleDay>
    {
        IEnumerable<ScheduleDay> GetAllForProject(long projectID);
        IEnumerable<ScheduleDay> GetAllWithScenesForProject(long projectID);
        ScheduleDay GetFull(long ID);
        ScheduleDay GetSummary(long ID);
    }
}