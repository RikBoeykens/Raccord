using System.Collections.Generic;
using Raccord.Domain.Model.Breakdowns;
using Raccord.Domain.Model.Callsheets.CallTypes;
using Raccord.Domain.Model.Comments;
using Raccord.Domain.Model.Crew.CrewUnits;
using Raccord.Domain.Model.Crew.Departments;
using Raccord.Domain.Model.Images;
using Raccord.Domain.Model.Users;

namespace Raccord.Domain.Model.Projects
{
    /// Represents a single project
    public class Project : Entity
    {
        private ICollection<Image> _images;
        private ICollection<ProjectUser> _projectUsers;
        private ICollection<CallType> _callTypes;
        private ICollection<Comment> _comments;
        private ICollection<Breakdown> _breakdowns;
        private ICollection<CrewUnit> _crewUnits;


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

        // Crew associated with the project
        public virtual ICollection<ProjectUser> ProjectUsers
        {
            get
            {
                return _projectUsers ?? (_projectUsers = new List<ProjectUser>());
            }
            set
            {
                _projectUsers = value;
            }

        }
        
        // Breakdown types associated with the project
        public virtual ICollection<CallType> CallTypes
        {
            get
            {
                return _callTypes ?? (_callTypes = new List<CallType>());
            }
            set
            {
                _callTypes = value;
            }
        }
        
        // Comments made to the project
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

        // Breakdowns associated with the project
        public virtual ICollection<Breakdown> Breakdowns
        {
            get
            {
                return _breakdowns ?? (_breakdowns = new List<Breakdown>());
            }
            set
            {
                _breakdowns = value;
            }
        }

        // Breakdowns associated with the project
        public virtual ICollection<CrewUnit> CrewUnits
        {
            get
            {
                return _crewUnits ?? (_crewUnits = new List<CrewUnit>());
            }
            set
            {
                _crewUnits = value;
            }
        }
    }
}