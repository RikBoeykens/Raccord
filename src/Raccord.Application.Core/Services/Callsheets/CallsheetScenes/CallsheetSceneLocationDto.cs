using System.Collections.Generic;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Scenes;

namespace Raccord.Application.Core.Services.Callsheets.CallsheetScenes
{
    // Dto to represent a summary of a schedule scene with scene info
    public class CallsheetSceneLocationDto
    {
        private SceneSummaryDto _scene;
        private IEnumerable<LocationSetSummaryDto> _availableLocations;
        private LocationSetSummaryDto _locationSet;

        // ID of the schedule scene
        public long ID { get; set; }

        // Length in eights
        public int PageLength { get; set; }

        // Linked scene
        public SceneSummaryDto Scene
        {
            get
            {
                return _scene ?? (_scene = new SceneSummaryDto()); 
            }
            set
            {
                _scene = value;
            }
        }

        // Characters on the schedule scene
        public IEnumerable<LocationSetSummaryDto> AvailableLocations
        {
            get
            {
                return _availableLocations ?? (_availableLocations = new List<LocationSetSummaryDto>());
            }
            set
            {
                _availableLocations = value;
            }
        }

        // Linked location set
        public LocationSetSummaryDto LocationSet
        {
            get
            {
                return _locationSet ?? (_locationSet = new LocationSetSummaryDto()); 
            }
            set
            {
                _locationSet = value;
            }
        }
    }
}