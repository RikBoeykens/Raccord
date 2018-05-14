using System;

namespace Raccord.Application.Core.Services.Scheduling.ScheduleDays
{
    // Dto to represent a day in a schedule
    public class ScheduleDayDto : BaseScheduleDayDto
    {
        // ID of the project
        public long CrewUnitID { get; set; }
    }
}