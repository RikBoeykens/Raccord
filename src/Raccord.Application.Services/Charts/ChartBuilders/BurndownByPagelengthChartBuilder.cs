using System.Collections.Generic;
using Raccord.Application.Core.Services.Charts;
using Raccord.Application.Core.Services.Charts.ChartBuilders;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Charts.ChartBuilders
{
    public class BurndownByPagelengthChartBuilder: IBurndownByPagelengthChartBuilder
    {
        public BurndownByPagelengthChartBuilder(){}

        public new ChartInfoType GetType()
        {
            return ChartInfoType.BurndownByPagelength;
        }

        public ChartInfoDto GetChartInfo(ChartRequestDto request)
        {
            return new ChartInfoDto
            {
                Title = "Burndown by pagelength",
                ChartType = ChartType.Area,
                DataType = ChartDataType.Pagelength,
                BaseData = new List<object>{"SD 1", "SD2", "SD 3", "SD 4", "SD 5", "SD 6", "SD 6", "SD 8", "SD 9", "SD 10", "SD 11", "SD 12", "SD 13", "SD 14", "SD 15"},
                SeriesData = new List<ChartSeriesDataDto>
                {
                    new ChartSeriesDataDto{ Name = "Burndown", Data = new List<object>{174, 169, 152, 148, 100, 89, 72, 65, 51, 49, null, null, null, null, null}}
                }
            };
        }
    }
}