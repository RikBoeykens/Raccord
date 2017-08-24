using System;

namespace Raccord.API.ViewModels.ShootingDays.Scenes
{
    // Dto to represent a scene on a shooting day
    public class ShootingDaySceneViewModel : BaseShootingDaySceneViewModel
    {
        // ID of the linked shooting day
        public long ShootingDayID { get; set; }

        // ID of the linked scene
        public long SceneID { get; set; }

        // ID of the location set
        public long? LocationSetID { get; set; }
    }
}