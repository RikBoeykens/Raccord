using Raccord.Domain.Model.Projects;

namespace Raccord.Domain.Model.Crew.Departments
{
    // Crew Department Definition
    public class CrewDepartmentDefinition : Entity
    {
        // Name of the department
        public string Name { get; set; }

        /// Description of the department
        public string Description { get; set; }

        // Sorting order for the department
        public int SortingOrder { get; set; }
    }
}