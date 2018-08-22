using System.Collections.Generic;
using Raccord.Core.Enums;

namespace Raccord.API.ViewModels.Charts
{
    // Viewmodel to represent chart info
    public class ChartInfoViewModel
    {
        private IEnumerable<object> _baseData;
        private IEnumerable<ChartSeriesDataViewModel> _seriesData;

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
        public IEnumerable<ChartSeriesDataViewModel> SeriesData
        {
            get
            {
                return _seriesData ?? (_seriesData = new List<ChartSeriesDataViewModel>());
            }
            set
            {
                _seriesData = value;
            }
        }
    }
}