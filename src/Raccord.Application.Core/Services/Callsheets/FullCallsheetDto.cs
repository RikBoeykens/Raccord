using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Images;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Callsheets.CallsheetScenes;
using Raccord.Application.Core.Services.Callsheets.Characters;

namespace Raccord.Application.Core.Services.Callsheets
{
    // Dto to represent a full location
    public class FullCallsheetDto: CallsheetDto
    {
        private IEnumerable<CallsheetSceneSceneDto> _scenes;
        private IEnumerable<CallsheetCharacterCharacterDto> _characters;

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

        // Characters scheduled for the day
        public IEnumerable<CallsheetCharacterCharacterDto> Characters
        {
            get
            {
                return _characters ?? (_characters = new List<CallsheetCharacterCharacterDto>());
            }
            set
            {
                _characters = value;
            }
        }
    }
}