using System.Collections.Generic;
using Raccord.Application.Core.Services.Locations.LocationSets;

namespace Raccord.Application.Core.Services.Locations.Locations
{
    // Dto to represent a full location
    public class FullLocationDto: LocationDto
    {
        private IEnumerable<LocationSetScriptLocationDto> _sets;

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
    }
}