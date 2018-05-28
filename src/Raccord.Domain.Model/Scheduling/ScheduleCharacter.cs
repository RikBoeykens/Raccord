using Raccord.Domain.Model.Characters;

namespace Raccord.Domain.Model.Scheduling
{
    // join for character and schedule scene
    public class ScheduleCharacter : Entity<long>
    {

        // ID of the linked character
        public long CharacterSceneID { get; set; }

        // Linked character
        public virtual CharacterScene CharacterScene { get; set; }

        // ID of the linked schedule scene
        public long ScheduleSceneID { get; set; }

        // Linked schedule scene
        public virtual ScheduleScene ScheduleScene { get; set; }
    }
}