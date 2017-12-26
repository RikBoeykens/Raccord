using System.Collections.Generic;
using Raccord.API.ViewModels.Scenes;
using Raccord.Application.Core.Services.Scenes;

namespace Raccord.API.ViewModels.ScriptTexts
{
  public class SceneTextViewModel
  {
    private SceneViewModel _scene;
    private IEnumerable<SceneActionViewModel> _actions;
    private IEnumerable<SceneDialogueViewModel> _dialogues;

    /// <summary>
    /// Scene info
    /// </summary>
    /// <returns></returns>
    public SceneViewModel Scene
    {
      get
      {
        return _scene ?? (_scene = new SceneViewModel());
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
    public IEnumerable<SceneActionViewModel> Actions
    {
      get
      {
        return _actions ?? (_actions = new List<SceneActionViewModel>());
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
    public IEnumerable<SceneDialogueViewModel> Dialogues
    {
      get
      {
        return _dialogues ?? (_dialogues = new List<SceneDialogueViewModel>());
      }
      set
      {
        _dialogues = value;
      }
    }
  }
}