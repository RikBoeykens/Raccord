using Raccord.Application.Core.Services.Crew.Departments;
using Raccord.Application.Core.Services.Crew.CrewMembers;
using Raccord.API.ViewModels.Crew.Departments;

namespace Raccord.API.ViewModels.Crew.CrewMembers
{
    public class CrewMemberViewModel
    {
        private CrewDepartmentViewModel _department;
        
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
        public CrewDepartmentViewModel Department
        {
            get
            {
                return _department ?? (_department = new CrewDepartmentViewModel());
            }
            set
            {
                _department = value;
            }
        }
    }
}