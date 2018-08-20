using System.Collections.Generic;
using Raccord.Application.Core.Services.Comments;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;
using Raccord.Application.Core.Services.ShootingDays;

namespace Raccord.Application.Core.Services.Locations.Locations
{
    // Dto to represent a full location
    public class FullLocationDto: LocationDto
    {
        private IEnumerable<LocationSetScriptLocationDto> _sets;
        private IEnumerable<ShootingDayInfoSceneCollectionDto> _shootingDays;
        private IEnumerable<CommentDto> _comments;

        // Sets linked to the location
        public IEnumerable<LocationSetScriptLocationDto> Sets
        {
            get
            {
                return _sets ?? (_sets = new List<LocationSetScriptLocationDto>());
            }
            set
            {
                _sets = value;
            }
        }

        // Schedule days linked to the location
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