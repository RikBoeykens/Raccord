using System.Collections.Generic;
using Raccord.API.ViewModels.Callsheets.CallsheetScenes;
using Raccord.API.ViewModels.Callsheets.Characters;

namespace Raccord.API.ViewModels.Callsheets
{
    // Dto to represent a full callsheet
    public class FullCallsheetViewModel: CallsheetViewModel
    {
        private IEnumerable<CallsheetSceneSceneViewModel> _scenes;
        private IEnumerable<CallsheetCharacterCharacterViewModel> _characters;

        // Scenes scheduled for the day
        public IEnumerable<CallsheetSceneSceneViewModel> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<CallsheetSceneSceneViewModel>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Characters scheduled for the day
        public IEnumerable<CallsheetCharacterCharacterViewModel> Characters
        {
            get
            {
                return _characters ?? (_characters = new List<CallsheetCharacterCharacterViewModel>());
            }
            set
            {
                _characters = value;
            }
        }
    }
}