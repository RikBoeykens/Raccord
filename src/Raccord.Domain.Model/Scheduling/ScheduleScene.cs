using Raccord.Domain.Model.Scenes;

namespace Raccord.Domain.Model.Scheduling
{
    /// Represents schedule scene on a day
    public class ScheduleScene : Entity
    {
        // Length in eights
        public int PageLength { get; set; }

        // The sorting order of the scene within the schedule day
        public int SortingOrder { get; set; }

        // ID of the linked schedule day
        public long ScheduleDayID { get; set; }

        // Linked image
        public virtual ScheduleDay ScheduleDay { get; set; }

        // ID of the linked scene
        public long SceneID { get; set; }

        // Linked scene
        public virtual Scene Scene { get; set; }
    }
}