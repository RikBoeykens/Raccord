using System.IO;

namespace Raccord.Application.Core.Services.Profile
{
  public class AddProfileImageDto
  {
    /// <summary>
    /// ID of the user
    /// </summary>
    /// <returns></returns>
    public string ID { get; set; }

    /// <summary>
    /// Contents of the image
    /// </summary>
    /// <returns></returns>
    public Stream FileContent { get; set; }
  }
}