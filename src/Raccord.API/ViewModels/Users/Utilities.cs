using System.Linq;
using Raccord.API.ViewModels.Users.Projects;
using Raccord.Application.Core.Services.Users;

namespace Raccord.API.ViewModels.Users
{
    // Viewmodel to represent a user
    public static class Utilities
    {
        public static CreateUserDto Translate(this CreateUserViewModel vm)
        {
            return new CreateUserDto
            {
                ID = vm.ID,
                Email = vm.Email,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Password = vm.Password
            };
        }

        public static FullUserViewModel Translate(this FullUserDto dto)
        {
            return new FullUserViewModel
            {
                ID = dto.ID,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                HasImage = dto.HasImage
            };
        }

        public static AdminFullUserViewModel Translate(this AdminFullUserDto dto)
        {
            return new AdminFullUserViewModel
            {
                ID = dto.ID,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                HasImage = dto.HasImage,
                Projects = dto.Projects.Select(p => p.Translate())
            };
        }

        public static UserSummaryViewModel Translate(this UserSummaryDto dto)
        {
            return new UserSummaryViewModel
            {
                ID = dto.ID,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                HasImage = dto.HasImage
            };
        }

        public static AdminUserSummaryViewModel Translate(this AdminUserSummaryDto dto)
        {
            return new AdminUserSummaryViewModel
            {
                ID = dto.ID,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                HasImage = dto.HasImage,
                ProjectCount = dto.ProjectCount
            };
        }

        public static UserViewModel Translate(this UserDto dto)
        {
            return new UserViewModel
            {
                ID = dto.ID,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
        }

        public static UserDto Translate(this UserViewModel vm)
        {
            return new UserDto
            {
                ID = vm.ID,
                Email = vm.Email,
                FirstName = vm.FirstName,
                LastName = vm.LastName
            };
        }
    }
}