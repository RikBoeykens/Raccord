using System;
using Raccord.Application.Core.Services.Scenes;

namespace Raccord.Application.Core.Services.ShootingDays.Scenes
{
    // Dto to represent a scene on a shooting day
    public class ShootingDaySceneSummaryDto : SceneSummaryDto
    {
        // ID of the linked shooting day
        public long LinkID { get; set; }
        public int ScheduledPageLength { get; set; }
    }
}