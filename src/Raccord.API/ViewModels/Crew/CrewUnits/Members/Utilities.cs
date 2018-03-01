using Raccord.Application.Core.Services.Crew.CrewUnits.Members;

namespace Raccord.API.ViewModels.Crew.CrewUnits.Members
{
  public static class Utilities
  {
    public static CreateUnitCrewMemberDto Translate(this CreateUnitCrewMemberViewModel vm)
    {
      if(vm == null)
      {
        return null;
      }

      return new CreateUnitCrewMemberDto
      {
        CrewUnitMemberID = vm.CrewUnitMemberID,
        JobTitle = vm.JobTitle,
        DepartmentID = vm.DepartmentID
      };
    }
  }
}