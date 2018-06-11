namespace Raccord.Application.Core.Services.Crew.CrewUnits.Members
{
    // Creates a new crew member and links it to a crew unit member
    public class CreateCrewUnitMemberCrewMemberDto
    {
      /// <summary>
      /// ID of the crew unit member
      /// </summary>
      /// <returns></returns>
      public long CrewUnitMemberID { get; set; }

      /// <summary>
      /// Job title of the crew member
      /// </summary>
      /// <returns></returns>
      public string JobTitle { get; set; }

      /// <summary>
      /// ID of the linked department
      /// </summary>
      /// <returns></returns>
      public long DepartmentID { get; set; }
    }
}