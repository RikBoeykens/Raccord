using Raccord.API.ViewModels.Breakdowns.BreakdownTypes;

namespace Raccord.API.ViewModels.Breakdowns.BreakdownItems
{
    // Viewmodel to represents a breakdown item
    public class BreakdownItemViewModel
    {
        private BreakdownTypeViewModel _type;

        // ID of the location
        public long ID { get; set; }

        /// Name of the location
        public string Name { get; set; }

        /// Description of the location
        public string Description { get; set; }

        // Linked type
        public BreakdownTypeViewModel Type
        {
            get
            {
                return _type ?? (_type = new BreakdownTypeViewModel());
            }
            set
            {
                _type = value;
            }
        }
    }
}