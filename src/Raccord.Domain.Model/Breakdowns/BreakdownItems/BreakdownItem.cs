using System.Collections.Generic;
using Raccord.Domain.Model.Breakdowns.BreakdownTypes;
using Raccord.Domain.Model.Comments;
using Raccord.Domain.Model.Images;

namespace Raccord.Domain.Model.Breakdowns.BreakdownItems
{
    /// Represents a breakdown item
    public class BreakdownItem : Entity<long>
    {
        private ICollection<BreakdownItemScene> _scenes;
        private ICollection<ImageBreakdownItem> _images;
        private ICollection<Comment> _comments;

        /// Name of the breakdown item
        public string Name { get; set; }

        /// Description of the breakdown item
        public string Description { get; set; }

        // ID of the linked breakdown type
        public long BreakdownTypeID { get; set; }

        // Linked breakdown type
        public virtual BreakdownType BreakdownType { get; set; }

        // ID of the linked breakdown
        public long BreakdownID { get; set; }

        // Linked breakdown type
        public virtual Breakdown Breakdown { get; set; }

        // Linked scenes
        public virtual ICollection<BreakdownItemScene> BreakdownItemScenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<BreakdownItemScene>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Linked images
        public virtual ICollection<ImageBreakdownItem> ImageBreakdownItems
        {
            get
            {
                return _images ?? (_images = new List<ImageBreakdownItem>());
            }
            set
            {
                _images = value;
            }
        }
        
        // Comments made to the breakdown item
        public virtual ICollection<Comment> Comments
        {
            get
            {
                return _comments ?? (_comments = new List<Comment>());
            }
            set
            {
                _comments = value;
            }
        }
    }
}