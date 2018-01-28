using Raccord.Core.Enums;
using System.Collections.Generic;

namespace Raccord.Application.Core.Services.SearchEngine
{
    //  Dto to specify ids that should be excluded
    public class ExcludeTypeIDsDto
    {
        private IEnumerable<long> _ids;
        // Type
        public EntityType Type { get; set;}

        // Ids to exclude
        public IEnumerable<long> IDs
        {
            get
            {
                return _ids ?? (_ids = new List<long>());
            }
            set
            {
                _ids = value;
            }
        }
    }
}