using System.Collections.Generic;
using Raccord.Domain.Model.Crew.CrewMembers;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Users;

namespace Raccord.Domain.Model.Users
{
    public class ProjectUser : Entity
    {
        private ICollection<CrewMember> _crewMembers;

        // ID of the linked project
        public long ProjectID { get; set; }
        // Linked project
        public virtual Project Project { get; set; }

        // ID of the linked user
        public string UserID { get; set; }
        // linked user
        public virtual ApplicationUser User { get; set; }

        // Crew Members associated with the user
        public virtual ICollection<CrewMember> CrewMembers
        {
            get
            {
                return _crewMembers ?? (_crewMembers = new List<CrewMember>());
            }
            set
            {
                _crewMembers = value;
            }
        }
    }
}