using System;
using System.Collections.Generic;
using Raccord.Domain.Model.Scenes;
using Raccord.Domain.Model.ScriptLocations;
using Raccord.Domain.Model.Characters;
using Raccord.Domain.Model.Projects;

namespace Raccord.Domain.Model.ScriptUploads
{
  // Keeps information about a script upload
  public class ScriptUpload : Entity
  {
    private ICollection<Scene> _scenes;
    private ICollection<ScriptLocation> _scriptLocations;
    private ICollection<Character> _characters;

    // Name of the file used to upload
    public string FileName { get; set; }

    // Start of the script upload
    public DateTime Start { get; set; }

    // End of the script upload
    public DateTime? End { get; set; }

    // ID of the linked project
    public long ProjectID { get; set; }

    // Linked project
    public virtual Project Project { get; set; }

    // Linked scenes
    public virtual ICollection<Scene> Scenes
    {
      get
      {
        return _scenes ?? (_scenes = new List<Scene>());
      }
      set
      {
        _scenes = value;
      }
    }

    // Linked script locations
    public virtual ICollection<ScriptLocation> ScriptLocations
    {
      get
      {
        return _scriptLocations ?? (_scriptLocations = new List<ScriptLocation>());
      }
      set
      {
        _scriptLocations = value;
      }
    }

    // Linked characters
    public virtual ICollection<Character> Characters
    {
      get
      {
        return _characters ?? (_characters = new List<Character>());
      }
      set
      {
        _characters = value;
      }
    }
  }
}