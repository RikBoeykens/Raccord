namespace Raccord.Application.Core.Services.Profile
{
  public class UserProfileDto : UserProfileSummaryDto
  {
    /// <summary>
    /// Telephone number for the user
    /// </summary>
    /// <returns></returns>
    public string Telephone { get; set; }

    /// <summary>
    /// Preferred email for the user
    /// </summary>
    /// <returns></returns>
    public string PreferredEmail { get; set; }
  }
}