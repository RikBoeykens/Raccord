using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Raccord.Application.Core.Common.Paging;
using Raccord.Application.Core.ExternalServices.Communication.Mail;
using Raccord.Application.Core.Services.Users;
using Raccord.Data.EntityFramework.Repositories.Users;
using Raccord.Domain.Model.Users;
using UserUtilities = Raccord.Application.Services.Users.Utilities;

namespace Raccord.Application.Services.Users
{
    public class UserService : IUserService
    {
        private UserManager<ApplicationUser> _userManager;
        private IUserRepository _userRepository;

        public UserService(
            UserManager<ApplicationUser> userManager,
            IUserRepository userRepository
        )
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public IEnumerable<UserSummaryDto> GetAll()
        {
            var users = _userRepository.GetAll();

            return users.Select(u=> u.TranslateSummary());
        }

        public PagedDataDto<AdminUserSummaryDto> GetAdminPaged(PaginationRequestDto requestDto)
        {
            var users = _userRepository.GetAll();

            return users.GetPaged<ApplicationUser, AdminUserSummaryDto>(requestDto, UserUtilities.TranslateAdminSummary);
        }

        public AdminFullUserDto Get(string ID)
        {
            var user = _userRepository.GetFullAdmin(ID);

            return user.TranslateFullAdmin();
        }

        public UserSummaryDto GetSummary(string ID)
        {
            var user = _userRepository.GetSummary(ID);

            return user.TranslateSummary();
        }

        public async Task<string> Add(CreateUserDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                EmailConfirmed = true,
                PreferredEmail = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                IsDummyUser = dto.IsDummyUser
            };
            var result = await _userManager.CreateAsync(user, dto.Password);

            return user.Id;
        }

        public async Task<string> Update(UserDto dto)
        {
            var user = _userRepository.Get(dto.ID);
            
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;

            await _userManager.UpdateAsync(user);

            return user.Id;
        }

        public async Task Delete(string ID)
        {
            var user = _userRepository.Get(ID);
            await _userManager.DeleteAsync(user);
        }
    }
}