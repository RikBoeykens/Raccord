namespace Raccord.API.ViewModels.ScriptTexts
{
  public class SceneActionViewModel
  {
    // Text of the scene component
    public string Text { get; set; }

    // Order within the scene
    public int Order { get; set; }

    // Type of scene component
    public string Type = "action";
  }
}