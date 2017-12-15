namespace Raccord.Application.Core.Services.ScriptUpload
{
  public class ScriptUploadResponseDto
  {
    // ID of the linked project
    public long ProjectID { get; set; }

    // Total scenes added
    public int TotalScenes { get; set; }

    // Total locations added
    public int TotalLocations { get; set; }

    // Total characters added
    public int TotalCharacters { get; set; }
  }
}