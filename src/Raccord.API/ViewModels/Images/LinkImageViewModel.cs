using Raccord.API.ViewModels.Common.SelectedEntity;

namespace Raccord.API.ViewModels.Images
{
    // Dto to represent a image
    public class LinkImageViewModel
    {
        private SelectedEntityViewModel _selectedEntity;

        // ID of the image
        public long ImageID { get; set; }

        // Selected entity to link to image
        public SelectedEntityViewModel SelectedEntity
        {
            get
            {
                return _selectedEntity ?? (_selectedEntity = new SelectedEntityViewModel());
            }
            set
            {
                _selectedEntity = value;
            }
        }
    }
}