using System.Collections.Generic;
using Raccord.Application.Core.Services.Charts;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Charts
{
    // Service used for character functionality
    public class ChartService : IChartService
    {
        // Initialises a new ChartService
        public ChartService(
            )
        {
        }

        // Gets all characters for a project
        public IEnumerable<ChartInfoDto> GetForProject(long projectID)
        {
            var dtos = new List<ChartInfoDto>
            {
                new ChartInfoDto
                {
                    Title = "Pagelength by day",
                    ChartType = ChartType.Column,
                    DataType = ChartDataType.Pagelength,
                    BaseData = new List<object>{"SD 1", "SD2", "SD 3", "SD 4", "SD 5", "SD 6", "SD 6", "SD 8", "SD 9", "SD 10", "SD 11", "SD 12", "SD 13", "SD 14", "SD 15"},
                    SeriesData = new List<ChartSeriesDataDto>
                    {
                        new ChartSeriesDataDto{ Name = "Pagelength", Data = new List<object>{23, 69, 22, 48, 10, 76, 64, 65, 50, 49, null, null, null, null, null}}
                    }
                },
                new ChartInfoDto
                {
                    Title = "Burndown by pagelength",
                    ChartType = ChartType.Area,
                    DataType = ChartDataType.Pagelength,
                    BaseData = new List<object>{"SD 1", "SD2", "SD 3", "SD 4", "SD 5", "SD 6", "SD 6", "SD 8", "SD 9", "SD 10", "SD 11", "SD 12", "SD 13", "SD 14", "SD 15"},
                    SeriesData = new List<ChartSeriesDataDto>
                    {
                        new ChartSeriesDataDto{ Name = "Burndown", Data = new List<object>{174, 169, 152, 148, 100, 89, 72, 65, 51, 49, null, null, null, null, null}}
                    }
                },
                new ChartInfoDto
                {
                    Title = "Completed by pagelength",
                    ChartType = ChartType.Pie,
                    DataType = ChartDataType.Pagelength,
                    BaseData = new List<object>{"Not Scheduled", "Scheduled but not shot", "Shot"},
                    SeriesData = new List<ChartSeriesDataDto>
                    {
                        new ChartSeriesDataDto{ Name = "", Data = new List<object>{32, 21, 45}}
                    }
                }
            };

            return dtos;
        }
    }
}