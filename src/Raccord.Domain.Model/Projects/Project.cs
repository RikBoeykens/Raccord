using System.Collections.Generic;
using Raccord.Domain.Model.Images;

namespace Raccord.Domain.Model.Projects
{
    /// Represents a single project
    public class Project : Entity
    {
        private ICollection<Image> _images;

        /// Title of the project
        public string Title { get; set; }

        public virtual ICollection<Image> Images
        {
            get
            {
                return _images ?? (_images = new List<Image>());
            }
            set
            {
                _images = value;
            }
        }
    }
}