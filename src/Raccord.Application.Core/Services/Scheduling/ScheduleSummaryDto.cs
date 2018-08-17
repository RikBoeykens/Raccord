using System;
using Raccord.Application.Core.Services.Crew.CrewUnits;

namespace Raccord.Application.Core.Services.Scheduling
{
  public class ScheduleSummaryDto
  {
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
  }
}