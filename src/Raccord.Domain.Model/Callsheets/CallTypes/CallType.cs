using System.Collections.Generic;
using Raccord.Domain.Model.Callsheets.Characters;
using Raccord.Domain.Model.Projects;

namespace Raccord.Domain.Model.Callsheets.CallTypes
{
    /// Represents definition of a call type
    public class CallType : Entity<long>
    {
        private ICollection<CharacterCall> _characterCalls;

        /// Name of the call type
        public string Name { get; set; }

        // Short name of the call type
        public string ShortName { get; set; }

        /// Description of the call type
        public string Description { get; set; }

        // The sorting order of the call type
        public int? SortingOrder { get; set; }

        // ID of the project
        public long ProjectID { get; set; }

        // Linked project
        public virtual Project Project { get; set; }

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