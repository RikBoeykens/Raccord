using System;

namespace Raccord.Application.Core.Services.Callsheets.CharacterCalls
{
    // Dto to represent a character with call type info
    public class CharacterCallDto
    {
        // ID of the character call
        public long ID { get; set; }

        // Time of call
        public DateTime CallTime { get; set; }
    }
}