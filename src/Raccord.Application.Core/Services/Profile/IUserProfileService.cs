using System.Threading.Tasks;

namespace Raccord.Application.Core.Services.Profile
{
  public interface IUserProfileService
  {
    UserProfileDto GetProfile(string ID);
    UserProfileSummaryDto GetProfileSummary(string ID);
    UserProfileDto UpdateProfile(UserProfileDto dto, string ID);
    ProfileImageContentDto GetProfileImage(string ID);
    void AddProfileImage(AddProfileImageDto dto);
    void RemoveProfileImage(string ID);
  }
}