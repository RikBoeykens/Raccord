using Raccord.Domain.Model.Characters;

namespace Raccord.Domain.Model.Callsheets.Scenes
{
    // join for character and callsheet scene
    public class CallsheetSceneCharacter : Entity<long>
    {

        // ID of the linked character
        public long CharacterSceneID { get; set; }

        // Linked character
        public virtual CharacterScene CharacterScene { get; set; }

        // ID of the linked schedule scene
        public long CallsheetSceneID { get; set; }

        // Linked schedule scene
        public virtual CallsheetScene CallsheetScene { get; set; }
    }
}