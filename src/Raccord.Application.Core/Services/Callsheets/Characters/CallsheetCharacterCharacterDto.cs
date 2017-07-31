using System.Collections.Generic;
using Raccord.Application.Core.Services.Callsheets.CharacterCalls;
using Raccord.Application.Core.Services.Characters;

namespace Raccord.Application.Core.Services.Callsheets.Characters
{
    // Dto to represent a character on a callsheet with character info
    public class CallsheetCharacterCharacterDto
    {
        private CharacterSummaryDto _character;
        private IEnumerable<CharacterCallCallTypeDto> _calls;

        // ID of the callsheet character
        public long ID { get; set; }

        // linked character
        public CharacterSummaryDto Character
        {
            get
            {
                return _character ?? (_character = new CharacterSummaryDto());
            }
            set
            {
                _character = value;
            }
        }

        // linked calls
        public IEnumerable<CharacterCallCallTypeDto> Calls
        {
            get
            {
                return _calls ?? (_calls = new List<CharacterCallCallTypeDto>());
            }
            set
            {
                _calls = value;
            }
        }
    }
}