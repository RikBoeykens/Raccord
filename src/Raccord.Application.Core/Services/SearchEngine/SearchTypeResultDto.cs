using System.Collections.Generic;

namespace Raccord.Application.Core.Services.SearchEngine
{
    // Dto to represent details for a single search type
    public class SearchTypeResultDto
    {
        private IEnumerable<SearchResultDto> _results;

        // Full amount of results
        public int Count { get; set; }

        // Type of search
        public string Type { get; set; }

        // Search results
        public IEnumerable<SearchResultDto> Results
        {
            get
            {
                return _results ?? (_results = new List<SearchResultDto>());
            }
            set
            {
                _results = value;
            }
        }
    }
}