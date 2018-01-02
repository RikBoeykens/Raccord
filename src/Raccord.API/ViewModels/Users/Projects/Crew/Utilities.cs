using Raccord.Application.Core.Services.Users.Project.Crew;

namespace Raccord.API.ViewModels.Users.Project.Crew
{
  public static class Utilities
  {
    public static CreateUserCrewMemberDto Translate(this CreateUserCrewMemberViewModel vm)
    {
      if(vm == null)
      {
        return null;
      }

      return new CreateUserCrewMemberDto
      {
        ProjectUserID = vm.ProjectUserID,
        JobTitle = vm.JobTitle,
        DepartmentID = vm.DepartmentID
      };
    }
  }
}