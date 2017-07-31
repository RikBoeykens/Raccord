using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.Callsheets;

namespace Raccord.API.ViewModels.Callsheets.CallsheetScenes
{
    // Dto to represent a summary of a callsheet scene with callsheet info
    public class CallsheetSceneCallsheetViewModel
    {
        private CallsheetSummaryViewModel _callsheet;
        private LocationSetSummaryViewModel _locationSet;

        // ID of the schedule scene
        public long ID { get; set; }

        // Length in eights
        public int PageLength { get; set; }

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