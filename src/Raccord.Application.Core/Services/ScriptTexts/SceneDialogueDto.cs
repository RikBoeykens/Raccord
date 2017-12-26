using Raccord.Application.Core.Services.Characters;

namespace Raccord.Application.Core.Services.ScriptTexts
{
  public class SceneDialogueDto
  {
    private CharacterDto _character;

    // Text of the scene component
    public string Text { get; set; }

    // Order within the scene
    public int Order { get; set; }

    // Character saying the dialogue
    public CharacterDto Character
    {
      get
      {
        return _character ?? (_character = new CharacterDto());
      }
      set
      {
        _character = value;
      }
    }
  }
}