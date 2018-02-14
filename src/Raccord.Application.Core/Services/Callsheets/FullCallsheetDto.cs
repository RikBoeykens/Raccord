using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Images;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Callsheets.CallsheetScenes;
using Raccord.Application.Core.Services.Callsheets.Characters;
using Raccord.Application.Core.Services.Locations.Locations;
using Raccord.Application.Core.Services.Breakdowns.BreakdownTypes;
using Raccord.Application.Core.Services.Breakdowns;

namespace Raccord.Application.Core.Services.Callsheets
{
    // Dto to represent a full location
    public class FullCallsheetDto: CallsheetDto
    {
        private IEnumerable<CallsheetSceneSceneDto> _scenes;
        private IEnumerable<CallsheetCharacterCharacterDto> _characters;
        private IEnumerable<CallsheetLocationDto> _locations;
        private CallsheetBreakdownDto _breakdownInfo;

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

        // Locations for the day
        public IEnumerable<CallsheetLocationDto> Locations
        {
            get
            {
                return _locations ?? (_locations = new List<CallsheetLocationDto>());
            }
            set
            {
                _locations = value;
            }
        }

        // Breakdown types on the day
        public CallsheetBreakdownDto BreakdownInfo
        {
            get
            {
                return _breakdownInfo ?? (_breakdownInfo = new CallsheetBreakdownDto());
            }
            set
            {
                _breakdownInfo = value;
            }
        }
    }
}