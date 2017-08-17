using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.Shots.Slates
{
    public class SlateSummaryDto : SlateDto
    {
        private ImageDto _primaryImage;
        public int TakeCount { get; set; }

        // Primary Image for the scene
        public ImageDto PrimaryImage
        {
            get
            {
                return _primaryImage ?? (_primaryImage = new ImageDto());
            }
            set
            {
                _primaryImage = value;
            }
        }
    }
}