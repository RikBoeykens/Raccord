using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Images;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Breakdowns.BreakdownTypes;
using Raccord.Application.Core.Services.Comments;
using Raccord.Application.Core.Services.ShootingDays;

namespace Raccord.Application.Core.Services.Breakdowns.BreakdownItems
{
    // Dto to represent a full breakdown item
    public class FullBreakdownItemDto: BaseBreakdownItemDto
    {
        private BreakdownSummaryDto _breakdown;
        private BreakdownTypeDto _type;
        private IEnumerable<LinkedSceneDto> _scenes;
        private IEnumerable<LinkedImageDto> _images;
        private IEnumerable<CommentDto> _comments;
        private IEnumerable<ShootingDayInfoSceneCollectionDto> _shootingDays;

        // Scenes linked to the breakdown item
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

        // Images linked to the breakdown item
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

        /// <summary>
        /// Breakdown linked to the item
        /// </summary>
        /// <returns></returns>
        public BreakdownSummaryDto Breakdown
        {
            get
            {
                return _breakdown ?? (_breakdown = new BreakdownSummaryDto());
            }
            set
            {
                _breakdown = value;
            }
        }

        /// <summary>
        /// Breakdown type linked to the item
        /// </summary>
        /// <returns></returns>
        public BreakdownTypeDto Type
        {
            get
            {
                return _type ?? (_type = new BreakdownTypeDto());
            }
            set
            {
                _type = value;
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

        // Shooting Days linked to the breakdown item
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
    }
}