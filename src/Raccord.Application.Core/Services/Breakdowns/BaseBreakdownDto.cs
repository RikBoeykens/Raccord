namespace Raccord.Application.Core.Services.Breakdowns
{
  public class BaseBreakdownDto
  {
    public long ID { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public long ProjectID { get; set; }
  }
}