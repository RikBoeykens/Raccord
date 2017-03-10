using Raccord.Application.Core.Services.Breakdowns.BreakdownTypes;

namespace Raccord.Application.Core.Services.Breakdowns.BreakdownItems
{
    // Dto to represent a breakdown item
    public class BreakdownItemDto
    {
        private BreakdownTypeDto _breakdownType;

        // ID of the breakdown item
        public long ID { get; set; }

        /// Name of the breakdown item
        public string Name { get; set; }

        /// Description of the breakdown item
        public string Description { get; set; }

        // Type of the breakdown item
        public BreakdownTypeDto Type
        {
            get
            {
                return _breakdownType ?? (_breakdownType = new BreakdownTypeDto());
            }
            set{
                _breakdownType = value;
            }
        }
    }
}