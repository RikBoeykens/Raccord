using System;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.ScriptLocations;

namespace Raccord.Application.Core.Services.ScriptUploads
{
  public class FullScriptUploadDto
  {
    private IEnumerable<SceneDto> _scenes;
    private IEnumerable<CharacterDto> _characters;
    private IEnumerable<ScriptLocationDto> _scriptLocations;

    // ID of the script upload
    public long ID { get; set; }

    // File name of the file used to upload
    public string FileName { get; set; }

    // Start of the script upload
    public DateTime Start { get; set; }

    // End of the script upload
    public DateTime? End { get; set; }

    // Scenes added
    public IEnumerable<SceneDto> Scenes
    {
      get
      {
        return _scenes ?? (_scenes = new List<SceneDto>());
      }
      set
      {
        _scenes = value;
      }
    }

    // Characters added
    public IEnumerable<CharacterDto> Characters
    {
      get
      {
        return _characters ?? (_characters = new List<CharacterDto>());
      }
      set
      {
        _characters = value;
      }
    }

    // Script locations added
    public IEnumerable<ScriptLocationDto> ScriptLocations
    {
      get
      {
        return _scriptLocations ?? (_scriptLocations = new List<ScriptLocationDto>());
      }
      set
      {
        _scriptLocations = value;
      }
    }
  }
}