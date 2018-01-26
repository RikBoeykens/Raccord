using Raccord.Core.Enums;
using System.Collections.Generic;

namespace Raccord.Application.Core.Services.SearchEngine
{
    //  Dto to represent a request for the search engine
    public class SearchRequestDto
    {
        private IEnumerable<EntityType> _includeTypes { get; set; }
        private IEnumerable<EntityType> _excludeTypes { get; set; }
        private IEnumerable<ExcludeTypeIDsDto> _excludeTypeIDs { get; set; }
        // Text to search on
        public string SearchText { get; set; }

        // Types to search for (if applicable)
        public IEnumerable<EntityType> IncludeTypes
        {
            get
            {
                return _includeTypes ?? (_includeTypes = new List<EntityType>());
            }
            set
            {
                _includeTypes = value;
            }
        }

        // Types to exclude (if applicable)
        public IEnumerable<EntityType> ExcludeTypes
        {
            get
            {
                return _excludeTypes ?? (_excludeTypes = new List<EntityType>());
            }
            set
            {
                _excludeTypes = value;
            }
        }

        // ProjectID of the project to search in (if applicable)
        public long? ProjectID { get; set; }

        // UserID of the user to search for
        public string UserID { get; set; }

        // Search regardless of user id
        public bool IsAdminSearch { get; set; }

        // Type IDs to exclude (if applicable)
        public IEnumerable<ExcludeTypeIDsDto> ExcludeTypeIDs
        {
            get
            {
                return _excludeTypeIDs ?? (_excludeTypeIDs = new List<ExcludeTypeIDsDto>());
            }
            set
            {
                _excludeTypeIDs = value;
            }
        }
    }
}