using Raccord.Core.Enums;

namespace Raccord.Application.Core.Common.SelectedEntity
{
    //  Dto for selected entity functionality
    public class SelectedEntityDto
    {
        // ID of the entity
        public long EntityID {get; set;}
        // Entity type
        public EntityType Type {get;set;}
    }
}