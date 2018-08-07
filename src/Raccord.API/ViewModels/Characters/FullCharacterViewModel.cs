using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Images;
using System.Collections.Generic;
using Raccord.API.ViewModels.Scheduling.ScheduleScenes;
using Raccord.API.ViewModels.Scheduling.ScheduleDays;
using Raccord.API.ViewModels.Profile;
using Raccord.API.ViewModels.Cast;
using Raccord.API.ViewModels.Comments;
using Raccord.API.ViewModels.ShootingDays;

namespace Raccord.API.ViewModels.Characters
{
    // ViewModel to represent a character
    public class FullCharacterViewModel : CharacterViewModel
    {
        private IEnumerable<LinkedSceneViewModel> _scenes;
        private IEnumerable<LinkedImageViewModel> _images;
        private IEnumerable<ShootingDayInfoSceneCollectionViewModel> _shootingDays;
        private CastMemberSummaryViewModel _castMember;
        private IEnumerable<CommentViewModel> _comments;

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
        public IEnumerable<ShootingDayInfoSceneCollectionViewModel> ShootingDays
        {
            get
            {
                return _shootingDays ?? (_shootingDays = new List<ShootingDayInfoSceneCollectionViewModel>());
            }
            set
            {
                _shootingDays = value;
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

        // comments linked
        public IEnumerable<CommentViewModel> Comments
        {
            get
            {
                return _comments ?? (_comments = new List<CommentViewModel>());
            }
            set
            {
                _comments = value;
            }
        }
    }
}