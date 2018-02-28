using System.Collections.Generic;
using Raccord.Domain.Model.Breakdowns;
using Raccord.Domain.Model.Cast;
using Raccord.Domain.Model.Characters;
using Raccord.Domain.Model.Crew.CrewMembers;
using Raccord.Domain.Model.Crew.CrewUnits;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Users;
using Raccord.Domain.Model.Users.ProjectRoles;

namespace Raccord.Domain.Model.Users
{
    public class ProjectUser : Entity
    {
        private ICollection<CrewUnitMember> _crewUnitMembers;

        // ID of the linked project
        public long ProjectID { get; set; }
        // Linked project
        public virtual Project Project { get; set; }

        // ID of the linked user
        public string UserID { get; set; }
        // linked user
        public virtual ApplicationUser User { get; set; }

        /// <summary>
        /// Role associated with the user
        /// </summary>
        /// <returns></returns>
        public long? RoleID { get; set; }

        /// <summary>
        /// Role associated with the user
        /// </summary>
        /// <returns></returns>
        public virtual ProjectRoleDefinition Role { get; set; }

        public long? SelectedBreakdownID { get; set; }

        public virtual Breakdown SelectedBreakdown { get; set; }

        public long? CastMemberID { get; set; }
        public virtual CastMember CastMember { get;set; }

        // Crew Unit Members associated with the user
        public virtual ICollection<CrewUnitMember> CrewUnitMembers
        {
            get
            {
                return _crewUnitMembers ?? (_crewUnitMembers = new List<CrewUnitMember>());
            }
            set
            {
                _crewUnitMembers = value;
            }
        }
    }
}