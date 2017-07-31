using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;

namespace Raccord.Application.Core.Services.Callsheets.CallsheetScenes
{
    // Dto to represent a scene on a callsheet
    public class CallsheetSceneSummaryDto
    {
        private SceneSummaryDto _scene;
        private CallsheetSummaryDto _callsheet;
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

        // Linked callsheet
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