using System.Collections.Generic;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Callsheets;

namespace Raccord.API.ViewModels.Callsheets.CallsheetScenes
{
    // Dto to represent a summary of a schedule scene with 
    public class CallsheetSceneCharactersViewModel
    {
        private SceneSummaryViewModel _scene;
        private IEnumerable<LinkedCharacterViewModel> _availableCharacters;
        private IEnumerable<LinkedCharacterViewModel> _characters;

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
        public IEnumerable<LinkedCharacterViewModel> AvailableCharacters
        {
            get
            {
                return _availableCharacters ?? (_availableCharacters = new List<LinkedCharacterViewModel>()); 
            }
            set
            {
                _availableCharacters = value;
            }
        }

        // Linked characters
        public IEnumerable<LinkedCharacterViewModel> Characters
        {
            get
            {
                return _characters ?? (_characters = new List<LinkedCharacterViewModel>()); 
            }
            set
            {
                _characters = value;
            }
        }
    }
}