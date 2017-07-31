using System;

namespace Raccord.API.ViewModels.Callsheets.CharacterCalls
{
    // Viewmodel to represent a character call
    public class CharacterCallViewModel
    {

        // ID of the character call
        public long ID { get; set; }

        // Time of call
        public DateTime CallTime { get; set; }
    }
}