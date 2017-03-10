using System.Collections.Generic;
using Raccord.Domain.Model.Breakdowns.BreakdownItems;
using Raccord.Domain.Model.Projects;

namespace Raccord.Domain.Model.Breakdowns.BreakdownTypes
{
    /// Represents a breakdown type
    public class BreakdownType : Entity
    {
        private ICollection<BreakdownItem> _items;

        /// Name of the breakdown type
        public string Name { get; set; }

        /// Description of the breakdown type
        public string Description { get; set; }

        // ID of the linked project
        public long ProjectID { get; set; }

        // Linked project
        public virtual Project Project { get; set; }

        // Linked items
        public virtual ICollection<BreakdownItem> BreakdownItems
        {
            get
            {
                return _items ?? (_items = new List<BreakdownItem>());
            }
            set
            {
                _items = value;
            }
        }
    }
}