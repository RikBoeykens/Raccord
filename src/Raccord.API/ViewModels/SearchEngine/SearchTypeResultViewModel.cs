using System.Collections.Generic;

namespace Raccord.API.ViewModels.SearchEngine
{
    // ViewModel to represent details for a single search type
    public class SearchTypeResultViewModel
    {
        private IEnumerable<SearchResultViewModel> _results;

        // Full amount of results
        public int Count { get; set; }

        // Type of search
        public string Type { get; set; }

        // Search results
        public IEnumerable<SearchResultViewModel> Results
        {
            get
            {
                return _results ?? (_results = new List<SearchResultViewModel>());
            }
            set
            {
                _results = value;
            }
        }
    }
}