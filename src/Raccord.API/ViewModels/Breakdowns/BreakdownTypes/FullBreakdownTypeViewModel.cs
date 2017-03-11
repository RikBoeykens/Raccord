using System.Collections.Generic;
using Raccord.API.ViewModels.Breakdowns.BreakdownItems;

namespace Raccord.API.ViewModels.Breakdowns.BreakdownTypes
{
    // ViewModel to represent a full breakdown type
    public class FullBreakdownTypeViewModel : BreakdownTypeViewModel
    {
        private IEnumerable<BreakdownItemSummaryViewModel> _items;

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