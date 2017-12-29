namespace Raccord.API.ViewModels.Profile
{
  public class UserProfileViewModel
  {
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