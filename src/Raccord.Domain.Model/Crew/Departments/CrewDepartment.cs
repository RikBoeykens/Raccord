using System.Collections.Generic;
using Raccord.Domain.Model.Crew.CrewMembers;
using Raccord.Domain.Model.Crew.CrewUnits;
using Raccord.Domain.Model.Projects;

namespace Raccord.Domain.Model.Crew.Departments
{
    // Crew department
    public class CrewDepartment : Entity<long>
    {
        private ICollection<CrewMember> _crew;
        
        // Name of the department
        public string Name { get; set; }

        /// Description of the department
        public string Description { get; set; }

        // Sorting order for the department
        public int? SortingOrder { get; set; }

        // ID of the linked crew unit
        public long CrewUnitID { get; set; }
        // Linked project
        public virtual CrewUnit CrewUnit { get; set; }

        // Crew linked to the department
        public virtual ICollection<CrewMember> Crew
        {
            get
            {
                return _crew ?? (_crew = new List<CrewMember>());
            }
            set
            {
                _crew = value;
            }
        }
    }
}