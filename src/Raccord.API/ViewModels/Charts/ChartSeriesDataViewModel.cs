using System.Collections.Generic;

namespace Raccord.API.ViewModels.Charts
{
    // Viewmodel to represent chart series data
    public class ChartSeriesDataViewModel
    {
        private IEnumerable<object> _data;

        // Name of the series
        public string Name { get;set;}

        // Data in the series
        public IEnumerable<object> Data
        {
            get
            {
                return _data ?? (_data = new List<object>());
            }
            set
            {
                _data = value;
            }
        }
    }
}