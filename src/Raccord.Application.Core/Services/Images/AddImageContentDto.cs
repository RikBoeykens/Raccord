using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Images
{
    // Dto to represent an image with content
    public class AddImageContentDto
    {
        private IEnumerable<NewImageContentDto> _images;

        // ID of the project
        public long ProjectID { get; set; }

        // Images to add
        public IEnumerable<NewImageContentDto> Images
        {
            get
            {
                return _images ?? (_images = new List<NewImageContentDto>());
            }
            set
            {
                _images = value;
            }
        }
    }
}