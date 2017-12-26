using System.Linq;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.ScriptLocations;
using Raccord.Application.Core.Services.ScriptUploads;

namespace Raccord.API.ViewModels.ScriptUploads
{
  // Helpers and extensions for script upload
  public static class Utilities
  {
    public static FullScriptUploadViewModel Translate(this FullScriptUploadDto dto)
    {
      return new FullScriptUploadViewModel
      {
        ID = dto.ID,
        FileName = dto.FileName,
        Start = dto.Start,
        End = dto.End,
        Scenes = dto.Scenes.Select(s => s.Translate()),
        Characters = dto.Characters.Select(c=> c.Translate()),
        ScriptLocations = dto.ScriptLocations.Select(sc=> sc.Translate()),
      };
    }
  }
}