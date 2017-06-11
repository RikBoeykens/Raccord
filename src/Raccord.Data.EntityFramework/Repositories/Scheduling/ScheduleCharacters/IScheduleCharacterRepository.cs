using System.Collections.Generic;
using Raccord.Domain.Model.Scheduling;

namespace Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleCharacters
{
    // Interface defining a repository for schedule characters
    public interface IScheduleCharacterRepository : IBaseRepository<ScheduleCharacter>
    {
        IEnumerable<ScheduleCharacter> GetAllForScheduleScene(long scheduleSceneID);
        IEnumerable<ScheduleCharacter> GetAllForCharacter(long characterID);
    }
}