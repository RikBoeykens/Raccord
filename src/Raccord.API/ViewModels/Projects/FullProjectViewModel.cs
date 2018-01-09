using System.Collections.Generic;
using Raccord.API.ViewModels.Comments;
using Raccord.API.ViewModels.Images;

namespace Raccord.API.ViewModels.Projects
{
    // Viewmodel to represent a full project
    public class FullProjectViewModel : ProjectViewModel
    {
        private ImageViewModel _primaryImage;
        private IEnumerable<CommentViewModel> _comments;

        // Primary image linked to the project
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

        // Comments linked to the project
        public IEnumerable<CommentViewModel> Comments
        {
            get
            {
                return _comments ?? (_comments = new List<CommentViewModel>());
            }
            set
            {
                _comments = value;
            }
        }
    }
}