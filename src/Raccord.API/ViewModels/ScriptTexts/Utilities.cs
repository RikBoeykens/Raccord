using System.Linq;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Scenes;
using Raccord.Application.Core.Services.ScriptTexts;

namespace Raccord.API.ViewModels.ScriptTexts
{
  public static class Utilities
  {
    public static SceneTextViewModel Translate(this SceneTextDto dto)
    {
      if(dto==null)
      {
        return null;
      }
      return new SceneTextViewModel
      {
        Scene = dto.Scene.Translate(),
        Actions = dto.Actions.Select(a=> a.Translate()),
        Dialogues = dto.Dialogues.Select(a=> a.Translate()),
      };
    }

    public static SceneActionViewModel Translate(this SceneActionDto dto)
    {
      if(dto==null)
      {
        return null;
      }
      return new SceneActionViewModel
      {
        Text = dto.Text,
        Order = dto.Order
      };
    }

    public static SceneDialogueViewModel Translate(this SceneDialogueDto dto)
    {
      if(dto==null)
      {
        return null;
      }
      return new SceneDialogueViewModel
      {
        Text = dto.Text,
        Order = dto.Order,
        Character = dto.Character.Translate(),
      };
    }
  }
}