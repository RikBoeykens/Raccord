using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Users;
using Raccord.Application.Core.Services.Crew;

namespace Raccord.API.ViewModels.Crew
{
    public static class Utilities
    {
        public static FullCrewUserViewModel Translate(this FullCrewUserDto dto)
        {
            return new FullCrewUserViewModel
            {
                ID = dto.ID,
                Project = dto.Project.Translate(),
                User = dto.User.Translate(),
            };
        }
        public static CrewUserProjectViewModel Translate(this CrewUserProjectDto dto)
        {
            return new CrewUserProjectViewModel
            {
                ID = dto.ID,
                Project = dto.Project.Translate(),
            };
        }
        public static CrewUserUserViewModel Translate(this CrewUserUserDto dto)
        {
            return new CrewUserUserViewModel
            {
                ID = dto.ID,
                User = dto.User.Translate(),
            };
        }
        public static CrewUserViewModel Translate(this CrewUserDto dto)
        {
            return new CrewUserViewModel
            {
                ID = dto.ID,
                ProjectID = dto.ProjectID,
                UserID = dto.UserID,
            };
        }
        public static CrewUserDto Translate(this CrewUserViewModel vm)
        {
            return new CrewUserDto
            {
                ID = vm.ID,
                ProjectID = vm.ProjectID,
                UserID = vm.UserID,
            };
        }
    }
}