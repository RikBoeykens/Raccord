using Raccord.API.ViewModels.Images;

namespace Raccord.API.ViewModels.Projects
{
    // Viewmodel to represent a project summary
    public class ProjectSummaryViewModel : ProjectViewModel
    {
        private ImageViewModel _primaryImage;

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
    }
}