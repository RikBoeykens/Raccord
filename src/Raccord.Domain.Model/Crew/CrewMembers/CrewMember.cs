using System.Collections.Generic;
using Raccord.Domain.Model.Breakdowns.BreakdownTypes;
using Raccord.Domain.Model.Crew.CrewUnits;
using Raccord.Domain.Model.Crew.Departments;
using Raccord.Domain.Model.Images;
using Raccord.Domain.Model.Users;

namespace Raccord.Domain.Model.Crew.CrewMembers
{
    /// Represents a breakdown item
    public class CrewMember : Entity
    {
        /// First Name of the crew member
        public string FirstName { get; set; }

        /// Last Name of the crew member
        public string LastName { get; set; }
        
        /// Job title of the crew member
        public string JobTitle { get; set; }

        /// Telephone of the crew member
        public string Telephone { get; set; }

        /// Email of the crew member
        public string Email { get; set; }

        // ID of the linked department
        public long DepartmentID { get; set; }

        // Linked crew department
        public virtual CrewDepartment Department { get; set; }

        /// <summary>
        /// Id of the linked Crew Unit Member (if applicable)
        /// </summary>
        /// <returns></returns>
        public long? CrewUnitMemberID { get; set; }

        /// <summary>
        /// Linked Crew Unit Member (if applicable)
        /// </summary>
        /// <returns></returns>
        public virtual CrewUnitMember CrewUnitMember { get; set; }
    }
}