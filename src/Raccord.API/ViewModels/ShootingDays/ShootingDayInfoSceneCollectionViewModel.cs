using System;
using System.Collections.Generic;
using Raccord.API.ViewModels.ShootingDays.Scenes;

namespace Raccord.API.ViewModels.ShootingDays
{
    // Vm to represent info about a shooting day
    public class ShootingDayInfoSceneCollectionViewModel : ShootingDayInfoViewModel
    {
        private IEnumerable<ShootingDaySceneSummaryViewModel> _scenes;

        public IEnumerable<ShootingDaySceneSummaryViewModel> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<ShootingDaySceneSummaryViewModel>());
            }
            set
            {
                _scenes = value;
            }
        }
    }
}