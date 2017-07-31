using System.Collections.Generic;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Callsheets;

namespace Raccord.API.ViewModels.Callsheets.CallsheetScenes
{
    // Viewmodel to represent a summary of a callsheet scene with location info
    public class CallsheetSceneLocationViewModel
    {
        private SceneSummaryViewModel _scene;
        private IEnumerable<LocationSetSummaryViewModel> _availableLocations;
        private LocationSetSummaryViewModel _locationSet;

        // ID of the schedule scene
        public long ID { get; set; }

        // Length in eights
        public int PageLength { get; set; }

        // Linked scene
        public SceneSummaryViewModel Scene
        {
            get
            {
                return _scene ?? (_scene = new SceneSummaryViewModel()); 
            }
            set
            {
                _scene = value;
            }
        }

        // Linked characters
        public IEnumerable<LocationSetSummaryViewModel> AvailableLocations
        {
            get
            {
                return _availableLocations ?? (_availableLocations = new List<LocationSetSummaryViewModel>()); 
            }
            set
            {
                _availableLocations = value;
            }
        }

        // Linked location set
        public LocationSetSummaryViewModel LocationSet
        {
            get
            {
                return _locationSet ?? (_locationSet = new LocationSetSummaryViewModel()); 
            }
            set
            {
                _locationSet = value;
            }
        }
    }
}