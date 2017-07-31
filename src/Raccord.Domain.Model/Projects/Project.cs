using System.Collections.Generic;
using Raccord.Domain.Model.Breakdowns.BreakdownTypes;
using Raccord.Domain.Model.Images;
using Raccord.Domain.Model.Crew;

namespace Raccord.Domain.Model.Projects
{
    /// Represents a single project
    public class Project : Entity
    {
        private ICollection<Image> _images;
        private ICollection<BreakdownType> _breakdownTypes;
        private ICollection<CrewUser> _crew;

        /// Title of the project
        public string Title { get; set; }

        // Images associated with the project
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

        // Breakdown types associated with the project
        public virtual ICollection<BreakdownType> BreakdownTypes
        {
            get
            {
                return _breakdownTypes ?? (_breakdownTypes = new List<BreakdownType>());
            }
            set
            {
                _breakdownTypes = value;
            }
        }

        // Crew associated with the project
        public virtual ICollection<CrewUser> Crew
        {
            get
            {
                return _crew ?? (_crew = new List<CrewUser>());
            }
            set
            {
                _crew = value;
            }
        }
    }
}