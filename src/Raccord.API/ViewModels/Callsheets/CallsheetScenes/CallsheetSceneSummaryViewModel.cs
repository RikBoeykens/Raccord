using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Callsheets;

namespace Raccord.API.ViewModels.Callsheets.CallsheetScenes
{
    // Viewmodel to represent a scene on a callsheet
    public class CallsheetSceneSummaryViewModel
    {
        private SceneSummaryViewModel _scene;
        private CallsheetSummaryViewModel _callsheet;
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

        // Linked callsheet
        public CallsheetSummaryViewModel Callsheet
        {
            get
            {
                return _callsheet ?? (_callsheet = new CallsheetSummaryViewModel()); 
            }
            set
            {
                _callsheet = value;
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