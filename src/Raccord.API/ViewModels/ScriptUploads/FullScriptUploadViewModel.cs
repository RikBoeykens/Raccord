using System;
using System.Collections.Generic;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.ScriptLocations;

namespace Raccord.API.ViewModels.ScriptUploads
{
    public class FullScriptUploadViewModel
  {
    private IEnumerable<SceneViewModel> _scenes;
    private IEnumerable<CharacterViewModel> _characters;
    private IEnumerable<ScriptLocationViewModel> _scriptLocations;

    // ID of the script upload
    public long ID { get; set; }

    // File name used to upload
    public string FileName { get; set; }

    // Start of the script upload
    public DateTime Start { get; set; }

    // End of the script upload
    public DateTime? End { get; set; }

    // Scenes added
    public IEnumerable<SceneViewModel> Scenes
    {
      get
      {
        return _scenes ?? (_scenes = new List<SceneViewModel>());
      }
      set
      {
        _scenes = value;
      }
    }

    // Characters added
    public IEnumerable<CharacterViewModel> Characters
    {
      get
      {
        return _characters ?? (_characters = new List<CharacterViewModel>());
      }
      set
      {
        _characters = value;
      }
    }

    // Script locations added
    public IEnumerable<ScriptLocationViewModel> ScriptLocations
    {
      get
      {
        return _scriptLocations ?? (_scriptLocations = new List<ScriptLocationViewModel>());
      }
      set
      {
        _scriptLocations = value;
      }
    }
  }
}