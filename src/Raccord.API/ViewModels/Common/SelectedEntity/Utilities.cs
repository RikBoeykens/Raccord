using Raccord.Application.Core.Common.SelectedEntity;

namespace Raccord.API.ViewModels.Common.SelectedEntity
{
    public static class Utilities
    {
        // Translates a sort order vm to a sort order dto
        public static SelectedEntityDto Translate(this SelectedEntityViewModel vm)
        {
            return new SelectedEntityDto
            {
                EntityID = vm.EntityID,
                Type = vm.Type,
            };
        }
    }
}