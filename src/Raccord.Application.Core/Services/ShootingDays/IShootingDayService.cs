using System.Collections.Generic;

namespace Raccord.Application.Core.Services.ShootingDays
{
    public interface IShootingDayService
    {
        IEnumerable<ShootingDayDto> GetAvailableDays(long projectID);
        IEnumerable<ShootingDayDto> GetAll(long projectID);
    }
}