using Raccord.API.ViewModels.Breakdowns.BreakdownTypes;

namespace Raccord.API.ViewModels.Breakdowns.BreakdownItems
{
    // Viewmodel to represents a breakdown item
    public class BreakdownItemViewModel : BaseBreakdownItemViewModel
    {
        /// <summary>
        /// ID of the linked breakdown
        /// </summary>
        /// <returns></returns>
        public long BreakdownID { get; set; }

        /// <summary>
        /// ID of the linked breakdown type
        /// </summary>
        /// <returns></returns>
        public long BreakdownTypeID { get; set; }
    }
}