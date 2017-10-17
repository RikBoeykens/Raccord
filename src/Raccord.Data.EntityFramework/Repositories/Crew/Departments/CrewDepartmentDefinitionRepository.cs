using Raccord.Domain.Model.Crew.Departments;

namespace Raccord.Data.EntityFramework.Repositories.Crew.Departments
{
    // Repository for breakdown type definitions
    public class CrewDepartmentDefinitionRepository : BaseRepository<CrewDepartmentDefinition>, ICrewDepartmentDefinitionRepository
    {
        public CrewDepartmentDefinitionRepository(RaccordDBContext context) : base(context) 
        {
        }
    }
}
