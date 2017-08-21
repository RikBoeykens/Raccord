using System;

namespace Raccord.Application.Core.Services.ShootingDays.Scenes
{
    // Dto to represent a scene on a shooting day
    public class BaseShootingDaySceneDto
    {
        // ID of the shooting day scene
        public long ID { get; set; }

        // Length in eights
        public int PageLength { get; set; }

        // Length in time
        public TimeSpan Timings { get; set; }
    }
}