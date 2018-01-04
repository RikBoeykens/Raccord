using System.Collections.Generic;
using Raccord.Application.Core.Services.Comments;
using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.Projects
{
    // Dto to represent a full project
    public class FullProjectDto : ProjectDto
    {
        private ImageDto _primaryImage;
        private IEnumerable<CommentDto> _comments;

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

        /// <summary>
        /// Comments on the project
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CommentDto> Comments
        {
            get
            {
                return _comments ?? (_comments = new List<CommentDto>());
            }
            set
            {
                _comments = value;
            }
        }
    }
}