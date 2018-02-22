using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Images;
using System.Collections.Generic;
using Raccord.API.ViewModels.Scheduling.ScheduleScenes;
using Raccord.API.ViewModels.Scheduling.ScheduleDays;
using Raccord.API.ViewModels.Profile;
using Raccord.API.ViewModels.Cast;

namespace Raccord.API.ViewModels.Characters
{
    // ViewModel to represent a character
    public class FullCharacterViewModel : CharacterViewModel
    {
        private IEnumerable<LinkedSceneViewModel> _scenes;
        private IEnumerable<LinkedImageViewModel> _images;
        private IEnumerable<ScheduleDaySceneCollectionViewModel> _scheduleDays;
        private CastMemberSummaryViewModel _castMember;

        // Scenes linked to the character
        public IEnumerable<LinkedSceneViewModel> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<LinkedSceneViewModel>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Images linked to the character
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

        // Schedule scenes linked to the character
        public IEnumerable<ScheduleDaySceneCollectionViewModel> ScheduleDays
        {
            get
            {
                return _scheduleDays ?? (_scheduleDays = new List<ScheduleDaySceneCollectionViewModel>());
            }
            set
            {
                _scheduleDays = value;
            }
        }

        public CastMemberSummaryViewModel CastMember
        {
            get
            {
                return _castMember ?? (_castMember = new CastMemberSummaryViewModel());
            }
            set
            {
                _castMember = value;
            }
        }
    }
}