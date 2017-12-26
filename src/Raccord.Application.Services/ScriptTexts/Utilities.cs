using System.Linq;
using Raccord.Application.Core.Services.ScriptTexts;
using Raccord.Application.Services.Characters;
using Raccord.Application.Services.Scenes;
using Raccord.Domain.Model.Scenes;
using Raccord.Domain.Model.Scenes.Actions;
using Raccord.Domain.Model.Scenes.Dialogues;

namespace Raccord.Application.Services.ScriptTexts
{
  public static class Utilities
  {
    public static SceneTextDto TranslateScript(this Scene scene)
    {
      if (scene == null)
      {
        return null;
      }

      return new SceneTextDto
      {
        Scene = scene.Translate(),
        Actions = scene.Actions.Select(a=> a.Translate()),
        Dialogues = scene.Dialogues.Select(a=> a.Translate()),
      };
    }

    public static SceneActionDto Translate(this SceneAction action)
    {
      if (action == null)
      {
        return null;
      }

      return new SceneActionDto
      {
        Text = action.Text,
        Order = action.Order,
      };
    }

    public static SceneDialogueDto Translate(this SceneDialogue dialogue)
    {
      if (dialogue == null)
      {
        return null;
      }

      return new SceneDialogueDto
      {
        Text = dialogue.Text,
        Order = dialogue.Order,
        Character = dialogue.Character.Translate(),
      };
    }
  }
}