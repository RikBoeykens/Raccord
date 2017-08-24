using System;

namespace Raccord.API.ViewModels.ShootingDays
{
    // Dto to represent a shooting day
    public class ShootingDaySummaryViewModel : ShootingDayViewModel
    {
        // Total count of scenes
        public int TotalScenes { get; set; }

        // Total count of completed scenes
        public int CompletedScenes { get; set; }

        // Total page count
        public int TotalPageCount { get; set; }

        // Total timings
        public TimeSpan TotalTimings { get; set; }
    }
}