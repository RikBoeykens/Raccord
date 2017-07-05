using Raccord.Application.Core.Services.ShootingDays;

namespace Raccord.API.ViewModels.ShootingDays
{
    public static class Utilities
    {
        public static ShootingDayViewModel Translate(this ShootingDayDto dto)
        {
            return new ShootingDayViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Date = dto.Date,
                ProjectID = dto.ProjectID,
            };
        }
    }
}