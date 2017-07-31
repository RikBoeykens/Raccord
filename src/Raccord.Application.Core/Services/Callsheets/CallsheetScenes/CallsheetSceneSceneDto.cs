using System.Collections.Generic;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Scenes;

namespace Raccord.Application.Core.Services.Callsheets.CallsheetScenes
{
    // Dto to represent a summary of a schedule scene with scene info
    public class CallsheetSceneSceneDto
    {
        private SceneSummaryDto _scene;
        private IEnumerable<LinkedCharacterDto> _characters;
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
        public IEnumerable<LinkedCharacterDto> Characters
        {
            get
            {
                return _characters ?? (_characters = new List<LinkedCharacterDto>());
            }
            set
            {
                _characters = value;
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