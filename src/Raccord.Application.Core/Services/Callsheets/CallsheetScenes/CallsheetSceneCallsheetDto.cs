using Raccord.Application.Core.Services.Locations.LocationSets;

namespace Raccord.Application.Core.Services.Callsheets.CallsheetScenes
{
    // Dto to represent a summary of a callsheet with 
    public class CallsheetSceneCallsheetDto
    {
        private CallsheetSummaryDto _callsheet;
        private LocationSetSummaryDto _locationSet;

        // ID of the schedule scene
        public long ID { get; set; }

        // Length in eights
        public int PageLength { get; set; }

        // Linked schedule day
        public CallsheetSummaryDto Callsheet
        {
            get
            {
                return _callsheet ?? (_callsheet = new CallsheetSummaryDto()); 
            }
            set
            {
                _callsheet = value;
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