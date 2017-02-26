using Raccord.Core.Enums;

namespace Raccord.Application.Core.Services.SearchEngine
{
    // Interface for a search engine service for a specific type
    public interface ITypeSearchEngineService
    {
        //  Returns the specific type this search engine service is for
        EntityType GetType();

        //  Returns search type result for a search request
        SearchTypeResultDto GetResults(SearchRequestDto requestDto);
    }
}