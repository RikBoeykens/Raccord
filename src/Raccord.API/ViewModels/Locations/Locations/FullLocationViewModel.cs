using System.Collections.Generic;
using Raccord.API.ViewModels.Locations.LocationSets;

namespace Raccord.API.ViewModels.Locations.Locations
{
    // Vm to represent a full location
    public class FullLocationViewModel: LocationViewModel
    {
        private IEnumerable<LocationSetScriptLocationViewModel> _sets;

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
    }
}