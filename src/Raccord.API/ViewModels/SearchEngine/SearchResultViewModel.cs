using Raccord.Core.Enums;

namespace Raccord.API.ViewModels.SearchEngine
{
    // Viewmodel for a single search result
    public class SearchResultViewModel
    {
        // ID
        public long[] RouteIDs { get; set; }

        // Display name
        public string DisplayName { get; set; }

        // Search result type
        public SearchType Type { get; set; }

        // Optional extra info
        public string Info { get; set; }
    }
}