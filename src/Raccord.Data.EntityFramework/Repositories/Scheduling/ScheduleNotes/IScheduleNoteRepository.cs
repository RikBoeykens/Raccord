using Raccord.Domain.Model.Scheduling;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleDayNotes
{
    // Interface defining a repository for Int/Ext
    public interface IScheduleDayNoteRepository : IBaseRepository<ScheduleDayNote>
    {
        IEnumerable<ScheduleDayNote> GetAllForScheduleDay(long dayID);
        ScheduleDayNote GetFull(long ID);
        ScheduleDayNote GetSummary(long ID);
    }
}