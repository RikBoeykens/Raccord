using Raccord.Application.Core.Services.Breakdowns.BreakdownTypes;
using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.Breakdowns.BreakdownItems
{
    // Dto to represent a breakdown item that's linked to something
    public class LinkedBreakdownItemDto: BaseBreakdownItemDto
    {
        private BreakdownTypeDto _type;
        private ImageDto _primaryImage;
        
        // ID of the link
        public long LinkID { get; set; }
        
        /// <summary>
        /// Breakdown type linked to the item
        /// </summary>
        /// <returns></returns>
        public BreakdownTypeDto Type
        {
            get
            {
                return _type ?? (_type = new BreakdownTypeDto());
            }
            set
            {
                _type = value;
            }
        }

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