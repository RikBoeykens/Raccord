using System.Collections.Generic;

namespace Raccord.Application.Core.Services.SearchEngine
{
    // Interface for a search engine service wrapper
    public interface ISearchEngineServiceWrapper
    {
        //  Returns multiple results for a search request
        IEnumerable<SearchTypeResultDto> GetResults(SearchRequestDto requestDto);
    }
}