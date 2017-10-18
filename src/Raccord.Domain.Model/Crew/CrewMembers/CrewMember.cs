using System.Collections.Generic;
using Raccord.Domain.Model.Breakdowns.BreakdownTypes;
using Raccord.Domain.Model.Crew.Departments;
using Raccord.Domain.Model.Images;

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
    }
}