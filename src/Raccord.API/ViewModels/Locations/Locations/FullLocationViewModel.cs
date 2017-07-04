using System.Collections.Generic;
using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.Scheduling.ScheduleDays;

namespace Raccord.API.ViewModels.Locations.Locations
{
    // Vm to represent a full location
    public class FullLocationViewModel: LocationViewModel
    {
        private IEnumerable<LocationSetScriptLocationViewModel> _sets;
        private IEnumerable<ScheduleDaySceneCollectionViewModel> _scheduleDays;

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
    }
}