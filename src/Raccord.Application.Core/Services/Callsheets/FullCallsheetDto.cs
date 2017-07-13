using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Images;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Callsheets.CallsheetScenes;

namespace Raccord.Application.Core.Services.Callsheets
{
    // Dto to represent a full location
    public class FullCallsheetDto: CallsheetDto
    {
        private IEnumerable<CallsheetSceneSceneDto> _scenes;

        // Scenes scheduled for the day
        public IEnumerable<CallsheetSceneSceneDto> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<CallsheetSceneSceneDto>());
            }
            set
            {
                _scenes = value;
            }
        }
    }
}