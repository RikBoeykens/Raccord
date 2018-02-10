namespace Raccord.API.ViewModels.Breakdowns
{
  public class BaseBreakdownViewModel
  {
    public long ID { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public long ProjectID { get; set; }
  }
}