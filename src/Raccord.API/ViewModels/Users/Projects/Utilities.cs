using System.Linq;
using Raccord.API.ViewModels.Cast;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Crew.CrewMembers;
using Raccord.API.ViewModels.Crew.CrewUnits;
using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Users;
using Raccord.API.ViewModels.Users.ProjectRoles;
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
                CastMember = dto.CastMember.Translate(),
                ProjectRole = dto.ProjectRole.Translate(),
                CrewUnits = dto.CrewUnits.Select(cu => cu.Translate())
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
        public static LinkedProjectUserUserViewModel Translate(this LinkedProjectUserUserDto dto)
        {
            return new LinkedProjectUserUserViewModel
            {
                ID = dto.ID,
                User = dto.User.Translate(),
                LinkID = dto.LinkID
            };
        }
        public static ProjectUserViewModel Translate(this ProjectUserDto dto)
        {
            return new ProjectUserViewModel
            {
                ID = dto.ID,
                ProjectID = dto.ProjectID,
                UserID = dto.UserID,
                RoleID = dto.RoleID
            };
        }
        public static ProjectUserDto Translate(this ProjectUserViewModel vm)
        {
            return new ProjectUserDto
            {
                ID = vm.ID,
                ProjectID = vm.ProjectID,
                UserID = vm.UserID,
                RoleID = vm.RoleID
            };
        }
    }
}