using System.Collections.Generic;
using Raccord.Core.Enums;

namespace Raccord.Application.Core.Services.Charts
{
    // Dto to represent chart info
    public class ChartInfoDto
    {
        private IEnumerable<object> _baseData;
        private IEnumerable<ChartSeriesDataDto> _seriesData;

        // Title of the chart
        public string Title { get; set; }

        // Chart type
        public ChartType ChartType { get; set; }

        // Chart Data Type
        public ChartDataType DataType { get; set; }
        public int ChartWidth { get; set; }

        // Base data
        public IEnumerable<object> BaseData
        {
            get
            {
                return _baseData ?? (_baseData = new List<object>());
            }
            set
            {
                _baseData = value;
            }
        }

        // Series data
        public IEnumerable<ChartSeriesDataDto> SeriesData
        {
            get
            {
                return _seriesData ?? (_seriesData = new List<ChartSeriesDataDto>());
            }
            set
            {
                _seriesData = value;
            }
        }
    }
}