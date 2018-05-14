using System;

namespace Raccord.API.ViewModels.Scheduling.ScheduleDays
{
    // Dto to represent a day in a schedule
    public class ScheduleDayViewModel : BaseScheduleDayViewModel
    {
        // ID of the project
        public long CrewUnitID { get; set; }
    }
}