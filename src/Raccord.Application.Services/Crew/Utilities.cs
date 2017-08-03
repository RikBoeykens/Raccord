using System.Linq;
using Raccord.Application.Core.Services.Crew;
using Raccord.Application.Services.Projects;
using Raccord.Application.Services.Users;
using Raccord.Core.Enums;
using Raccord.Domain.Model.Crew;

namespace Raccord.Application.Services.Crew
{
    // Utilities and helper methods for Schedule Scenes
    public static class Utilities
    {
        public static FullCrewUserDto TranslateFull(this CrewUser crewUser)
        {
            return new FullCrewUserDto
            {
                ID = crewUser.ID,
                User = crewUser.User.Translate(),
                Project = crewUser.Project.Translate(),
            };
        }
        public static CrewUserUserDto TranslateUser(this CrewUser crewUser)
        {
            return new CrewUserUserDto
            {
                ID = crewUser.ID,
                User = crewUser.User.Translate(),
            };
        }
        public static CrewUserProjectDto TranslateProject(this CrewUser crewUser)
        {
            return new CrewUserProjectDto
            {
                ID = crewUser.ID,
                Project = crewUser.Project.Translate(),
            };
        }
        public static CrewUserDto Translate(this CrewUser crewUser)
        {
            return new CrewUserDto
            {
                ID = crewUser.ID,
                UserID = crewUser.UserID,
                ProjectID = crewUser.ProjectID,
            };
        }
    }
}