using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Application.Core.Common.Sorting;

namespace Raccord.API.ViewModels.Common.Sorting
{
    public static class Utilities
    {
        // Translates a sort order vm to a sort order dto
        public static SortOrderDto Translate(this SortOrderViewModel vm)
        {
            return new SortOrderDto
            {
                ParentID = vm.ParentID,
                SortIDs = vm.SortIDs,
            };
        }
    }
}