using Raccord.Core.Enums;

namespace Raccord.Application.Core.Services.SearchEngine
{
    //  Dto to represent a single result from the search engine
    public class SearchResultDto
    {
        // ID of the result
        public long ID { get; set;}
        // IDs to get to the result
        public long[] RouteIDs { get; set; }

        // Display name
        public string DisplayName { get; set; }

        // Search result type
        public EntityType Type { get; set; }

        // Optional extra info
        public string Info { get; set; }
    }
}