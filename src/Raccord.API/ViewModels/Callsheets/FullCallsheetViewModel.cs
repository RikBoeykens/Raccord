using System.Collections.Generic;
using Raccord.API.ViewModels.Breakdowns;
using Raccord.API.ViewModels.Callsheets.CallsheetScenes;
using Raccord.API.ViewModels.Callsheets.Characters;
using Raccord.API.ViewModels.Locations.Locations;

namespace Raccord.API.ViewModels.Callsheets
{
    // Dto to represent a full callsheet
    public class FullCallsheetViewModel: CallsheetViewModel
    {
        private IEnumerable<CallsheetSceneSceneViewModel> _scenes;
        private IEnumerable<CallsheetCharacterCharacterViewModel> _characters;
        private IEnumerable<CallsheetLocationViewModel> _locations;
        private CallsheetBreakdownViewModel _breakdownInfo;

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

        // Locations scheduled for the day
        public IEnumerable<CallsheetLocationViewModel> Locations
        {
            get
            {
                return _locations ?? (_locations = new List<CallsheetLocationViewModel>());
            }
            set
            {
                _locations = value;
            }
        }

        // Breakdown types for the day
        public CallsheetBreakdownViewModel BreakdownInfo
        {
            get
            {
                return _breakdownInfo ?? (_breakdownInfo = new CallsheetBreakdownViewModel());
            }
            set
            {
                _breakdownInfo = value;
            }
        }
    }
}