using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Raccord.Application.Core.Services.Profile;
using Raccord.Data.EntityFramework.Repositories.Users;
using Raccord.Domain.Model.Users;

namespace Raccord.Application.Services.Profile
{
  public class UserProfileService: IUserProfileService
  {
    private UserManager<ApplicationUser> _userManager;
    private IUserRepository _userRepository;
    public UserProfileService(
      UserManager<ApplicationUser> userManager,
      IUserRepository userRepository
    )
    {
      _userManager = userManager;
      _userRepository = userRepository;
    }

    public UserProfileDto GetProfile(string ID)
    {
      var user = _userRepository.Get(ID);

      return user.Translate();
    }

    public async Task<UserProfileDto> UpdateProfile(UserProfileDto dto)
    {
      var user = _userRepository.Get(dto.ID);
      
      user.FirstName = dto.FirstName;
      user.LastName = dto.LastName;
      user.Telephone = dto.Telephone;
      user.PreferredEmail = dto.PreferredEmail;

      await _userManager.UpdateAsync(user);

      return user.Translate();
    }
  }
}