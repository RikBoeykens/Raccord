using Raccord.Application.Core.Services.Profile;
using Raccord.Domain.Model.Users;

namespace Raccord.Application.Services.Profile
{
  public static class Utilities
  {
    public static UserProfileDto Translate(this ApplicationUser user)
    {
      if(user == null)
      {
        return null;
      }

      return new UserProfileDto
      {
        ID = user.Id,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Telephone = user.Telephone,
        PreferredEmail = user.PreferredEmail,
        HasImage = user.ImageContent != null
      };
    }
  }
}