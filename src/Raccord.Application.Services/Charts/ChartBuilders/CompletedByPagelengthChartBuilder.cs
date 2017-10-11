using System.Collections.Generic;
using Raccord.Application.Core.Services.Charts;
using Raccord.Application.Core.Services.Charts.ChartBuilders;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Charts.ChartBuilders
{
    public class CompletedByPagelengthChartBuilder: ICompletedByPagelengthChartBuilder
    {
        public CompletedByPagelengthChartBuilder(){}

        public new ChartInfoType GetType()
        {
            return ChartInfoType.CompletedByPagelength;
        }

        public ChartInfoDto GetChartInfo(ChartRequestDto request)
        {
            return new ChartInfoDto
            {
                Title = "Completed by pagelength",
                ChartType = ChartType.Pie,
                DataType = ChartDataType.Pagelength,
                BaseData = new List<object>{"Not Scheduled", "Scheduled but not shot", "Shot"},
                SeriesData = new List<ChartSeriesDataDto>
                {
                    new ChartSeriesDataDto{ Name = "", Data = new List<object>{32, 21, 45}}
                }
            };
        }
    }
}