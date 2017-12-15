using Raccord.Application.Core.Services.ScriptUpload;

namespace Raccord.API.ViewModels.ScriptUpload
{
  // Helpers and extensions for script upload
  public static class Utilities
  {
    // Translates a script upload response to a vm
    public static ScriptUploadResponseViewModel Translate(this ScriptUploadResponseDto dto)
    {
      return new ScriptUploadResponseViewModel
      {
        ProjectID = dto.ProjectID,
        TotalScenes = dto.TotalScenes,
        TotalCharacters = dto.TotalCharacters,
        TotalLocations = dto.TotalLocations
      };
    }

  }
}