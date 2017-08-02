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
                Password = vm.Password
            };
        }

        public static FullUserViewModel Translate(this FullUserDto dto)
        {
            return new FullUserViewModel
            {
                ID = dto.ID,
                Email = dto.Email,
            };
        }

        public static UserSummaryViewModel Translate(this UserSummaryDto dto)
        {
            return new UserSummaryViewModel
            {
                ID = dto.ID,
                Email = dto.Email,
            };
        }

        public static UserViewModel Translate(this UserDto dto)
        {
            return new UserViewModel
            {
                ID = dto.ID,
                Email = dto.Email,
            };
        }

        public static UserDto Translate(this UserViewModel vm)
        {
            return new UserDto
            {
                ID = vm.ID,
                Email = vm.Email,
            };
        }
    }
}