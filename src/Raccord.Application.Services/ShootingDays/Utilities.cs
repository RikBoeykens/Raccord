using Raccord.Application.Core.Services.ShootingDays;
using Raccord.Domain.Model.ShootingDays;

namespace Raccord.Application.Services.ShootingDays
{
    public static class Utilities
    {
        public static ShootingDayDto Translate(this ShootingDay shootingDay)
        {
            return new ShootingDayDto
            {
                ID = shootingDay.ID,
                Number = shootingDay.Number,
                Date = shootingDay.Date,
                CallsheetID = shootingDay.CallsheetID,
                ProjectID = shootingDay.ProjectID
            };
        }
    }
}