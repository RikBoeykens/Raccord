using Raccord.Domain.Model.Projects;

namespace Raccord.Domain.Model.Breakdowns.BreakdownTypes
{
    /// Represents a breakdown type
    public class BreakdownType : Entity
    {
        /// Name of the breakdown type
        public string Name { get; set; }

        /// Description of the breakdown type
        public string Description { get; set; }

        // ID of the linked project
        public long ProjectID { get; set; }

        // Linked project
        public virtual Project Project { get; set; }
    }
}