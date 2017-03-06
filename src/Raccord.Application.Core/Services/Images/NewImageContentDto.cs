using System.IO;
using Raccord.Application.Core.Common.SelectedEntity;

namespace Raccord.Application.Core.Services.Images
{
    // Dto to represent an image with content
    public class NewImageContentDto
    {
        private SelectedEntityDto _selectedEntity;

        // File Content
        public Stream FileContent { get; set; }

        // Name of the file
        public string FileName { get; set;}

        // Selected Entity (if applicable)
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