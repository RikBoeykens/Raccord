using System.Linq;
using Raccord.Application.Core.Services.Users.Project;
using Raccord.Application.Services.Characters;
using Raccord.Application.Services.Crew.CrewMembers;
using Raccord.Application.Services.Cast;
using Raccord.Application.Services.Projects;
using Raccord.Application.Services.Users;
using Raccord.Application.Services.Users.ProjectRoles;
using Raccord.Core.Enums;
using Raccord.Domain.Model.Users;
using Raccord.Domain.Model.Crew.CrewUnits;
using Raccord.Application.Services.Crew.CrewUnits;

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
                CastMember = projectUser.CastMember.Translate(),
                ProjectRole = projectUser.Role.Translate(),
                CrewUnits = projectUser.CrewUnitMembers.Select(cum => cum.TranslateCrewUnit())
            };
        }
        public static ProjectUserUserDto TranslateUser(this ProjectUser projectUser)
        {
            return new ProjectUserUserDto
            {
                ID = projectUser.ID,
                User = projectUser.User.TranslateSummary(),
                ProjectRole = projectUser.Role.Translate(),
            };
        }
        public static LinkedProjectUserUserDto TranslateProjectUser(this CrewUnitMember crewUnitMember)
        {
            return new LinkedProjectUserUserDto
            {
                ID = crewUnitMember.ProjectUser.ID,
                User = crewUnitMember.ProjectUser.User.TranslateSummary(),
                ProjectRole = crewUnitMember.ProjectUser.Role.Translate(),
                LinkID = crewUnitMember.ID
            };
        }
        public static ProjectUserProjectDto TranslateProject(this ProjectUser projectUser)
        {
            return new ProjectUserProjectDto
            {
                ID = projectUser.ID,
                Project = projectUser.Project.TranslateSummary(),
                ProjectRole = projectUser.Role.Translate(),
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