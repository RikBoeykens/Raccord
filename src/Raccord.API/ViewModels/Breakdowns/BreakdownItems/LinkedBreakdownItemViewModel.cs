using Raccord.API.ViewModels.Breakdowns.BreakdownTypes;
using Raccord.API.ViewModels.Images;

namespace Raccord.API.ViewModels.Breakdowns.BreakdownItems
{
    // ViewModel to represent a summary of a breakdown item
    public class LinkedBreakdownItemViewModel : BaseBreakdownItemViewModel
    {
        private BreakdownTypeViewModel _type;
        private BreakdownViewModel _breakdown;
        private ImageViewModel _primaryImage;
        
        // ID of the link
        public long LinkID { get; set; }
        
        /// <summary>
        /// Breakdown type linked to the item
        /// </summary>
        /// <returns></returns>
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
        
        /// <summary>
        /// Breakdown linked to the item
        /// </summary>
        /// <returns></returns>
        public BreakdownViewModel Breakdown
        {
            get
            {
                return _breakdown ?? (_breakdown = new BreakdownViewModel());
            }
            set
            {
                _breakdown = value;
            }
        }

        // Primary Image for the breakdown item
        public ImageViewModel PrimaryImage
        {
            get
            {
                return _primaryImage ?? (_primaryImage = new ImageViewModel());
            }
            set
            {
                _primaryImage = value;
            }
        }
    }
}