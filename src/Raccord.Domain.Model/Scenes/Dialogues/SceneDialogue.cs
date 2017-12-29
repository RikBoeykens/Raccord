using Raccord.Domain.Model.Characters;

namespace Raccord.Domain.Model.Scenes.Dialogues
{
  public class SceneDialogue : Entity
  {
    // Text of the action
    public string Text { get; set; }

    // Order within the scene
    public int Order { get; set; }

    // ID of the linked character
    public long CharacterID { get; set; }

    // Linked character
    public virtual Character Character { get; set; }

    // ID of the linked scene
    public long SceneID { get; set; }

    // Linked scene
    public virtual Scene Scene { get; set; }
  }
}