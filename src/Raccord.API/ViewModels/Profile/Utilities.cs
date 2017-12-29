using Raccord.Application.Core.Services.Profile;

namespace Raccord.API.ViewModels.Profile
{
  public static class Utilities
  {
    public static UserProfileViewModel Translate(this UserProfileDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new UserProfileViewModel
      {
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Telephone = dto.Telephone,
        PreferredEmail = dto.PreferredEmail
      };
    }

    public static UserProfileDto Translate(this UserProfileViewModel vm, string ID)
    {
      if(vm == null)
      {
        return null;
      }

      return new UserProfileDto
      {
        ID = ID,
        FirstName = vm.FirstName,
        LastName = vm.LastName,
        Telephone = vm.Telephone,
        PreferredEmail = vm.PreferredEmail
      };
    }
  }
}