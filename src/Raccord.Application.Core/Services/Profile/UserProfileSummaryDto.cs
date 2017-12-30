namespace Raccord.Application.Core.Services.Profile
{
  public class UserProfileSummaryDto
  {
    /// <summary>
    /// ID of the user
    /// </summary>
    /// <returns></returns>
    public string ID { get; set; }

    /// <summary>
    /// First name of the user
    /// </summary>
    /// <returns></returns>
    public string FirstName { get; set; }

    /// <summary>
    /// Last name of the user
    /// </summary>
    /// <returns></returns>
    public string LastName { get; set; }

    /// <summary>
    /// Indicates if the user has an image
    /// </summary>
    /// <returns></returns>
    public bool HasImage { get; set; }
  }
}