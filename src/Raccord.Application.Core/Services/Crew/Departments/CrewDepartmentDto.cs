namespace Raccord.Application.Core.Services.Crew.Departments
{
    public class CrewDepartmentDto
    {
        // ID of the crew user
        public long ID { get; set; }

        // Name of the department
        public string Name { get; set; }

        // Description of the department
        public string Description { get; set; }

        // Linked project
        public long CrewUnitID { get; set; }
    }
}