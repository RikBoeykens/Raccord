using System.Collections.Generic;
using Raccord.API.ViewModels.Callsheets.CallsheetScenes;

namespace Raccord.API.ViewModels.Callsheets
{
    // Dto to represent a full callsheet
    public class FullCallsheetViewModel: CallsheetViewModel
    {
        private IEnumerable<CallsheetSceneSceneViewModel> _scenes;

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
    }
}