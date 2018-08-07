using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Images;
using Raccord.Application.Core.Services.Scheduling.ScheduleScenes;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;
using Raccord.Application.Core.Services.Cast;
using Raccord.Application.Core.Services.Comments;
using Raccord.Application.Core.Services.ShootingDays;

namespace Raccord.Application.Core.Services.Characters
{
    // Dto to represent a full character
    public class FullCharacterDto: CharacterDto
    {
        private IEnumerable<LinkedSceneDto> _scenes;
        private IEnumerable<LinkedImageDto> _images;
        private IEnumerable<ShootingDayInfoSceneCollectionDto> _shootingDays;
        private CastMemberSummaryDto _castMember;
        private IEnumerable<CommentDto> _comments;

        // Scenes linked to the character
        public IEnumerable<LinkedSceneDto> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<LinkedSceneDto>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Images linked to the character
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

        // Schedule days linked to the character
        public IEnumerable<ShootingDayInfoSceneCollectionDto> ShootingDays
        {
            get
            {
                return _shootingDays ?? (_shootingDays = new List<ShootingDayInfoSceneCollectionDto>());
            }
            set
            {
                _shootingDays = value;
            }
        }

        public CastMemberSummaryDto CastMember
        {
            get
            {
                return _castMember ?? (_castMember = new CastMemberSummaryDto());
            }
            set
            {
                _castMember = value;
            }
        }

        // Comments linked to the breakdown item
        public IEnumerable<CommentDto> Comments
        {
            get
            {
                return _comments ?? (_comments = new List<CommentDto>());
            }
            set
            {
                _comments = value;
            }
        }
    }
}