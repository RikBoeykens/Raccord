using System;
using Raccord.Domain.Model.Callsheets.CallTypes;

namespace Raccord.Domain.Model.Callsheets.Characters
{
    // join for character and callsheet scene
    public class CharacterCall : Entity<long>
    {
        // Time of call
        public DateTime CallTime { get; set; }
        // ID of the linked character
        public long CallsheetCharacterID { get; set; }

        // Linked character
        public virtual CallsheetCharacter CallsheetCharacter { get; set; }

        // ID of the linked call type
        public long CallTypeID { get; set; }

        // Linked schedule scene
        public virtual CallType CallType { get; set; }
    }
}