using System.Linq;
using Raccord.Application.Core.Services.Charts;

namespace Raccord.API.ViewModels.Charts
{
    public static class Utilities
    {
        // Translates ChartInfoDto to Vm
        public static ChartInfoViewModel Translate(this ChartInfoDto dto)
        {
            return new ChartInfoViewModel
            {
                Title = dto.Title,
                ChartType = dto.ChartType,
                DataType = dto.DataType,
                BaseData = dto.BaseData,
                ChartWidth = dto.ChartWidth,
                SeriesData = dto.SeriesData.Select(sd=> sd.Translate()),
            };
        }

        // Translates Chart Series Data Dto to Vm
        public static ChartSeriesDataViewModel Translate(this ChartSeriesDataDto dto)
        {
            return new ChartSeriesDataViewModel
            {
                Name = dto.Name,
                Data = dto.Data,
            };
        }
    }
}