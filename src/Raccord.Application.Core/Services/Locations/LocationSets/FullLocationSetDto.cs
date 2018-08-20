using System.Collections.Generic;
using Raccord.Application.Core.Services.Comments;
using Raccord.Application.Core.Services.Locations.Locations;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;
using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Application.Core.Services.ShootingDays;

namespace Raccord.Application.Core.Services.Locations.LocationSets
{
    // Dto to represent a full schedule scene
    public class FullLocationSetDto : LocationSetSummaryDto
    {
        private IEnumerable<ShootingDayInfoSceneCollectionDto> _shootingDays;
        private IEnumerable<CommentDto> _comments;

        // Schedule days linked to the location set
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

        // Comments linked to the location set
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