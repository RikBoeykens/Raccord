using Raccord.Application.Core.Services.Images;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.Shots.Slates;
using Raccord.Application.Core.Services.ShootingDays;
using Raccord.Application.Core.Services.Breakdowns;

namespace Raccord.Application.Core.Services.Scenes
{
    // Dto to represent a full scene
    public class FullSceneDto : SceneDto
    {
        private IEnumerable<LinkedImageDto> _images;
        private IEnumerable<LinkedCharacterDto> _characters;
        private LinkedBreakdownDto _breakdownInfo;
        private IEnumerable<ShootingDayInfoDto> _shootingDays;
        private IEnumerable<SlateSummaryDto> _slates;

        // Images linked to the scene
        public IEnumerable<LinkedImageDto> Images
        {
            get
            {
                return _images ?? (_images = new List<LinkedImageDto>());
            }
            set
            {
                _images = value;
            }
        }

        // Characters linked to the scene
        public IEnumerable<LinkedCharacterDto> Characters
        {
            get
            {
                return _characters ?? (_characters = new List<LinkedCharacterDto>());
            }
            set
            {
                _characters = value;
            }
        }

        // Breakdown items linked to the scene
        public LinkedBreakdownDto BreakdownInfo
        {
            get
            {
                return _breakdownInfo ?? (_breakdownInfo = new LinkedBreakdownDto());
            }
            set
            {
                _breakdownInfo = value;
            }
        }

        // Days the scene is scheduled for
        public IEnumerable<ShootingDayInfoDto> ShootingDays
        {
            get
            {
                return _shootingDays ?? (_shootingDays = new List<ShootingDayInfoDto>());
            }
            set
            {
                _shootingDays = value;
            }
        }

        // Slates linked to the scene
        public IEnumerable<SlateSummaryDto> Slates
        {
            get
            {
                return _slates ?? (_slates = new List<SlateSummaryDto>());
            }
            set
            {
                _slates = value;
            }
        }
    }
}