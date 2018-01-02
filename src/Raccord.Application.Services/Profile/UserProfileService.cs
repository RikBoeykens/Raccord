using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Raccord.Application.Core.Services.Profile;
using Raccord.Application.Services.Images;
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

    public UserProfileDto UpdateProfile(UserProfileDto dto, string ID)
    {
      var user = _userRepository.Get(ID);
      
      user.FirstName = dto.FirstName;
      user.LastName = dto.LastName;
      user.Telephone = dto.Telephone;
      user.PreferredEmail = dto.PreferredEmail;

      _userRepository.Edit(user);
      _userRepository.Commit();

      return user.Translate();
    }

    public ProfileImageContentDto GetProfileImage(string ID)
    {
      var user = _userRepository.Get(ID);
      return new ProfileImageContentDto
      {
        FileName = user.ImageName,
        FileContent = user.ImageContent
      };
    }

    public void AddProfileImage(AddProfileImageDto dto)
    {
      var user = _userRepository.Get(dto.ID);
      using(var imageContent = dto.FileContent)
      {
        user.ImageName = dto.FileName;
        user.ImageContent = imageContent.GetBytes();

        _userRepository.Edit(user);
        _userRepository.Commit();
      }
    }

    public void RemoveProfileImage(string ID)
    {
      var user = _userRepository.Get(ID);
      
      user.ImageContent = null;
      user.ImageName = null;

      _userRepository.Edit(user);
      _userRepository.Commit();
    }
  }
}