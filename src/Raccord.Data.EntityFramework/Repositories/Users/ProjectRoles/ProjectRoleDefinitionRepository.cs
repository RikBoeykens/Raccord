using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Users.ProjectRoles;

namespace Raccord.Data.EntityFramework.Repositories.Users.ProjectRoles
{
    // Repository for preojct users
    public class ProjectRoleDefinitionRepository : BaseRepository<ProjectRoleDefinition>, IProjectRoleDefinitionRepository
    {
        public ProjectRoleDefinitionRepository(RaccordDBContext context) : base(context) 
        {
        }
    }
}
