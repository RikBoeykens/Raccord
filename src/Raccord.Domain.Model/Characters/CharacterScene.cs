using Raccord.Domain.Model.Scenes;

namespace Raccord.Domain.Model.Characters
{
    // join for character and scene
    public class CharacterScene : Entity
    {

        // ID of the linked image
        public long CharacterID { get; set; }

        // Linked image
        public virtual Character Character { get; set; }

        // ID of the linked location
        public long SceneID { get; set; }

        // Linked location
        public virtual Scene Scene { get; set; }
    }
}