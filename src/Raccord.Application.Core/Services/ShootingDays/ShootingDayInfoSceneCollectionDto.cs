using System;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Crew.CrewUnits;
using Raccord.Application.Core.Services.ShootingDays.Scenes;

namespace Raccord.Application.Core.Services.ShootingDays
{
    // Dto to represent info about a shooting day
    public class ShootingDayInfoSceneCollectionDto : ShootingDayInfoDto
    {
        private IEnumerable<ShootingDaySceneSummaryDto> _scenes;

        public IEnumerable<ShootingDaySceneSummaryDto> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<ShootingDaySceneSummaryDto>());
            }
            set
            {
                _scenes = value;
            }
        }
    }
}