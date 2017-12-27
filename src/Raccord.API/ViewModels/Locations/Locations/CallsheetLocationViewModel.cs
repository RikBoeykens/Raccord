using System.Collections.Generic;
using Raccord.API.ViewModels.Locations.LocationSets;

namespace Raccord.API.ViewModels.Locations.Locations
{
    // Dto to represent a full location
    public class CallsheetLocationViewModel: LocationViewModel
    {
        private IEnumerable<CallsheetLocationSetViewModel> _sets;

        // Number of location on callsheet
        public string Number { get; set; }

        // Sets linked to the location
        public IEnumerable<CallsheetLocationSetViewModel> Sets
        {
            get
            {
                return _sets ?? (_sets = new List<CallsheetLocationSetViewModel>());
            }
            set
            {
                _sets = value;
            }
        }
    }

}