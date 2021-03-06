using System;

namespace Raccord.Application.Core.Services.ShootingDays.Scenes
{
    // Dto to represent a scene on a shooting day
    public class ShootingDaySceneDto : BaseShootingDaySceneDto
    {
        // ID of the linked shooting day
        public long ShootingDayID { get; set; }

        // ID of the linked scene
        public long SceneID { get; set; }

        // ID of the linked location set
        public long? LocationSetID { get; set; }
    }
}