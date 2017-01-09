using Raccord.Core.Enums;

namespace Raccord.API.ViewModels.SearchEngine
{
    // Viewmodel for a single search result
    public class SearchResultViewModel
    {
        // ID of the result
        public long ID { get; set; }
        // IDs
        public long[] RouteIDs { get; set; }

        // Display name
        public string DisplayName { get; set; }

        // Search result type
        public SearchType Type { get; set; }

        // Optional extra info
        public string Info { get; set; }
    }
}