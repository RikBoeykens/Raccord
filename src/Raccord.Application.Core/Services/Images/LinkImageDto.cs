using Raccord.Application.Core.Common.SelectedEntity;

namespace Raccord.Application.Core.Services.Images
{
    // Dto to represent a image
    public class LinkImageDto
    {
        private SelectedEntityDto _selectedEntity;

        // ID of the image
        public long ImageID { get; set; }

        // Selected entity to link to image
        public SelectedEntityDto SelectedEntity
        {
            get
            {
                return _selectedEntity ?? (_selectedEntity = new SelectedEntityDto());
            }
            set
            {
                _selectedEntity = value;
            }
        }
    }
}