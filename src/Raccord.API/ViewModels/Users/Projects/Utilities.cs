using System.Linq;
using Raccord.API.ViewModels.Crew.CrewMembers;
using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Users;
using Raccord.Application.Core.Services.Users.Project;

namespace Raccord.API.ViewModels.Users.Projects
{
    public static class Utilities
    {
        public static FullProjectUserViewModel Translate(this FullProjectUserDto dto)
        {
            return new FullProjectUserViewModel
            {
                ID = dto.ID,
                Project = dto.Project.Translate(),
                User = dto.User.Translate(),
                CrewMembers = dto.CrewMembers.Select(cm=> cm.Translate()),
            };
        }
        public static ProjectUserProjectViewModel Translate(this ProjectUserProjectDto dto)
        {
            return new ProjectUserProjectViewModel
            {
                ID = dto.ID,
                Project = dto.Project.Translate(),
            };
        }
        public static ProjectUserUserViewModel Translate(this ProjectUserUserDto dto)
        {
            return new ProjectUserUserViewModel
            {
                ID = dto.ID,
                User = dto.User.Translate()
            };
        }
        public static ProjectUserViewModel Translate(this ProjectUserDto dto)
        {
            return new ProjectUserViewModel
            {
                ID = dto.ID,
                ProjectID = dto.ProjectID,
                UserID = dto.UserID,
            };
        }
        public static ProjectUserDto Translate(this ProjectUserViewModel vm)
        {
            return new ProjectUserDto
            {
                ID = vm.ID,
                ProjectID = vm.ProjectID,
                UserID = vm.UserID,
            };
        }
    }
}