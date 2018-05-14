using System;

namespace Raccord.Application.Core.Services.ShootingDays
{
    // Dto to represent a shooting day
    public class ShootingDaySummaryDto : BaseShootingDayDto
    {
        // Total count of scenes
        public int TotalScenes { get; set; }

        // Total count of completed scenes
        public int CompletedScenes { get; set; }

        // Total page count
        public int TotalPageCount { get; set; }

        // Total timings
        public TimeSpan TotalTimings { get; set; }

        // Total setups
        public int TotalSetups { get; set; }
        public long CrewUnitID { get; set; }
    }
}