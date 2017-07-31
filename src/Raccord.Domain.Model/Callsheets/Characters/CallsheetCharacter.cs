using System.Collections.Generic;
using Raccord.Domain.Model.Characters;

namespace Raccord.Domain.Model.Callsheets.Characters
{
    // join for character and callsheet scene
    public class CallsheetCharacter : Entity
    {
        private ICollection<CharacterCall> _characterCalls;

        // ID of the linked character
        public long CharacterID { get; set; }

        // Linked character
        public virtual Character Character { get; set; }

        // ID of the linked schedule scene
        public long CallsheetID { get; set; }

        // Linked schedule scene
        public virtual Callsheet Callsheet { get; set; }

        // Linked characters
        public virtual ICollection<CharacterCall> CharacterCalls
        {
            get
            {
                return _characterCalls ?? (_characterCalls = new List<CharacterCall>());
            }
            set
            {
                _characterCalls = value;
            }
        }
    }
}