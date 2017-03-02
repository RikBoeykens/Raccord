using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.Locations
{
    // Dto to represent a full location
    public class LocationSummaryDto: LocationDto
    {
        private ImageDto _primaryImage;

        // Full count of scenes
        public int SceneCount {get; set; }

        // Primary Image for the location
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