namespace Raccord.Domain.Model.Scenes.Actions
{
  // Action in a scene
  public class SceneAction : Entity
  {
    // Text of the action
    public string Text { get; set; }

    // Order within the scene
    public int Order { get; set; }

    // ID of the linked scene
    public long SceneID { get; set; }

    // Linked scene
    public virtual Scene Scene { get; set; }
  }
}