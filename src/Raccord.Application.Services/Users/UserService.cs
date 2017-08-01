using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Raccord.Application.Core.Services.Users;
using Raccord.Data.EntityFramework.Repositories.Users;
using Raccord.Domain.Model.Users;

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
            if(userManager==null)
                throw new ArgumentNullException(nameof(userManager));
            if(userRepository==null)
                throw new ArgumentNullException(nameof(userRepository));

            _userManager = userManager;
            _userRepository = userRepository;
        }

        public IEnumerable<UserSummaryDto> GetAll()
        {
            var users = _userRepository.GetAll();

            return users.Select(u=> u.TranslateSummary());
        }

        public FullUserDto Get(string ID)
        {
            var user = _userRepository.GetFull(ID);

            return user.TranslateFull();
        }

        public async Task<string> Add(CreateUserDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                EmailConfirmed = true,
            };
            var result = await _userManager.CreateAsync(user, dto.Password);

            return user.Id;
        }

        public async Task<string> Update(UserDto dto)
        {
            var user = _userRepository.Get(dto.ID);
            
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