using System.Collections.Generic;
using Raccord.Application.Core.Services.Charts;
using Raccord.Application.Core.Services.Charts.ChartBuilders;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Charts.ChartBuilders
{
    public class PageLengthByDayChartBuilder: IPageLengthByDayChartBuilder
    {
        public PageLengthByDayChartBuilder(){}

        public new ChartInfoType GetType()
        {
            return ChartInfoType.PagelengthByDay;
        }

        public ChartInfoDto GetChartInfo(ChartRequestDto request)
        {
            return new ChartInfoDto
            {
                Title = "Pagelength by day",
                ChartType = ChartType.Column,
                DataType = ChartDataType.Pagelength,
                BaseData = new List<object>{"SD 1", "SD2", "SD 3", "SD 4", "SD 5", "SD 6", "SD 6", "SD 8", "SD 9", "SD 10", "SD 11", "SD 12", "SD 13", "SD 14", "SD 15"},
                SeriesData = new List<ChartSeriesDataDto>
                {
                    new ChartSeriesDataDto{ Name = "Pagelength", Data = new List<object>{23, 69, 22, 48, 10, 76, 64, 65, 50, 49, null, null, null, null, null}}
                }
            };
        }
    }
}