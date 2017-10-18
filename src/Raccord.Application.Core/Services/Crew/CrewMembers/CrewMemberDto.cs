using Raccord.Application.Core.Services.Crew.Departments;
using Raccord.Application.Core.Services.Crew.CrewMembers;

namespace Raccord.Application.Core.Services.Crew.CrewMembers
{
    public class CrewMemberDto
    {
        private CrewDepartmentDto _department;
        
        public long ID { get; set; }

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

        // Department linked to crew member
        public CrewDepartmentDto Department
        {
            get
            {
                return _department ?? (_department = new CrewDepartmentDto());
            }
            set
            {
                _department = value;
            }
        }
    }
}