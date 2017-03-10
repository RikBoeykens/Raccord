using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.Breakdowns.BreakdownItems
{
    // Dto to represent a full break down item
    public class BreakdownItemSummaryDto: BreakdownItemDto
    {
        private ImageDto _primaryImage;

        // Full count of scenes
        public int SceneCount {get; set; }

        // Primary Image for the breakdown item
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