using System.Collections.Generic;
using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.Projects
{
    // Dto to represent a full project
    public class FullProjectDto : ProjectDto
    {
        private ImageDto _primaryImage;

        /// <summary>
        /// Indicates if the schedule has been published
        /// </summary>
        /// <returns></returns>
        public bool PublishedSchedule { get; set; }

        // Primary Image for the project
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