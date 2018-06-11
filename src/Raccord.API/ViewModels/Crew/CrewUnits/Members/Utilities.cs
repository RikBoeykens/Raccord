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
        CrewUnitMemberID = vm.CrewUnitMemberID,
        JobTitle = vm.JobTitle,
        DepartmentID = vm.DepartmentID
      };
    }
    public static CreateCrewUnitInvitationMemberCrewMemberDto Translate(this CreateCrewUnitInvitationMemberCrewMemberViewModel vm)
    {
      if(vm == null)
      {
        return null;
      }

      return new CreateCrewUnitInvitationMemberCrewMemberDto
      {
        CrewUnitInvitationMemberID = vm.CrewUnitInvitationMemberID,
        JobTitle = vm.JobTitle,
        DepartmentID = vm.DepartmentID
      };
    }
  }
}