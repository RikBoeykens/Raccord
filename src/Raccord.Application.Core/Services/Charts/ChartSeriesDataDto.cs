using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Charts
{
    // Dto to represent chart series data
    public class ChartSeriesDataDto
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