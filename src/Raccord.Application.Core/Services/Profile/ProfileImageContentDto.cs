namespace Raccord.Application.Core.Services.Profile
{
  public class ProfileImageContentDto
  {
    /// <summary>
    /// Filename of the image
    /// </summary>
    /// <returns></returns>
    public string FileName { get; set; }
    /// <summary>
    /// Content of the image
    /// </summary>
    /// <returns></returns>
    public byte[] FileContent { get; set; }
  }
}