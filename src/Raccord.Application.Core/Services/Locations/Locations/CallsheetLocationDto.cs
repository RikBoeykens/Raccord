using System.Collections.Generic;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;

namespace Raccord.Application.Core.Services.Locations.Locations
{
    // Dto to represent a full location
    public class CallsheetLocationDto: LocationDto
    {
        private IEnumerable<CallsheetLocationSetDto> _sets;

        // Number of location on callsheet
        public string Number { get; set; }

        // Sets linked to the location
        public IEnumerable<CallsheetLocationSetDto> Sets
        {
            get
            {
                return _sets ?? (_sets = new List<CallsheetLocationSetDto>());
            }
            set
            {
                _sets = value;
            }
        }
    }
}