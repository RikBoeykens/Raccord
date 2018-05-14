namespace Raccord.Domain.Model.Callsheets.CallTypes
{
    /// Represents definition of a call type
    public class CallTypeDefinition : Entity
    {
        /// Name of the call type
        public string Name { get; set; }

        // Short name of the call type
        public string ShortName { get; set; }

        /// Description of the call type
        public string Description { get; set; }

        // The sorting order of the call type
        public int? SortingOrder { get; set; }
    }
}