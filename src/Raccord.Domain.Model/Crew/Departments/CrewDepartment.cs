using Raccord.Domain.Model.Projects;

namespace Raccord.Domain.Model.Crew.Departments
{
    // Crew department
    public class CrewDepartment : Entity
    {
        // Name of the department
        public string Name { get; set; }

        /// Description of the department
        public string Description { get; set; }

        // Sorting order for the department
        public int SortingOrder { get; set; }

        // ID of the linked project
        public long ProjectID { get; set; }
        // Linked project
        public virtual Project Project { get; set; }
    }
}