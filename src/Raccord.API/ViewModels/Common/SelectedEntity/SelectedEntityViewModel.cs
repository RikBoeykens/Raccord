using Raccord.Core.Enums;

namespace Raccord.API.ViewModels.Common.SelectedEntity
{
    //  Viewmodel for selected entity functionality
    public class SelectedEntityViewModel
    {
        // ID of the entity
        public long EntityID {get; set;}
        // Entity type
        public EntityType Type {get;set;}
    }
}