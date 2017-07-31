using System.Collections.Generic;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Scenes;

namespace Raccord.Application.Core.Services.Callsheets.CallsheetScenes
{
    // Dto to represent a full schedule scene
    public class CallsheetSceneCharactersDto
    {
        private SceneSummaryDto _scene;
        private IEnumerable<LinkedCharacterDto> _availableCharacters;
        private IEnumerable<LinkedCharacterDto> _characters;

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

        // Available Characters on the schedule scene
        public IEnumerable<LinkedCharacterDto> AvailableCharacters
        {
            get
            {
                return _availableCharacters ?? (_availableCharacters = new List<LinkedCharacterDto>());
            }
            set
            {
                _availableCharacters = value;
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
    }
}