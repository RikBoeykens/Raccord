using Raccord.Core.Enums;
using System.Collections.Generic;

namespace Raccord.API.ViewModels.SearchEngine
{
    // Viewmodel for making search requests
    public class SearchRequestViewModel
    {
        private IEnumerable<SearchType> _includeTypes { get; set; }
        private IEnumerable<SearchType> _excludeTypes { get; set; }
        // Text to search on
        public string SearchText { get; set; }

        // Types to search for (if applicable)
        public IEnumerable<SearchType> IncludeTypes
        {
            get
            {
                return _includeTypes ?? (_includeTypes = new List<SearchType>());
            }
            set
            {
                _includeTypes = value;
            }
        }

        // Types to exclude (if applicable)
        public IEnumerable<SearchType> ExcludeTypes
        {
            get
            {
                return _excludeTypes ?? (_excludeTypes = new List<SearchType>());
            }
            set
            {
                _excludeTypes = value;
            }
        }

        // ProjectID of the project to search in (if applicable)
        public long? ProjectID { get; set; }
    }
}