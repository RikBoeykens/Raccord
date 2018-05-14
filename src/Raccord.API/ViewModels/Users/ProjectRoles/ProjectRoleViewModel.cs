using Raccord.Core.Enums;

namespace Raccord.API.ViewModels.Users.ProjectRoles
{
  public class ProjectRoleViewModel
  {
    /// <summary>
    /// ID of the the role
    /// </summary>
    /// <returns></returns>
    public long ID { get; set; }

    /// <summary>
    /// Name of the role
    /// </summary>
    /// <returns></returns>
    public string Name { get; set; }

    /// <summary>
    /// Description of the role
    /// </summary>
    /// <returns></returns>
    public string Description { get; set; }

    /// <summary>
    /// Role on the project role
    /// </summary>
    /// <returns></returns>
    public ProjectRoleEnum Role { get; set; }
  }
}