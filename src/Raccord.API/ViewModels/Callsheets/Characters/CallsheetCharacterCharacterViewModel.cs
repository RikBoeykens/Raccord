using System.Collections.Generic;
using Raccord.API.ViewModels.Callsheets.CharacterCalls;
using Raccord.API.ViewModels.Characters;

namespace Raccord.API.ViewModels.Callsheets.Characters
{
    // Dto to represent a character on a callsheet with character info
    public class CallsheetCharacterCharacterViewModel
    {
        private CharacterSummaryViewModel _character;
        private IEnumerable<CharacterCallCallTypeViewModel> _calls;

        // ID of the callsheet character
        public long ID { get; set; }

        // linked character
        public CharacterSummaryViewModel Character
        {
            get
            {
                return _character ?? (_character = new CharacterSummaryViewModel());
            }
            set
            {
                _character = value;
            }
        }

        // linked calls
        public IEnumerable<CharacterCallCallTypeViewModel> Calls
        {
            get
            {
                return _calls ?? (_calls = new List<CharacterCallCallTypeViewModel>());
            }
            set
            {
                _calls = value;
            }
        }
    }
}