using System.Collections.Generic;
using Raccord.Application.Core.Services.Scenes;

namespace Raccord.Application.Core.Services.ScriptTexts
{
  public class SceneTextDto
  {
    private SceneDto _scene;
    private IEnumerable<SceneActionDto> _actions;
    private IEnumerable<SceneDialogueDto> _dialogues;

    /// <summary>
    /// Scene info
    /// </summary>
    /// <returns></returns>
    public SceneDto Scene
    {
      get
      {
        return _scene ?? (_scene = new SceneDto());
      }
      set
      {
        _scene = value;
      }
    }

    /// <summary>
    /// Actions on a scene
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SceneActionDto> Actions
    {
      get
      {
        return _actions ?? (_actions = new List<SceneActionDto>());
      }
      set
      {
        _actions = value;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SceneDialogueDto> Dialogues
    {
      get
      {
        return _dialogues ?? (_dialogues = new List<SceneDialogueDto>());
      }
      set
      {
        _dialogues = value;
      }
    }
  }
}