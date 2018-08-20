using System;
using Raccord.API.ViewModels.Scenes;

namespace Raccord.API.ViewModels.ShootingDays.Scenes
{
    // Vm to represent a scene on a shooting day
    public class ShootingDaySceneSummaryViewModel : SceneSummaryViewModel
    {
        // ID of the linked shooting day
        public long LinkID { get; set; }
        public int ScheduledPageLength { get; set; }
    }
}