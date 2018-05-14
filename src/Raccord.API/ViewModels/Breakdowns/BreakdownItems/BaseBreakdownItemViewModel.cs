namespace Raccord.API.ViewModels.Breakdowns.BreakdownItems
{
  // Viewmodel to represent a breakdown item
  public class BaseBreakdownItemViewModel
  {
    // ID of the breakdown item
    public long ID { get; set; }

    /// Name of the breakdown item
    public string Name { get; set; }

    /// Description of the breakdown item
    public string Description { get; set; }
  }
}