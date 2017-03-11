using Raccord.API.ViewModels.Images;

namespace Raccord.API.ViewModels.Breakdowns.BreakdownItems
{
    // ViewModel to represent a summary of a breakdown item
    public class BreakdownItemSummaryViewModel : BreakdownItemViewModel
    {
        private ImageViewModel _primaryImage;

        // Total count of scenes
        public int SceneCount { get; set; }

        // Primary image linked to the breakdown item
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