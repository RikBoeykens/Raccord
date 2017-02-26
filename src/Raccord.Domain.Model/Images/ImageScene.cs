using Raccord.Domain.Model.Scenes;

namespace Raccord.Domain.Model.Images
{
    // join for image and scene
    public class ImageScene : Entity
    {
        // ID of the linked image
        public long ImageID { get; set; }

        // Linked image
        public virtual Image Image { get; set; }

        // ID of the linked scene
        public long SceneID { get; set; }

        // Linked scene
        public virtual Scene Scene { get; set; }
    }
}