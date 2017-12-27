namespace Raccord.Application.Core.Services.Breakdowns.BreakdownItems
{
  public class CallsheetBreakdownItemDto
  {
    // ID of the breakdown item
    public long ID { get; set; }

    /// Name of the breakdown item
    public string Name { get; set; }

    /// Description of the breakdown item
    public string Description { get; set; }
  }
}