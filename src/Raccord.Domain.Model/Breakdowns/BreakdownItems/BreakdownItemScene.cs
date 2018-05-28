using Raccord.Domain.Model.Scenes;

namespace Raccord.Domain.Model.Breakdowns.BreakdownItems
{
    // join for breakdown item and scene
    public class BreakdownItemScene : Entity<long>
    {

        // ID of the linked breakdown item
        public long BreakdownItemID { get; set; }

        // Linked breakdown item
        public virtual BreakdownItem BreakdownItem { get; set; }

        // ID of the linked location
        public long SceneID { get; set; }

        // Linked location
        public virtual Scene Scene { get; set; }
    }
}