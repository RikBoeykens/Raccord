using System.Linq;
using Raccord.Application.Core.Services.Users.Project;
using Raccord.Application.Services.Crew.CrewMembers;
using Raccord.Application.Services.Projects;
using Raccord.Application.Services.Users;
using Raccord.Core.Enums;
using Raccord.Domain.Model.Users;

namespace Raccord.Application.Services.Users.Projects
{
    // Utilities and helper methods for project users
    public static class Utilities
    {
        public static FullProjectUserDto TranslateFull(this ProjectUser projectUser)
        {
            return new FullProjectUserDto
            {
                ID = projectUser.ID,
                User = projectUser.User.Translate(),
                Project = projectUser.Project.Translate(),
                CrewMembers = projectUser.CrewMembers.Select(cm => cm.Translate()),
            };
        }
        public static ProjectUserUserDto TranslateUser(this ProjectUser projectUser)
        {
            return new ProjectUserUserDto
            {
                ID = projectUser.ID,
                User = projectUser.User.TranslateSummary(),
            };
        }
        public static ProjectUserProjectDto TranslateProject(this ProjectUser projectUser)
        {
            return new ProjectUserProjectDto
            {
                ID = projectUser.ID,
                Project = projectUser.Project.TranslateSummary()
            };
        }
        public static ProjectUserDto Translate(this ProjectUser projectUser)
        {
            return new ProjectUserDto
            {
                ID = projectUser.ID,
                UserID = projectUser.UserID,
                ProjectID = projectUser.ProjectID,
            };
        }
    }
}