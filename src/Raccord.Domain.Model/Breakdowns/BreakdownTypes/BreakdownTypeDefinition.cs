namespace Raccord.Domain.Model.Breakdowns.BreakdownTypes
{
    /// Represents a definition for a breakdown type
    public class BreakdownTypeDefinition : Entity<long>
    {
        /// Name of the breakdown type
        public string Name { get; set; }

        /// Description of the breakdown type
        public string Description { get; set; }
    }
}