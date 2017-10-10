using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Charts
{
    // Interface for character scene functionality
    public interface IChartService
    {
        IEnumerable<ChartInfoDto> GetForProject(long projectID);
    }
}