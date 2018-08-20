using System.Collections.Generic;
using Raccord.API.ViewModels.Comments;
using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.Scheduling.ScheduleDays;
using Raccord.API.ViewModels.ShootingDays;

namespace Raccord.API.ViewModels.Locations.Locations
{
    // Vm to represent a full location
    public class FullLocationViewModel: LocationViewModel
    {
        private IEnumerable<LocationSetScriptLocationViewModel> _sets;
        private IEnumerable<ShootingDayInfoSceneCollectionViewModel> _shootingDays;
        private IEnumerable<CommentViewModel> _comments;

        // Scenes scheduled for the day
        public IEnumerable<LocationSetScriptLocationViewModel> Sets
        {
            get
            {
                return _sets ?? (_sets = new List<LocationSetScriptLocationViewModel>());
            }
            set
            {
                _sets = value;
            }
        }

        // Schedule scenes linked to the location
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