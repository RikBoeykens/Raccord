using System;
using Raccord.Core.Enums;

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

        // Indicates if the shooting day scene completes the scene
        public Completion Completion { get; set; }

        public long? CallsheetSceneID { get; set; }
    }
}