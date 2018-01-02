namespace Raccord.API.ViewModels.Profile
{
  public class UserProfileViewModel : UserProfileSummaryViewModel
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