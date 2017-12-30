using System.Threading.Tasks;

namespace Raccord.Application.Core.Services.Profile
{
  public interface IUserProfileService
  {
    UserProfileDto GetProfile(string ID);
    Task<UserProfileDto> UpdateProfile(UserProfileDto dto, string ID);
    ProfileImageContentDto GetProfileImage(string ID);
    Task AddProfileImage(AddProfileImageDto dto);
    Task RemoveProfileImage(string ID);
  }
}