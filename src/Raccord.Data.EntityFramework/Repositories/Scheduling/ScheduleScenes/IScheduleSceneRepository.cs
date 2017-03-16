using Raccord.Domain.Model.Scheduling;
using System.Collections.Generic;
using System;

namespace Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleScenes
{
    // Interface defining a repository for Int/Ext
    public interface IScheduleSceneRepository : IBaseRepository<ScheduleScene>
    {
        IEnumerable<ScheduleScene> GetAllForScheduleDay(long dayID);
        IEnumerable<ScheduleScene> GetAllForScheduleDate(DateTime date);
        IEnumerable<ScheduleScene> GetAllForScene(long sceneID);
        ScheduleScene GetFull(long ID);
        ScheduleScene GetSummary(long ID);
    }
}