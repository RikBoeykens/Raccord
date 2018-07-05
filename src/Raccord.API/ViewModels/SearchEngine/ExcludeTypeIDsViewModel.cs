using Raccord.Core.Enums;
using System.Collections.Generic;

namespace Raccord.API.ViewModels.SearchEngine
{
    //  Dto to specify ids that should be excluded
    public class ExcludeTypeIDsViewModel
    {
        private IEnumerable<object> _ids;
        // Type
        public EntityType Type { get; set;}

        // Ids to exclude
        public IEnumerable<object> IDs
        {
            get
            {
                return _ids ?? new List<object>();
            }
            set
            {
                _ids = value;
            }
        }
    }
}