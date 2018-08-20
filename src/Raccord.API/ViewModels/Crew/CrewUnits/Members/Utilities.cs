using Raccord.Application.Core.Services.Crew.CrewUnits.Members;

namespace Raccord.API.ViewModels.Crew.CrewUnits.Members
{
  public static class Utilities
  {
    public static CreateCrewUnitMemberCrewMemberDto Translate(this CreateCrewUnitMemberCrewMemberViewModel vm)
    {
      if(vm == null)
      {
        return null;
      }

      return new CreateCrewUnitMemberCrewMemberDto
      {
        LinkID = vm.LinkID,
        JobTitle = vm.JobTitle,
        DepartmentID = vm.DepartmentID
      };
    }
  }
}