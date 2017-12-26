using Raccord.API.ViewModels.Characters;

namespace Raccord.API.ViewModels.ScriptTexts
{
  public class SceneDialogueViewModel
  {
    private CharacterViewModel _character;

    // Text of the scene component
    public string Text { get; set; }

    // Order within the scene
    public int Order { get; set; }

    // Type of scene component
    public string Type = "dialogue";

    // Character saying the dialogue
    public CharacterViewModel Character
    {
      get
      {
        return _character ?? (_character = new CharacterViewModel());
      }
      set
      {
        _character = value;
      }
    }
  }
}