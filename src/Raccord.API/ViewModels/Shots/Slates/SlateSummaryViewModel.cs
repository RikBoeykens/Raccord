using Raccord.API.ViewModels.Images;

namespace Raccord.API.ViewModels.Shots.Slates
{
    public class SlateSummaryViewModel : SlateViewModel
    {
        private ImageViewModel _primaryImage;
        public int TakeCount { get; set; }

        // Primary image linked to the location
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