namespace Raccord.API.ViewModels.Users.Project.Crew
{
    // Creates a new crew member and links it to a user
    public class CreateUserCrewMemberViewModel
    {
      /// <summary>
      /// ID of the project user
      /// </summary>
      /// <returns></returns>
      public long ProjectUserID { get; set; }

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