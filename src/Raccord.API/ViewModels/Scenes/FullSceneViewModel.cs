using Raccord.API.ViewModels.Images;
using System.Collections.Generic;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Breakdowns.BreakdownItems;
using Raccord.API.ViewModels.Scheduling.ScheduleScenes;
using Raccord.API.ViewModels.Shots.Slates;
using Raccord.API.ViewModels.ShootingDays;

namespace Raccord.API.ViewModels.Scenes
{
    // Viewmodel to represent scene
    public class FullSceneViewModel : SceneViewModel
    {
        private IEnumerable<LinkedImageViewModel> _images;
        private IEnumerable<LinkedCharacterViewModel> _characters;
        private IEnumerable<LinkedBreakdownItemViewModel> _breakdownItems;
        private IEnumerable<ShootingDayInfoViewModel> _shootingDays;
        private IEnumerable<SlateSummaryViewModel> _slates;

        // Images linked to the scene
        public IEnumerable<LinkedImageViewModel> Images
        {
            get
            {
                return _images ?? (_images = new List<LinkedImageViewModel>());
            }
            set
            {
                _images = value;
            }
        }

        // Characters linked to the scene
        public IEnumerable<LinkedCharacterViewModel> Characters
        {
            get
            {
                return _characters ?? (_characters = new List<LinkedCharacterViewModel>());
            }
            set
            {
                _characters = value;
            }
        }

        // Breakdown items linked to the scene
        public IEnumerable<LinkedBreakdownItemViewModel> BreakdownItems
        {
            get
            {
                return _breakdownItems ?? (_breakdownItems = new List<LinkedBreakdownItemViewModel>());
            }
            set
            {
                _breakdownItems = value;
            }
        }

        // Shooting days linked to the scene
        public IEnumerable<ShootingDayInfoViewModel> ShootingDays
        {
            get
            {
                return _shootingDays ?? (_shootingDays = new List<ShootingDayInfoViewModel>());
            }
            set
            {
                _shootingDays = value;
            }
        }

        // Slates linked to the scene
        public IEnumerable<SlateSummaryViewModel> Slates
        {
            get
            {
                return _slates ?? (_slates = new List<SlateSummaryViewModel>());
            }
            set
            {
                _slates = value;
            }
        }
    }
}