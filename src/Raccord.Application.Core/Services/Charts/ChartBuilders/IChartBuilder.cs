using Raccord.Core.Enums;

namespace Raccord.Application.Core.Services.Charts.ChartBuilders
{
    // Interface for a search engine service for a specific type
    public interface IChartBuilder
    {
        //  Returns the specific type this search engine service is for
        ChartInfoType GetType();

        //  Returns search type result for a search request
        ChartInfoDto GetChartInfo(ChartRequestDto request);
    }
}