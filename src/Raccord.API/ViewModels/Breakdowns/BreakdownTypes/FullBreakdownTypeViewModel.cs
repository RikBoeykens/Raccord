using System.Collections.Generic;
using Raccord.API.ViewModels.Breakdowns.BreakdownItems;

namespace Raccord.API.ViewModels.Breakdowns.BreakdownTypes
{
    // ViewModel to represent a full breakdown type
    public class FullBreakdownTypeViewModel : BreakdownTypeViewModel
    {
        private BreakdownSummaryViewModel _breakdown;
        private IEnumerable<BreakdownItemSummaryViewModel> _items;

        public BreakdownSummaryViewModel Breakdown
        {
            get
            {
                return _breakdown ?? (_breakdown = new BreakdownSummaryViewModel());
            }
            set
            {
                _breakdown = value;
            }
        }
        public IEnumerable<BreakdownItemSummaryViewModel> BreakdownItems
        {
            get
            {
                return _items ?? (_items = new List<BreakdownItemSummaryViewModel>());
            }
            set
            {
                _items = value;
            }
        }
    }
}